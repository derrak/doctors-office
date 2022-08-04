using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DocOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DocOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DocOfficeContext _db;

    public DoctorsController(DocOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Doctors.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisDoctor = _db.Doctors
          .Include(doctor => doctor.JoinEntities)
          .ThenInclude(join => join.Specialty)
          .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    public ActionResult Create()
    {
      ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor, int SpecialtyId)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      if (SpecialtyId != 0)
      {
        _db.DoctorSpecialty.Add(new DoctorSpecialty() { SpecialtyId = SpecialtyId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

  }
}
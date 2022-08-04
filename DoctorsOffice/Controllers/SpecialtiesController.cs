using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DocOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DocOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DocOfficeContext _db;

    public SpecialtiesController(DocOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Specialties.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisSpecialty = _db.Specialties
          .Include(specialty => specialty.JoinEntities)
          .ThenInclude(join => join.Doctor)
          .FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    public ActionResult Create()
    {
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty specialty, int DoctorId)
    {
      _db.Specialties.Add(specialty);
      _db.SaveChanges();
      if (DoctorId != 0)
      {
        _db.DoctorSpecialty.Add(new DoctorSpecialty() { DoctorId = DoctorId, SpecialtyId = specialty.SpecialtyId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

  }
}

using Microsoft.EntityFrameworkCore;

namespace DocOffice.Models
{
  public class DocOfficeContext : DbContext
  {
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<DoctorSpecialty> DoctorSpecialty { get; set; }

    public DocOfficeContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

  }
}
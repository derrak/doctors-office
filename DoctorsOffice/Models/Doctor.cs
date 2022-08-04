using System.Collections.Generic;

namespace DocOffice.Models
{
  public class Doctor
  {
    public Doctor()
    {
      this.JoinEntities = new HashSet<DoctorSpecialty>();
    }

    public int DoctorId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<DoctorSpecialty> JoinEntities { get; set; }
  }
}
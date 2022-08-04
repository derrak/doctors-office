using System.Collections.Generic;

namespace DocOffice.Models{
  public class Specialty
  {
    public Specialty()
    {
      this.JoinEntities = new HashSet<DoctorSpecialty>();
    }

    public int SpecialtyId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<DoctorSpecialty> JoinEntities { get; set; }
  }
}
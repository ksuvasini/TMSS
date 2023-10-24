using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.Entities

{
    public class ProceduresClinic : BaseEntity
    {
        public ProceduresClinic()
        {
          //  this.Clinics = new HashSet<Clinic>();
        }
        [Key]
       public int ProcedureId { get; set; }
        public string? ProcedureName { get; set; }
        //public List<Clinic>? Clinics { get; set;}
        public int ClinicId { get; set; }
     

        //public virtual ICollection<Clinic> Clinics { get; set; }
        //  public virtual List<Clinic> Clinics { get; set; }
        //public List<int> SelectedClinicIds { get; set; }


    }


}

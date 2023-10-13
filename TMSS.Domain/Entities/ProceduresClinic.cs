using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TMSS.Domain.DTO;

namespace TMSS.Domain.Entities

{
    public class ProceduresClinic : BaseEntity
    {
        public ProceduresClinic()
        {
           // this.Clinics = new HashSet<Clinic>();
        }
        [Key]
       public int ProcedureId { get; set; }
        public string? ProcedureName { get; set; }
        //public List<Clinic>? Clinics { get; set;}
        public int ClinicId { get; set; }
       
        //public virtual ICollection<Clinic> Clinics { get; set; }


    }


}

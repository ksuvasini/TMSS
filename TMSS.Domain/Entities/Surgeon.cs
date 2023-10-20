using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TMSS.Domain.Entities
{
    public class Surgeon : BaseEntity
    {
       
        [Key]
        public int SurgeonId { get; set; }
        public string? SurgeonFirstName { get; set; }
        public string? SurgeonLastName { get; set; }
        public string? Speciality { get; set; }
        public DateTime? DatePPGranted { get; set; }
        public DateTime? DateStartedFirstCase { get; set; }
        public DateTime? ALSDate { get; set; }
        public int ProcedureId { get; set; }
        public int ClinicId { get; set; }
    }
    
}

using System.ComponentModel.DataAnnotations;
using TMSS.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.DTO
{
    public class SurgeonDto : BaseDto
    {
        [Key]
        public int SurgeonId { get; set; }

        [Required(ErrorMessage = "first name is required!")]
        public string? SurgeonFirstName { get; set; }

        [Required(ErrorMessage = "last name is required!")]
        public string? SurgeonLastName { get; set; }

        [Required(ErrorMessage = "speciality is required!")]
        public string? Speciality { get; set; }

        [Required(ErrorMessage = "DatePPGranted is required!")]
        public DateTime? DatePPGranted { get; set; }

        [Required(ErrorMessage = "DateFirstCase is required!")]
        public DateTime? DateStartedFirstCase { get; set; }

        [Required(ErrorMessage = "ALSDate is required!")]
        public DateTime? ALSDate { get; set; }

        public int ProcedureId { get; set; }

        public int ClinicId { get; set; }

        public int ProcedureName { get; set; }

        public int ClinicName { get; set; }

    }
}

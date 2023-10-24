﻿using System.ComponentModel.DataAnnotations;


namespace TMSS.Domain.Entities
{
    public class Surgeon : BaseEntity
    {
       
        [Key]
        public int SurgeonId { get; set; }
        public string? SurgeonFirstName { get; set; }
        public string? SurgeonLastName { get; set; }
        public string? Speciality { get; set; }

        [Required(ErrorMessage = "surgeon name is required!")]
        public string? SurgeonName { get; set; }

        [Required(ErrorMessage = "DatePPGranted is required!")]
        public DateTime? DatePPGranted { get; set; }

        [Required(ErrorMessage = "DateFirstCase is required!")]
        public DateTime? DateFirstCase { get; set; }

        [Required(ErrorMessage = "ALSDate is required!")]
        public DateTime? DateStartedFirstCase { get; set; }
        public DateTime? ALSDate { get; set; }
        public int ProcedureId { get; set; }
        public int ClinicId { get; set; }

        public int ProcedureName { get; set; }

        public int ClinicName { get; set; }

    }
    
}

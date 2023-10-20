﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
    public class SurgeonViewModel
    {
        [Key]
        public int SurgeonId { get; set; }

        [Required(ErrorMessage = "surgeon name is required!")]
        public string? SurgeonName { get; set; }

        [Required(ErrorMessage = "DatePPGranted is required!")]
         public DateTime? DatePPGranted { get; set; }

        [Required(ErrorMessage = "DateFirstCase is required!")]
        public DateTime? DateFirstCase { get; set; }

        [Required(ErrorMessage = "ALSDate is required!")]
         public DateTime? ALSDate { get; set; }

        public int ProcedureId { get; set; }

        public int ClinicId { get; set; }

        public List<SelectListItem> Procedures { get; set; }

        public List<SelectListItem> Clinics { get; set; }

    }
}

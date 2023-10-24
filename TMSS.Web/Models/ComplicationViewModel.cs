﻿using System.ComponentModel.DataAnnotations;


namespace TMSS.Web.Models
{
    public class ComplicationViewModel
    {
        [Key]
        public int ComplicationId { get; set; }

        [Required(ErrorMessage = "Complication name is required!")]
        public string ComplicationName { get; set; }

    }
}

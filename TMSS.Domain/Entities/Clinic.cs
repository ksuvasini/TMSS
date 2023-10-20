using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        [Key]
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "clinic name is required!")]
        public string? ClinicName { get; set; }

        [Required(ErrorMessage = "clinic location  is required!")]
        public string? ClinicLocation { get; set; }
      
    }
}

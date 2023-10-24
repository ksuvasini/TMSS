using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.Entities
{
    public class Complication : BaseEntity
    {
        [Key]
        public int ComplicationId { get; set; }
        [Required(ErrorMessage = "complication name is required!")]
        public string ComplicationName { get; set; }    
    }
}

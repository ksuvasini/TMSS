using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.DTO
{
    public class ClinicDto : BaseDto
    {
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? ClinicLocation { get; set; }

    }
}

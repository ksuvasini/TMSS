using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.DTO
{
    public class ComplicationDto : BaseDto
    {
        public int ComplicationId { get; set; }
        public string ComplicationName { get; set; }    
    }
}

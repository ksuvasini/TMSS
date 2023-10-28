using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.DTO
{
    public class SurgeryDto : BaseDto
    {
        public int SurgeryId { get; set; }
        public int PatientId { get; set; }
        public int SurgeonId { get; set; }
        public int ProcedureId { get; set; }
        public int ClinicID { get; set; }
        public DateTime SurgeryDate { get; set; }

        public DateTime ArrivedInClinic { get; set; }
        public DateTime ArrivedInTheatre { get; set; }
        public DateTime AnesthesiaStartTime { get; set; }
        public DateTime KnifeSkinTime { get; set; }
        public DateTime ProcedureFinishTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}

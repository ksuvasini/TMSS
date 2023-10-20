using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.DTO
{
    public class ClinicDto : BaseDto
    {
        [Key]
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicLocation { get; set; }
    }
}

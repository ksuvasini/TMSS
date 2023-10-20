using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.Entities

{
    public class Clinic : BaseEntity
    {
        [Key]
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicLocation { get; set; }
    }
}

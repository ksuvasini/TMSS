using System.ComponentModel.DataAnnotations;

namespace TMSSDemo.Models
{
    public class ProcedurViewModele
    {
        [Key]
        public int ProcedureId { get; set; }

        [Required(ErrorMessage = "procedure name is required!")]
        public string? ProcedureName { get; set; }

       

    }
}

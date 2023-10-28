namespace TMSS.Web.Models
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public int PatientNo { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

        public DateTime RegistrationDate { get; set; }
        public int SurgeryId { get; set; }
        //public int PatientId { get; set; }
        public int SurgeonId { get; set; }
        public int ProcedureId { get; set; }
        public int ClinicID { get; set; }
        public DateTime SurgeryDate { get; set; }
    }
}
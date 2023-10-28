using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.Entities
{
    public class Patient : BaseEntity
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
    }
}

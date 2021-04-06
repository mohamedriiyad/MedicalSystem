using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalSystem.Domain
{
    public class UpdatePatientModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string FirstRelativeName { get; set; }
        public string FirstRelativePhoneNumber { get; set; }
        public string SecondRelativeName { get; set; }
        public string SecondRelativePhoneNumber { get; set; }

    }
}

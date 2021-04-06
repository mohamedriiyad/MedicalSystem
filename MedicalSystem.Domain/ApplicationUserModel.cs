using System;

namespace MedicalSystem.Domain
{
    public class ApplicationUserModel
    {

        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string PatientSsn { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string FirstRelativeName { get; set; }
        public string FirstRelativePhoneNumber { get; set; }
        public string SecondRelativeName { get; set; }
        public string SecondRelativePhoneNumber { get; set; }

        public string Role { get; set; }




    }
}

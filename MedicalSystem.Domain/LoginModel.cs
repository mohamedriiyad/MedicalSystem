using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalSystem.Domain
{
    public class LoginModel
    {

        [Required]
        public string PatientSSN { get; set; }

        [Required]
        public string Password { get; set; }


    }
}

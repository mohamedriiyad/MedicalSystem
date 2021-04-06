using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace MedicalSystem.Domain
{
    public class User : IdentityUser
    {
        [Required]
        public string PatientSsn { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string FirstRelativeName { get; set; }

        [Required]
        public string FirstRelativePhoneNumber { get; set; }

        [Required]
        public string SecondRelativeName { get; set; }

        [Required]
        public string SecondRelativePhoneNumber { get; set; }

        public virtual MedicalHistory MedicalHistory { get; set; }
    }
}

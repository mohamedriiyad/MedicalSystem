using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MedicalSystem.Domain;

namespace MedicalSystem.WebAPI.Controllers
{
    public class PatientProfileController:Controller
    {

        private readonly UserManager<User> _userManager;
        public PatientProfileController(UserManager<User> userManager)
        {

            this._userManager = userManager;
        }


        /*

       [HttpGet]
       [Authorize]
       //GET : /api/UserProfile

       public async Task<Object> GetUserProfile()
       {
           string userId = User.Claims.First(c => c.Type == "UserID").Value;
           var user = await _userManager.FindByIdAsync(userId);
           return new
           {
               user.FullName,
               user.Email,
               user.UserName,
               user.City,
               user.Gender
           };
       }
       */

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/PatientProfile/GetForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }




        [HttpGet]
        [Authorize(Roles = "Patient")]
        [Route("api/PatientProfile/GetForPatient")]
        public string GetForPatient()
        {
            return "Web method for patient";
        }



        [HttpGet]
        [Authorize(Roles = "hospital")]
        [Route("api/PatientProfile/GetForHospital")]
        public string GetForHospital()
        {
            return "Web method for hospital";
        }









        [HttpGet]
        [Route("api/PatientProfile/GetPatientById/{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetPatientById(string patientId)
        {
            var user = await _userManager.FindByIdAsync(patientId);
            if (user == null)
            {
                return BadRequest("sorry user not found");
            }
            return Ok(new
            {
                user.FullName,
                user.PhoneNumber,
                user.Gender,
                user.City
            });
        }


        [HttpGet]
        [Route("api/PatientProfile/GetPatientBySsn/{patientSsn}")]
        [Authorize]

        public async Task<IActionResult> GetPatientBySsn(string patientSsn)
        {
            var user = await _userManager.Users.FirstAsync(e => e.PatientSsn == patientSsn);
            if (user == null)
            {
                return BadRequest("sorry user not found");
            }
            return Ok(new
            {
                user.FullName,
                user.PhoneNumber,
                DateOfBirth = user.Birthdate,
                RealtiveOneName = user.FirstRelativeName,
                RealtiveTwoName = user.SecondRelativeName,
                RealtiveOnePhone = user.FirstRelativePhoneNumber,
                RealtiveTwoPhone = user.SecondRelativePhoneNumber,

            });
        }



        [HttpPut]
        [Route("api/PatientProfile/UpdatePatient/{patientId}")]
        public async Task<IActionResult> UpdatePatient(string patientId, [FromBody] UpdatePatientModel model)
        {
            var user = await _userManager.FindByIdAsync(patientId);

            if (user == null)
            {
                return BadRequest();
            }


            user.City = model.City;
            user.Gender = model.Gender;
            user.FullName = model.FullName;
            user.FirstRelativeName = model.FirstRelativeName;
            user.FirstRelativePhoneNumber = model.FirstRelativePhoneNumber;
            user.SecondRelativeName = model.SecondRelativeName;
            user.PasswordHash = model.Password;
            user.SecondRelativePhoneNumber = model.SecondRelativePhoneNumber;
            user.PhoneNumber = model.PhoneNumber;


            await _userManager.UpdateAsync(user);
            return Ok();

        }
        
    }
}

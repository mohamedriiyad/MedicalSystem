using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MedicalSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(ApplicationUserModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(201);

            var x = await _roleManager.RoleExistsAsync("Patient");
            if (!x)
            {
                var role = new IdentityRole {Name = "Patient"};
                await _roleManager.CreateAsync(role);
            }


            var y = await _roleManager.RoleExistsAsync("Admin");
            if (!y)
            {
                var role = new IdentityRole {Name = "Admin"};
                await _roleManager.CreateAsync(role);
            }

            var z = await _roleManager.RoleExistsAsync("hospital");
            if (!z)
            {
                var role = new IdentityRole {Name = "hospital"};
                await _roleManager.CreateAsync(role);
            }


            model.Role = "Admin";

            var user = new User()
            {

                FullName = model.FullName,
                PatientSsn = model.PatientSsn,
                UserName = model.PatientSsn,
                Birthdate = model.Birthdate,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                FirstRelativeName = model.FirstRelativeName,
                FirstRelativePhoneNumber = model.FirstRelativePhoneNumber,
                SecondRelativeName = model.SecondRelativeName,
                SecondRelativePhoneNumber = model.SecondRelativePhoneNumber,
                City = model.City
            };

            var result= await _userManager.CreateAsync(user, model.Password);
            

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                return Ok(result);
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(errors);
        }


        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Enter all Required fields");

            var user = _userManager.Users.FirstOrDefault(e=>e.PatientSsn == model.PatientSSN);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)) // valid user //
            {
                var role = await _userManager.GetRolesAsync(user);

                var options = new IdentityOptions();

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:4200",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>() {
                        new Claim(options.ClaimsIdentity.RoleClaimType , role.FirstOrDefault())

                    },
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signinCredentials

                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, UserId = user.Id });


            }


            return BadRequest(new { message = "patientSSN or password is incorrect." });
        }
    }
}

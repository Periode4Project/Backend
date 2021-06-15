using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.Controllers
{
    [Route("Auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login/")]
        public ActionResult Login([FromBody] ApplicationClasses.LoginUserCredentials loginUserCredentials)
        {
            if (DatabaseRepositories.LoginRepository.IsValidLogin(loginUserCredentials.Email, loginUserCredentials.Password))
                return Ok();
            return Unauthorized();
        }
        [HttpPost("Register/")]
        public ActionResult Register([FromBody] ApplicationClasses.RegistrationUser registrationUser)
        {
            if (DatabaseRepositories.LoginRepository.IsValidRegistration(registrationUser.Email, registrationUser.FullName, registrationUser.Password))
                return Ok();
            return Unauthorized();
        }
        [HttpGet("IsUserAdmin")]
        public ActionResult isuserAdmin([FromBody] ApplicationClasses.EmailClass emailClass)
        {
            if (DatabaseRepositories.LoginRepository.UserIsAdmin(emailClass.Email))
                return Ok();
            return NotFound();
        }
    }
}

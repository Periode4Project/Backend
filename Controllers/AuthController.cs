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
        public ActionResult<ApplicationClasses.LoggedInUser> Login([FromBody] ApplicationClasses.LoginUserCredentials loginUserCredentials)
        {
            ApplicationClasses.LoggedInUser loggedInUser = DatabaseRepositories.LoginRepository.GetLoginInformation(loginUserCredentials.Email, loginUserCredentials.Password);
            if (loggedInUser.Email != null && loggedInUser.Fullname != null)
                return Ok(loggedInUser);
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

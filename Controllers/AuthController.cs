using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SailingBackend.ApplicationClasses;

namespace SailingBackend.Controllers
{
    /// <summary>
    /// Define API controller route and class
    /// </summary>
    [Route("Auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Check if login credentials are valid
        /// </summary>
        /// <param name="loginUserCredentials"> Object of type LoginUserCredentials, containing Email and Password </param>
        /// <returns>
        /// ActionResult/HTTP status code,
        ///  Object of type LoggedInUser
        /// </returns>
        [HttpPost("Login/")]
        [ProducesResponseType(typeof(ActionResult<LoggedInUser>), 200)] // Ok
        [ProducesResponseType(typeof(ActionResult), 403)] // Unauthorized
        public ActionResult<LoggedInUser> Login([FromBody] LoginUserCredentials loginUserCredentials)
        {
            LoggedInUser loggedInUser = DatabaseRepositories.LoginRepository.GetLoginInformation(loginUserCredentials.Email, loginUserCredentials.Password);
            if (loggedInUser.Email != null && loggedInUser.Fullname != null)
                return Ok(loggedInUser);
            return Unauthorized();
        }

        /// <summary>
        /// Create new login credentials.
        /// </summary>
        /// <param name="registrationUser"> Object of type Registrationuser, containing user information </param>
        /// <returns> ActionResult/HTTP status code </returns>
        [HttpPost("Register/")]
        [ProducesResponseType(typeof(ActionResult), 200)] // Ok
        [ProducesResponseType(typeof(ActionResult), 403)] // Unauthorized
        public ActionResult Register([FromBody] RegistrationUser registrationUser)
        {
            if (DatabaseRepositories.LoginRepository.IsValidRegistration(registrationUser.Email, registrationUser.FullName, registrationUser.Password))
                return Ok();
            return Unauthorized();
        }

        /// <summary>
        /// Check if mail address belongs to admin account
        /// </summary>
        /// <param name="emailClass"> Object containing only email address </param>
        /// <returns> ActionResult/HTTP status code </returns>
        [HttpPost("IsUserAdmin")]
        [ProducesResponseType(typeof(ActionResult), 200)] // Ok
        [ProducesResponseType(typeof(ActionResult), 404)] // Not Found
        public ActionResult IsUserAdmin([FromBody] EmailClass emailClass)
        {
            if (DatabaseRepositories.LoginRepository.UserIsAdmin(emailClass.Email))
                return Ok();
            return NotFound();
        }
    }
}

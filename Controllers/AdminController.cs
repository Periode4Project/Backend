using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using SailingBackend.ApplicationClasses;
using SailingBackend.DatabaseClasses;

namespace SailingBackend.Controllers
{
    /// <summary>
    /// Define API controller route and class
    /// </summary>
    [Route("/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Add an activity as admin user
        /// </summary>
        /// <param name="activityInfo"> Object of type AdminCreateActivityInfo, contains activity details and userinfo </param>
        /// <returns> ActionResult/HTTP status code </returns>
        [HttpPost("AddActivity/")]
        [ProducesResponseType(typeof(ActionResult), 200)] // OK
        [ProducesResponseType(typeof(ActionResult), 403)] // Unauthorized
        [ProducesResponseType(typeof(ActionResult), 500)] // Server Error
        public ActionResult AddActivity([FromBody] AdminCreateActivityInfo activityInfo)
        {
            if (!DatabaseRepositories.LoginRepository.GetLoginInformation(activityInfo.LoginUserCredentials.Email, activityInfo.LoginUserCredentials.Password).IsAdmin)
                return StatusCode(403);
            try
            {

                DatabaseClasses.Activity activity = new DatabaseClasses.Activity
                {
                    ActivityDesc = activityInfo.SubmittedLocation.ActivityDesc,
                    ActivityImage = activityInfo.SubmittedLocation.ActivityImage,
                    ActivityName = activityInfo.SubmittedLocation.ActivityName,
                    ActivityType = activityInfo.SubmittedLocation.ActivityType,
                    Address = activityInfo.SubmittedLocation.ActivityPlace.Address,
                    City = activityInfo.SubmittedLocation.ActivityPlace.City,
                    EntranceFee = activityInfo.SubmittedLocation.EntranceFee,
                    Lat = activityInfo.SubmittedLocation.ActivityPlace.Location.lat,
                    Lng = activityInfo.SubmittedLocation.ActivityPlace.Location.lng
                };

                if (!DatabaseRepositories.AdminRepository.IsAddActivitySuccessful(activity))
                    return StatusCode(500);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Delete a review from the application
        /// </summary>
        /// <param name="login"> Object of type LoginUserCredentials, containing email and password </param>
        /// <param name="review"> integer for review ID, entered in query string </param>
        /// <returns> ActionResult/HTTP status code </returns>
        [HttpDelete("DeleteReview")]
        [ProducesResponseType(typeof(ActionResult), 200)] // OK
        [ProducesResponseType(typeof(ActionResult), 403)] // Unauthorized
        [ProducesResponseType(typeof(ActionResult), 500)] // Server Error
        public ActionResult DeleteReview([FromBody] LoginUserCredentials login, int review)
        {
            if (!DatabaseRepositories.LoginRepository.GetLoginInformation(login.Email, login.Password).IsAdmin)
                return StatusCode(403);
            try
            {
                if (DatabaseRepositories.AdminRepository.IsDeleteReviewSuccessful(review))
                    return Ok();
                return StatusCode(500);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return StatusCode(500);
        }
        /// <summary>
        /// Delete an activity from the application
        /// </summary>
        /// <param name="login"> Object of type LoginUserCredentials, containing email and password </param>
        /// <param name="activity"> integer for activity ID, entered in query string </param>
        /// <returns> ActionResult/HTTP status code </returns>
        [HttpDelete("DeleteActivity")]
        [ProducesResponseType(typeof(ActionResult), 200)] // OK
        [ProducesResponseType(typeof(ActionResult), 403)] // Unauthorized
        [ProducesResponseType(typeof(ActionResult), 500)] // Server Error
        public ActionResult DeleteActivity([FromBody] LoginUserCredentials login, int activity)
        {
            if (!DatabaseRepositories.LoginRepository.GetLoginInformation(login.Email, login.Password).IsAdmin)
                return StatusCode(403);
            try
            {
                if (DatabaseRepositories.AdminRepository.IsDeleteActivitySuccessful(activity))
                    return Ok();
                return StatusCode(500);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return StatusCode(500);
        }
    }
}

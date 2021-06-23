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

namespace SailingBackend.Controllers
{
    [Route("/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost("AddActivity/")]
        public ActionResult AddActivity([FromBody] ApplicationClasses.AdminCreateActivityInfo activityInfo)
        {
            if (!DatabaseRepositories.LoginRepository.GetLoginInformation(activityInfo.LoginUserCredentials.Email, activityInfo.LoginUserCredentials.Password).IsAdmin)
                return StatusCode(403);
            try
            {
                //string encodedUrl = "http://open.mapquestapi.com/geocoding/v1/address?key=" + Config.config.MapQuestToken + "&location=" + HttpUtility.UrlEncode(activityInfo.SubmittedLocation.ActivityPlace.Address);
                //Console.WriteLine(encodedUrl);
                //HttpClient client = new HttpClient();
                //client.DefaultRequestHeaders.Add("Accept", "application/json");
                //HttpResponseMessage response = client.GetAsync(encodedUrl).Result;
                //response.EnsureSuccessStatusCode();
                //ApplicationClasses.MapQuestResponse locationData = JsonConvert.DeserializeObject<ApplicationClasses.MapQuestResponse>(response.Content.ReadAsStringAsync().Result);

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
        [HttpDelete("DeleteReview")]
        public ActionResult DeleteReview([FromBody] ApplicationClasses.LoginUserCredentials login, int review)
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

        [HttpDelete("DeleteActivity")]
        public ActionResult DeleteActivity([FromBody] ApplicationClasses.LoginUserCredentials login, int activity)
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

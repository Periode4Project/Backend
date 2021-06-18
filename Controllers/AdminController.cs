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
                string encodedUrl = "http://open.mapquestapi.com/geocoding/v1/address?key=" + Config.config.MapQuestToken + "&location=" + HttpUtility.UrlEncode(activityInfo.SubmittedLocation.Address);
                Console.WriteLine(encodedUrl);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = client.GetAsync(encodedUrl).Result;
                response.EnsureSuccessStatusCode();
                ApplicationClasses.MapQuestResponse locationData = JsonConvert.DeserializeObject<ApplicationClasses.MapQuestResponse>(response.Content.ReadAsStringAsync().Result);

                DatabaseClasses.Activity activity = new DatabaseClasses.Activity
                {
                    ActivityDesc = activityInfo.SubmittedLocation.ActivityDesc,
                    ActivityImage = activityInfo.SubmittedLocation.ActivityImg,
                    ActivityName = activityInfo.SubmittedLocation.ActivityName,
                    ActivityType = activityInfo.SubmittedLocation.ActivityType,
                    Address = activityInfo.SubmittedLocation.Address,
                    City = activityInfo.SubmittedLocation.City,
                    EntranceFee = activityInfo.SubmittedLocation.Entrancefee,
                    Lat = locationData.results[0].locations[0].latLng.lat,
                    Lng = locationData.results[0].locations[0].latLng.lng
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
    }
}

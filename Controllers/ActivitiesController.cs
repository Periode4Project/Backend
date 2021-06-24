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
    [Route("/Activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        /// <summary>
        /// Gets all activities from database and returns as json
        /// </summary>
        /// <returns>
        /// ActionResult (HTTP statuscode) 200 OK, 
        /// List of type Activity in request body.
        /// </returns>
        [ProducesResponseType(typeof(List<Activity>), 200)]
        [HttpGet("GetAll")]
        public ActionResult<List<Activity>> getAllActivities()
        {
            return Ok(DatabaseRepositories.ActivitiesRepository.GetAllActivities());
        }
    }
}

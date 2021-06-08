using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.Controllers
{
    [Route("/Activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<List<ApplicationClasses.Activity>> getAllActivities()
        {
            return Ok(DatabaseRepositories.ActivitiesRepository.GetAllActivities());
        }
    }
}

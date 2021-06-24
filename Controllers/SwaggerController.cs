using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.Controllers
{
    /// <summary>
    /// Create API controller and hide from Swagger
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        /// <summary>
        /// Redirect / to /swagger
        /// </summary>
        /// <returns> Permanent Redirect</returns>
        [HttpGet("/")]
        public IActionResult RedirectToDocs()
        {
            return RedirectPermanent("/swagger");
        }
    }
}

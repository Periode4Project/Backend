using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult RedirectToDocs()
        {
            return RedirectPermanent("/swagger");
        }
    }
}

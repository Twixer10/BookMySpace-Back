using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookMySpace.API.Controllers
{
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VersionController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> getVersion()
        {
            var versionInfo = _configuration.GetSection("ApiInformations");
            return this.Ok(new {name = versionInfo["Name"],
                version = versionInfo["Version"],
                description= versionInfo["Description"],
                contact = versionInfo["Contact"],
            });
        }
    }
}

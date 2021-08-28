using ApiLinkShortener.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : Controller
    {
        [HttpPost, Route("Ip")]
        public IActionResult Ip([FromBody] Data data)
        {
            AnalyticsRepository analytics = new();
            analytics.SaveInfo(data);

            return Ok();
        }

        [HttpGet, Route("Platform")]
        public string Platform()
        {
            AnalyticsRepository analytics = new();
            return analytics.Platform();
        }
    }

    public struct Data
    {
        public string Ip { get; set; }
        public string Site { get; set; }
        public string So { get; set; }
    }
}

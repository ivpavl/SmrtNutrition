using Microsoft.AspNetCore.Mvc;
using System;

namespace SmrtNutrition.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetTime()
        {
            // return DateTime.Now.ToString("hh:mm:ss tt");
            var currentTime = DateTime.Now.ToString("hh:mm:ss tt");

            return Ok(new { time = currentTime });

        }
    }

}

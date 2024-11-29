using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FitFolio.Api.Controllers
{
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet("version")]
        public IActionResult Version()
        {
            return new JsonResult(GetVersion());
        }

        private Object GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();

            var version = assembly.Version.ToString();
            var name = assembly.Name;

            return new
            {
                version = version,
                name = name
            };
        }
    }
}

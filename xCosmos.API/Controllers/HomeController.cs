using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace xCosmos.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            return View();
        }
    }
}

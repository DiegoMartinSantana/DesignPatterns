using Example1_Singleton.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatronesDiseño.Singleton;
using System.Diagnostics;
using Tools;

namespace Example1_Singleton.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //agrego iptions privado
        private readonly IOptions<single_object_representation> _options;    
        public HomeController(IOptions<single_object_representation> options)
        {
            _options = options;
        }

        public IActionResult Index()
        {
            //manejo manual de nombre de archivo
          //  ObjectOnly.InstancewithName("log.txt").Save("Index Enter");
          ObjectOnly.InstancewithName(_options.Value.name).Save("Index Enter with inyection");
            return View();
        }

        public IActionResult Privacy()
        {
            // MANEJO POR APP SETTINGS
            ObjectOnly.InstancewithName(_options.Value.name).Save("privacy Enter with inyection");

            ObjectOnly.InstancewithName("log.txt").Save("Privacy Enter");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

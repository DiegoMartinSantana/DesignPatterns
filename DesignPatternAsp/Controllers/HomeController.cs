using DesignPatternAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DesignPatternAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly  IOptions<MyOptions> _options;

        public HomeController(IOptions<MyOptions> options)
        {
            _options = options;
        }

        public IActionResult Index( )
        {
              // extraigo el path de options! 
            Tools.Log.CreateLog(_options.Value.Path).Save("entro a Index");

            return View();
        }

        public IActionResult Privacy()
        {
            Tools.Log.CreateLog(_options.Value.Path).Save("entro a privacy");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

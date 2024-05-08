using DesignPatternAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatronesDiseño.Models.Data;
using PatronesDiseño.Repository;
using System.Diagnostics;

namespace DesignPatternAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly  IOptions<MyOptions> _options;

        private readonly  IPatronesDiseñoRepository<Medico> _RepositoryMedico;
        //OBTENGO INYECTADO EL IREPOSITORY
        public HomeController(IOptions<MyOptions> options,IPatronesDiseñoRepository<Medico> repositorioMedico)
        {
            _RepositoryMedico = repositorioMedico;
            _options = options;
        }

        public IActionResult Index( )
        {

            IEnumerable<Medico> listMedicos = _RepositoryMedico.GetAll();

              // extraigo el path de options! 
            Tools.Log.CreateLog(_options.Value.Path).Save("entro a Index");

            return View("Index",listMedicos); // le mando la vista y la LISTA
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

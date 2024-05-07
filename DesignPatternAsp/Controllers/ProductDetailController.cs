using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)//recibe el total x url
        {

            var EarnLocalFactory = new EarnLocalFactory(0.20m); //le pasa el porcentaje
            IEarn Earnlocal = EarnLocalFactory.Earn();

            var EarnForeignFactory = new EarnForeignFactory(0.25m, 1500); //pasa el extra 
            IEarn EarnForeign = EarnForeignFactory.Earn(); //devuelve la interfaz

            // agregamos para obtenerla en una vista.
            


            ViewBag.totalLocal = total + Earnlocal.Earn(total); // recibe total xque tiene su funcionalidad propia ,el porcentaje se le paso a la fabrica,que es la que controla todo.
            ViewBag.totalForeign = total+EarnForeign.Earn(total); 

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternAsp.Controllers
{
    public class ProductDetailController : Controller { 

        //lo va a recibir inyectado en elc onstructor
        private EarnFactory _earnLocalFactory;
        private EarnFactory _earnForeignFactory;
        // es una prop de mi controller 
        //lo recibe en un constructor
        public ProductDetailController(EarnLocalFactory factoryLocal,EarnForeignFactory factoryforeign)
        {
            _earnLocalFactory = factoryLocal;
            _earnForeignFactory = factoryforeign;   
        }


        public IActionResult Index(decimal total)//recibe el total x url
        {
            //para manejarlo en la vista lo guardo del tipo que devuelve que es un IEARN
            var EarnLocal = _earnLocalFactory.Earn(); 
            var EarnForeign = _earnForeignFactory.Earn();

            // agregamos para obtenerla en una vista.
            
            ViewBag.totalLocal = total + EarnLocal.Earn(total); // recibe total xque tiene su funcionalidad propia ,el porcentaje se le paso a la fabrica,que es la que controla todo.
            ViewBag.totalForeign = total+EarnForeign.Earn(total); 

            return View();
        }
    }
}

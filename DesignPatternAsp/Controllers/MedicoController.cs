using DesignPatternAsp.Models.ViewModels;
using DesignPatternAsp.Strategies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PatronesDiseño.Models.Data;
using PatronesDiseño.Repository;

namespace DesignPatternAsp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MedicoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   
     
        public IActionResult Index()
        {
            //vamos a mostrar especialidades aca. 

            IEnumerable<EspecialidadViewModel> listEspe= from e in _unitOfWork.RepositoryEspecialidade.GetAll()
                                                 select  new EspecialidadViewModel
                                                 {
                                                     Id = e.Idespecialidad,
                                                     Nombre = e.Nombre
                                                 };
                                                
            return View("Index",listEspe);

        }
        [HttpGet] // obtenemos la lista de especialidades
        public IActionResult AddMedico()
        {
            var especialidadesList = _unitOfWork.RepositoryEspecialidade.GetAll();

            ViewBag.Especialidades = new SelectList(especialidadesList,"Idespecialidad", "Nombre"); //creamos una lista conformada por id y nombre(nombres props del contexto)
            return View();

        }

        [HttpPost] // para actualizar la vista con la nueva especialidad
        public IActionResult AddMedico(MedicoViewModel medicoVM) //recibimos el view model 
        {
           // var medico = medicoVM;
            //valido el REQUERIDO DE MI VIEW MODEL
            if (!ModelState.IsValid)
            {
                //si no es valido devuelvo la vista con el modelo y sus datos precargados
                var especialidadesList = _unitOfWork.RepositoryEspecialidade.GetAll();

                ViewBag.Especialidades = new SelectList(especialidadesList, "Idespecialidad", "Nombre");

                return View("AddMedico", medicoVM);
            }
            // solo usa la estrategia para ADD Medicos.

            var MedStrategy = new MedicoStrategy();

            MedStrategy.Add(medicoVM, _unitOfWork);



           return  RedirectToAction("Index"); 

            
        }
        }
}

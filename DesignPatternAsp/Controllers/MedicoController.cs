using DesignPatternAsp.Models.ViewModels;
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
            // si es valido lleno el objeto a enviar a la BD.
            var medico = new Medico();

            medico.Idmedico = medicoVM.Id;
            //valido si ingreso un id de espcialidad
            if(medicoVM.IdEspecialidad == null) // si no ingreso una especialidad, ingreso una nueva!
            {
                var nuevaEspecialidad = new Especialidade();
                nuevaEspecialidad.Nombre = medicoVM.EspecialidadNueva;
                var randomInt  = new Random();
                //no valido x que son ejemplos.
                nuevaEspecialidad.Idespecialidad = randomInt.Next(200,500); // genero un id random
                // gracias a unitof work ,añado la nueva especialidad a la BD,pero envio todo junto
                _unitOfWork.RepositoryEspecialidade.Add(nuevaEspecialidad);            
            }
            else
            {
                medico.Idespecialidad = (int)medicoVM.IdEspecialidad;
                //asigna id porque el value de la lista que envio a la vista es el ID

            }
            medico.Nombre = medicoVM.Name;
            medico.Apellido = medicoVM.Apellido;
            medico.Fechanac = medicoVM.FechaNacimiento;
            medico.Fechaingreso = medicoVM.FechaIngreso;
            medico.CostoConsulta = medicoVM.CostoConsulta;
            medico.Sexo = medicoVM.Sexo;

            _unitOfWork.RepositoryMedico.Add(medico);

            //AÑADO TODO JUNTO A LA BD 
            _unitOfWork.Save(); 


           return  RedirectToAction("Index"); 

            
        }
        }
}

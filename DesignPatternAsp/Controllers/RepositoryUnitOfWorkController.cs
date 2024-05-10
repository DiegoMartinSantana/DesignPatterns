using DesignPatternAsp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PatronesDiseño.Repository;

namespace DesignPatternAsp.Controllers
{
    public class RepositoryUnitOfWorkController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryUnitOfWorkController (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<TurnosViewModel> Turnos = from t in _unitOfWork.RepositoryTurno.GetAll()
                                                  select new TurnosViewModel
                                                  {
                                                      IdTurno = (int)t.Idturno,
                                                      Fecha = t.Fechahora,
                                                      Duracion = t.Duracion,
                                                      IdPaciente = (int)t.Idpaciente,
                                                      IdMedico = (int)t.Idmedico
                                                  };




            return View("Index",Turnos);
        }
    }
}

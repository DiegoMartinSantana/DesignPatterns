using Microsoft.AspNetCore.Mvc;
using PatronesDiseño.Repository;
using Tools.BuilderGenerator;

namespace DesignPatternAsp.Controllers
{
    public class TextChoiseController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;
        public TextChoiseController(GeneratorConcreteBuilder generatorConcreteBuilder, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        //metodo para invocar el builder
        public IActionResult BuildFile(int optionFile)
        {

            try
            {
                var Medicos = _unitOfWork.RepositoryMedico.GetAll(); //lista a transformar
                var Director = new GeneratorDirector(_generatorConcreteBuilder);
                List<string> content = Medicos.Select(x => x.Nombre).ToList();

                string path ="file"+DateTime.Now.Ticks+new Random().Next(1000)+".txt";


                if (optionFile == 1)
                {
                    Director.CreateJson(content, path);
                }else
                {
                    Director.CreatePipe(content, path);
                }

                var Generator = _generatorConcreteBuilder.GetGenerator(); // obtengo el generador que esta trabajando
                Generator.Save();

                return Json("Archivo creado con exito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
               
            }


        }


    }
}

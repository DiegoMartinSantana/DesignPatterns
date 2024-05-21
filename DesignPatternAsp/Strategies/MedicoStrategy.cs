using DesignPatternAsp.Models.ViewModels;
using PatronesDiseño.Models.Data;
using PatronesDiseño.Repository;

namespace DesignPatternAsp.Strategies
{
    public class MedicoStrategy : IMedicoStrategy
    {
        public void Add(MedicoViewModel medicoVM, IUnitOfWork unitOfWork)
        {
            var medico = new Medico();

            medico.Idmedico = medicoVM.Id;
            //valido si ingreso un id de espcialidad
            if (medicoVM.IdEspecialidad == null) // si no ingreso una especialidad, ingreso una nueva!
            {
                var nuevaEspecialidad = new Especialidade();
                nuevaEspecialidad.Nombre = medicoVM.EspecialidadNueva;
                var randomInt = new Random();
                //no valido x que son ejemplos.
                nuevaEspecialidad.Idespecialidad = randomInt.Next(200, 500); // genero un id random
                // gracias a unitof work ,añado la nueva especialidad a la BD,pero envio todo junto
                unitOfWork.RepositoryEspecialidade.Add(nuevaEspecialidad);
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

            unitOfWork.RepositoryMedico.Add(medico);

            //AÑADO TODO JUNTO A LA BD 
            unitOfWork.Save();



        }
    }
}

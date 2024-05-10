using PatronesDiseño.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Repository
{
    public interface IUnitOfWork
    {
        public IPatronesDiseñoRepository<Paciente> RepositoryPaciente { get; }
        public IPatronesDiseñoRepository<Turno> RepositoryTurno{ get; }

        public IPatronesDiseñoRepository<Medico> RepositoryMedico { get; }

        public IPatronesDiseñoRepository<Especialidade> RepositoryEspecialidade { get; }
        public void Save();
    }
}

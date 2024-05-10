using PatronesDiseño.models;
using PatronesDiseño.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.UnitofWork
{
    public interface IUnitOfWork
    {
        public IMedicoRepository MedicoRepository { get; }
        public IRepository<Paciente> RepositoryPaciente { get; }


        public void Save();

    }
}

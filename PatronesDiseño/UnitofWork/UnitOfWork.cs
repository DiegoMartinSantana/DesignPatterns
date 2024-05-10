using PatronesDiseño.models;
using PatronesDiseño.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //vamos a manejar internamente cual singleton los repository
        private Repository<Paciente> _RepoPaciente { get; }
        private MedicoRepository _RepoMedico{get; }

        private readonly DiagnosticoContext _context;

        public UnitOfWork(DiagnosticoContext context)
        {
            _context = context;
        }
    //cuando quiera obtener los repository 
    //Evaluamos si ya se creo o no eso una vez
        public IMedicoRepository MedicoRepository
        {
            get
            {
                return _RepoMedico == null ? new MedicoRepository(_context) : _RepoMedico;
            }
        }

        public IRepository<Paciente> RepositoryPaciente
        {
            get
            {
                return _RepoPaciente == null ? new Repository<Paciente>(_context) : _RepoPaciente;

            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

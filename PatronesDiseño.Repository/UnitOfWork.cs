using PatronesDiseño.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PatronesDiseño.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PatronesDiseñoRepository<Paciente> _Pacientes { get; }

        private PatronesDiseñoRepository<Turno> _Turnos { get; }
        private readonly DiagnosticoContext _context;

        public UnitOfWork(DiagnosticoContext context)
        {
            _context = context;
        }


        IPatronesDiseñoRepository<Paciente> IUnitOfWork.RepositoryPaciente
        {
            get
            {
                return _Pacientes == null ? new PatronesDiseñoRepository<Paciente>(_context) : _Pacientes;
            }
        }

        public IPatronesDiseñoRepository<Turno> RepositoryTurno
        {
            get
            {
                return _Turnos == null ? new PatronesDiseñoRepository<Turno>(_context) : _Turnos;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

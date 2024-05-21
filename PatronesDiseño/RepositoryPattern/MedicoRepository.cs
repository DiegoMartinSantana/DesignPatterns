using Microsoft.EntityFrameworkCore;
using PatronesDiseño.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.RepositoryPattern
{

    public class MedicoRepository : IMedicoRepository
    {
        private DiagnosticoContext _context;
        public MedicoRepository(DiagnosticoContext context)
        {
            _context = context;
        }

        public void Add(Medico medico) => _context.Add(medico);

        public void Delete(long id)
        {
            var medico = _context.Medicos.Find(id);
            _context.Medicos.Remove(medico);
        }

        public IEnumerable<Medico> GetAll() => _context.Medicos.ToList();
        public Medico GetById(int id) => _context.Medicos.Find(id);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Medico medico)
        {
            _context.Entry(medico).State = EntityState.Modified;
        }
       
    }
}

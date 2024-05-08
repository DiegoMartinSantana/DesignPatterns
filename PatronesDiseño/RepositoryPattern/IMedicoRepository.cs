using PatronesDiseño.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.RepositoryPattern
{
    public interface IMedicoRepository
    {
        public void Add(Medico medico);
        public void Update(Medico medico);  
        public void Delete(int id);
        public Medico GetById(int id);
        public IEnumerable<Medico> GetAll();
        public void Save();
    }
}

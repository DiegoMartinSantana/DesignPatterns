using PatronesDiseño.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.RepositoryPattern
{
    public interface IRepository<TEntity>
    {

        public TEntity GetById(int id);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
        public IEnumerable<TEntity> GetAll();
        public void Save();
    }
}

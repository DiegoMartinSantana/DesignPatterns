using Microsoft.EntityFrameworkCore;
using PatronesDiseño.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Repository
{
    public class PatronesDiseñoRepository<TEntity> : IPatronesDiseñoRepository<TEntity> where TEntity : class
    {
        private DiagnosticoContext _context;
        private DbSet<TEntity> _dbSet;
        public PatronesDiseñoRepository(DiagnosticoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>(); // seteamos el contexto con el tentity
        }

        public void Add(TEntity entity)
        {
            //manejamos el db set
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

        public TEntity GetById(int id) => _dbSet.Find(id);


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);   //sobreescribe
            _context.Entry(entity).State = EntityState.Modified;      //seteo el state
        }
    }
}


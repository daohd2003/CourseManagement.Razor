using FUBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Sp25Prn222Context _context;
        protected readonly DbSet<T> _dbset;

        public Repository(Sp25Prn222Context context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}


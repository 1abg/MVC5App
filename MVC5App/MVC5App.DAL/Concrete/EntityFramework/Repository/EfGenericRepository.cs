using MVC5App.DAL.Abstract.Repository;
using MVC5App.DAL.Context;
using MVC5App.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Concrete.EntityFramework.Repository
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CountryContext _context;
        private readonly DbSet<T> _table;

        public EfGenericRepository(CountryContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Add(T entity)
        {
            try
            {
                return _table.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> exp = null)
        {
            return exp == null ? _table.ToList() : _table.Where(exp).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> exp)
        {
            return exp == null ? await _table.ToListAsync() : await _table.Where(exp).ToListAsync();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
        }

        public void Remove(int id)
        {
            _table.Remove(GetById(id));
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

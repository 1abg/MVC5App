using MVC5App.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Abstract.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(int id);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> exp);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> exp);
    }
}

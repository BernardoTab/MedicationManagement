using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicationManagement.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

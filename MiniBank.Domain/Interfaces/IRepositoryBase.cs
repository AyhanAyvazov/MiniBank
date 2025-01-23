using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> AddASync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByAsync(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetByAsync(Func<T, bool> predicate, int page, int pageSize);

    }
}

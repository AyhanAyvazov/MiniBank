using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> AddASync(T entity,CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        void Delete(T entity, CancellationToken cancellationToken); 
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken);

    }
}

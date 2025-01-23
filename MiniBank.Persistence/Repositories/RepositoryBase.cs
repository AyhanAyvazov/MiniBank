using Microsoft.EntityFrameworkCore;
using MiniBank.Domain.Interfaces;
using MiniBank.Persistence.Database; 
using System.Linq.Expressions; 

namespace MiniBank.Persistence.Repositories
{
    public class RepositoryBase<T>(MiniBankDbContext context) : IRepositoryBase<T> where T : class
    {
        public async Task<T> AddASync(T entity, CancellationToken cancellationToken)
        {
            var result = await context.Set<T>().AddAsync(entity, default);
            return result.Entity;

        }

        public void Delete(T entity, CancellationToken cancellationToken)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await context.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken)
        {
            return await context.Set<T>().AsNoTracking().Where(predicate).Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            return Task.FromResult(context.Set<T>().Update(entity).Entity);
        }
    }
}

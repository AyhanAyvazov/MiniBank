using MiniBank.Domain.Interfaces;
using MiniBank.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Persistence
{
    public class UnitOfWork(MiniBankDbContext dbContext) : IUnitOfWork
    {
        public async Task BeginTransactionAsync() => await dbContext.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync() => await dbContext.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync() => await dbContext.Database.RollbackTransactionAsync();

        public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}

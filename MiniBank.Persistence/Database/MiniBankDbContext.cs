using Microsoft.EntityFrameworkCore;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Persistence.Database
{
    public sealed class MiniBankDbContext(DbContextOptions<MiniBankDbContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

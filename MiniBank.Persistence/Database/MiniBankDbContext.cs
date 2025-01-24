using Microsoft.EntityFrameworkCore;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Entities.Users;

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

            modelBuilder.Entity<AccountType>().HasData(
      new AccountType { Id = 1, Name = "Savings", Description = "Savings account" },
      new AccountType { Id = 2, Name = "Current", Description = "Current account" }
  );

            modelBuilder.Entity<Currency>().HasData(
        new Currency { Id = 1, Code = "USD", Name = "US Dollar", Symbol = "$" },
        new Currency { Id = 2, Code = "EUR", Name = "Euro", Symbol = "€" },
        new Currency { Id = 3, Code = "GEL", Name = "Georgian Lari", Symbol = "₾" },
        new Currency { Id = 4, Code = "TL", Name = "Turkish Lira", Symbol = "₺" }
    );
            modelBuilder.Entity<Role>().HasData(
        new Role { Id = 1, Name = "Admin" },
        new Role { Id = 2, Name = "Employer" },
        new Role { Id = 3, Name = "Customer" }

    );
            modelBuilder.Entity<TransactionStatus>().HasData(
      new TransactionStatus { Id = 1, Name = "Pending" },
      new TransactionStatus { Id = 2, Name = "Completed" },
      new TransactionStatus { Id = 3, Name = "Failed" },
      new TransactionStatus { Id = 4, Name = "Cancelled" }
  );
            modelBuilder.Entity<TransactionType>().HasData(
      new TransactionType { Id = 1, Name = "Deposit" },
      new TransactionType { Id = 2, Name = "Withdrawal" },
      new TransactionType { Id = 3, Name = "Transfer" }
  );
        }

    }
}

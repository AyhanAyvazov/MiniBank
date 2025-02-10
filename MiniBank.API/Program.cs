using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniBank.API.Filters;
using MiniBank.API.Validators;
using MiniBank.API.Validators.Accounts;
using MiniBank.API.Validators.Currencies;
using MiniBank.API.Validators.Customers;
using MiniBank.API.Validators.Roles;
using MiniBank.API.Validators.Transactions;
using MiniBank.API.Validators.Users;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Interfaces;
using MiniBank.Infrastructure.Services;
using MiniBank.Persistence;
using MiniBank.Persistence.Database;
using MiniBank.Persistence.Repositories;
using MiniBank.Shared.Interfaces.IServices;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddDbContext<MiniBankDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteAccountDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteAccountTypeDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteBalanceDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetAccountDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetAccountTypeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetBalanceDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertAccountDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertAccountTypeDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertBalanceDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAccountDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAccountTypeDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateBalanceDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteCurrencyDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteExchangeRateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetCurrencyDTOValidators>();
builder.Services.AddValidatorsFromAssemblyContaining<GetExchangeRateDTOValidators>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCurrencyDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertExchangeRateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCurrencyDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateExchangeRateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCustomerDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertPermissionDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertRoleDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertRolePermissionDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertTransactionDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertTransactionStatusDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertTransactionTypeDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTransactionDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertUserDTOValidator>();



builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBalanceService, BalanceService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IAccountTypeService, AccountTypeService>();
builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();
builder.Services.AddScoped<ITransactionTypeService, TransactionTypeService>();
builder.Services.AddScoped<ITransactionStatusService, TransactionStatusService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MiniBankDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        IRepositoryBase<Account> _accountRepository;
        IUnitOfWork _unitOfWork;
        public AccountService(IRepositoryBase<Account> accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertAccountDTO> CreateAccountAsync(InsertAccountDTO accountDto)
        {
            var account = AccountMapping.InsertAccountDtoToEntity(accountDto);
            await _accountRepository.AddASync(account, default);
            await _unitOfWork.SaveChangesAsync();
            return accountDto;
        }


        public async Task<bool> DeleteAccountAsync(DeleteAccountDTO accountDto)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(a => a.Id == accountDto.id, CancellationToken.None);
            if (account == null)
                return false;

            _accountRepository.Delete(account, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<GetAccountDTO?> GetAccountByIdAsync(int accountId)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(a => a.Id == accountId, CancellationToken.None);
            return account?.AccountToGetAccountDto();

        }

        public async Task<IEnumerable<GetAccountDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepository.GetAllAsync(CancellationToken.None);
            return accounts.Select(a => a.AccountToGetAccountDto());
        }

        public async Task<bool> UpdateAccountAsync(int accountId, UpdateAccountDTO accountDto)
        {
            var existingAccount = await _accountRepository.FirstOrDefaultAsync(a => a.Id == accountId, CancellationToken.None);
            if (existingAccount == null)
                return false;

            existingAccount.UpdateAccountFromDto(accountDto);
            await _accountRepository.UpdateAsync(existingAccount, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}

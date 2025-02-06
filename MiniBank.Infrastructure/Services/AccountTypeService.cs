using MiniBank.Domain.Entities.Accounts;
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
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IRepositoryBase<AccountType> _accountTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountTypeService(IRepositoryBase<AccountType> accountTypeRepository, IUnitOfWork unitOfWork)
        {
            _accountTypeRepository = accountTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertAccountTypeDTO> CreateAccountTypeAsync(InsertAccountTypeDTO accountTypeDto)
        {
            var accountType = AccountTypeMapping.InsertDtoToAccountType(accountTypeDto);
            await _accountTypeRepository.AddASync(accountType, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return accountTypeDto;
        }

        public async Task<bool> DeleteAccountTypeAsync(DeleteAccountTypeDTO accountTypeDto)
        {
            var accountType = await _accountTypeRepository.FirstOrDefaultAsync(a => a.Id == accountTypeDto.Id, CancellationToken.None);
            if (accountType == null) return false;

            _accountTypeRepository.Delete(accountType, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetAccountTypeDTO>> GetAllAccountTypesAsync()
        {
            var accountTypes = await _accountTypeRepository.GetAllAsync(CancellationToken.None);
            return accountTypes.Select(a => a.AccountTypeToGetDto());
        }

        public async Task<GetAccountTypeDTO?> GetAccountTypeByIdAsync(int id)
        {
            var accountType = await _accountTypeRepository.FirstOrDefaultAsync(a => a.Id == id, CancellationToken.None);
            return accountType?.AccountTypeToGetDto();
        }

        public async Task<bool> UpdateAccountTypeAsync(int accountTypeId, UpdateAccountTypeDTO accountTypeDto)
        {
            var existing = await _accountTypeRepository.FirstOrDefaultAsync(a => a.Id == accountTypeId, CancellationToken.None);
            if (existing == null) return false;

            existing.UpdateAccountTypeFromDto(accountTypeDto);
            await _accountTypeRepository.UpdateAsync(existing, CancellationToken.None);
            return true;
        }
    }
}

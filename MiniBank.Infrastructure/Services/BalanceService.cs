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
    public class BalanceService : IBalanceService
    {
        private readonly IRepositoryBase<Balance> _balanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BalanceService(IRepositoryBase<Balance> balanceRepository, IUnitOfWork unitOfWork)
        {
            _balanceRepository = balanceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertBalanceDTO> CreateBalanceAsync(InsertBalanceDTO balanceDto)
        {
            var balance = BalanceMapping.InsertBalanceDtoToEntity(balanceDto);
            await _balanceRepository.AddASync(balance, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return balanceDto;
        }

        public async Task<bool> DeleteBalanceAsync(DeleteBalanceDTO balanceDto)
        {
            var balance = await _balanceRepository.FirstOrDefaultAsync(b => b.Id == balanceDto.Id, CancellationToken.None);
            if (balance == null) return false;

            _balanceRepository.Delete(balance, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetBalanceDTO>> GetAllBalancesAsync()
        {
            var balances = await _balanceRepository.GetAllAsync(CancellationToken.None);
            return balances.Select(b => b.BalanceToGetBalanceDto());
        }

        public async Task<GetBalanceDTO?> GetBalanceByIdAsync(int balanceId)
        {
            var balance = await _balanceRepository.FirstOrDefaultAsync(b => b.Id == balanceId, CancellationToken.None);
            return balance?.BalanceToGetBalanceDto();
        }

        public async Task<bool> UpdateBalanceAsync(int balanceId, UpdateBalanceDTO balanceDto)
        {
            var existing = await _balanceRepository.FirstOrDefaultAsync(b => b.Id == balanceId, CancellationToken.None);
            if (existing == null) return false;

            existing.AccountId = balanceDto.AccountId;
            existing.CurrencyId = balanceDto.CurrencyId;
            existing.Amount = balanceDto.Amount;
            existing.UpdatedDate = DateTime.Now;

            await _balanceRepository.UpdateAsync(existing, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

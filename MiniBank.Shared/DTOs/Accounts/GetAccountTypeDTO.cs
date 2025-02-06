using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Accounts
{
    public record GetAccountTypeDTO(int Id, string Name, string Description, DateTime CreatedDate, DateTime? UpdatedDate);

}

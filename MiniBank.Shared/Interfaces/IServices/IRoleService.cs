﻿using MiniBank.Shared.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface IRoleService
    {
        Task<InsertRoleDTO> CreateRoleAsync(InsertRoleDTO roleDto);
    }
}

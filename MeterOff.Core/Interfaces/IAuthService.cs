using MeterOff.Core.Models.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IAuthService
    {
        Task<NewAuthServiceResponseDto> SeedRolesAsync();

        Task<NewAuthServiceResponseDto> RegisterAsync(NewRegisterDto registerDto);
        Task<NewAuthServiceResponseDto> LoginAsync(NewLoginDto loginDto);
        Task<NewAuthServiceResponseDto> MakeAdminAsync(NewUpdatePermissionDto NewUpdatePermissionDto);
        Task<NewAuthServiceResponseDto> MakeOwnerAsync(NewUpdatePermissionDto NewUpdatePermissionDto);
    }
}

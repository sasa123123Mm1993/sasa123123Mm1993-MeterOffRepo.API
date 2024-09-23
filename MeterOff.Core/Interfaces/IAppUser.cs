using MeterOff.Core.Models;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IAppUser
    {
        IEnumerable<ApplicationUser> GetAllUsersWithDepartments();
        IEnumerable<AppUserDto> GetAllUsersBasicData();

        IEnumerable<SmallDepartmentDto> GetAllSmallDepartments();
        IEnumerable<SmallDepartmentUserDtoOutput> GetAllSmallDepartment_UserOutput();

        IEnumerable<AppRoleDto> GetAllRoles();
        IEnumerable<SmallDepartment> GetAllSmallDepartmentsByMainDepId();
        GetAllUsersWithDepartmentsOutput GetAllUserssByNatId(string NatId);
        Task<InsertUserInput> AddAsync(InsertUserInput model);
       
        Task<EditUserInput> UpdateAsync(string UserId, EditUserInput model);
        ChangePasswordDtoOutput ChangePassword(ChangePasswordDto model);

        Logout Logout();
        

        
        ApplicationUser DeActiveUser(string userId);
        ApplicationUser ResetUserPass(string userId);

        List<SmallDepartment_UserDto> GetUserDataByUserId(string userId);

        GetSmallDepartmentsByUserIdOutput GetSmallDepartmentsByUserIdOutput(string userId);

        GetAllUsersWithDepartmentsOutput GetUserWithDepartments(string userId);
        Task<UserDepartmentsRolesOutput> GetUserDataById(string userId);
        bool ValidateAddUserWithDeps(InsertUserInput model);
        bool ValidateUpdateUserWithDeps(string userId, EditUserInput model);
        Task<NewAuthServiceResponseDto> Register(NewRegisterDto model);
    }
}

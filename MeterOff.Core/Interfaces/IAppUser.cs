using MeterOff.Core.Models;
using MeterOff.Core.Models.Base;
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
        Response<List<ApplicationUser>> GetAllUsersWithDepartments();
        Response<IEnumerable<AppUserDto>> GetAllUsersBasicData();

        Response<IEnumerable<SmallDepartmentDto>> GetAllSmallDepartments();
        Response<IEnumerable<SmallDepartmentUserDtoOutput>> GetAllSmallDepartment_UserOutput();

        Response<IEnumerable<AppRoleDto>> GetAllRoles();
        //Response<IEnumerable<SmallDepartment>> GetAllSmallDepartmentsByMainDepId();
        Response<GetAllUsersWithDepartmentsOutput> GetAllUserssByNatId(string NatId);
        Task<Response<InsertUserInput>> AddAsync(InsertUserInput model);
        Task<Response<EditUserInput>> UpdateAsync(string UserId, EditUserInput model);
        Response<string> ChangePassword(ChangePasswordDto model);
        Response<bool> Logout();
        Response<string> DeActiveUser(string userId);
        Response<ApplicationUser> ResetUserPass(string userId);
        Response<List<SmallDepartment_UserDto>> GetUserDataByUserId(string userId);

        Response<GetSmallDepartmentsByUserIdOutput> GetSmallDepartmentsByUserIdOutput(string userId);

         Response<GetAllUsersWithDepartmentsOutput> GetUserWithDepartments(string userId);
         Response<UserDepartmentsRolesOutput> GetUserDataById(string userId);
         Response<bool> ValidateAddUserWithDeps(InsertUserInput model);
         Response<bool> ValidateUpdateUserWithDeps(string userId, EditUserInput model);
         Response<Task<NewAuthServiceResponseDto>> Register(NewRegisterDto model);
    }
}

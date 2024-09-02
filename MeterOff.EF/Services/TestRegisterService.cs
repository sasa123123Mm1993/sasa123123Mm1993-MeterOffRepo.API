using MeterOff.Core.Interfaces;
using MeterOff.Core.Models;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class TestRegisterService : ITestRegister
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestRegisterService(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<InsertUserInput> AddAsync(InsertUserInput model)
        {
            if (model != null)
            {

                //Create User With Role
                var input = new NewRegisterDto
                {
                    Email = "Test@gmail.com",
                    Code = "12345987456",
                    FullName = model.FullName,
                    IsActive = model.IsActive,
                    UserName = model.UserName,
                    Password = "123456",
                    NatId = model.NatId,
                    RoleId = model.RoleId,
                };


                var result = await Register(input);

                //Fill SmallDepartment_User Table
                List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();

                foreach (var item in model.smallDepartmentsIds)
                {
                    var smallDepartment_UserDto = new SmallDepartment_UserDto();
                    smallDepartment_UserDto.SmallDepartmentId = item;
                    smallDepartment_UserDto.AppUserId = result.UserId; //static 
                    NewDto.Add(smallDepartment_UserDto);
                    _context.SmallDepartment_Users.Add(new SmallDepartment_User
                    {
                        AppUserId = smallDepartment_UserDto.AppUserId,//static 
                        SmallDepartmentId = item,
                    });
                }

                _context.SaveChanges();

                return model;
            }

            return model;
        }

        public ApplicationUser DeActiveUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppRoleDto> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmallDepartmentDto> GetAllSmallDepartments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmallDepartment> GetAllSmallDepartmentsByMainDepId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmallDepartmentUserDtoOutput> GetAllSmallDepartment_UserOutput()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppUserDto> GetAllUsersBasicData()
        {
            throw new NotImplementedException();
        }

        public GetAllUsersWithDepartmentsOutput GetAllUserssByNatId(string NatId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsersWithDepartments()
        {
            throw new NotImplementedException();
        }

        public GetSmallDepartmentsByUserIdOutput GetSmallDepartmentsByUserIdOutput(string userId)
        {
            throw new NotImplementedException();
        }

        public List<SmallDepartment_UserDto> GetUserDataByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public GetAllUsersWithDepartmentsOutput GetUserWithDepartments(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDepartmentsRolesOutput> GetUserWithRole(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<NewAuthServiceResponseDto> Register(NewRegisterDto model)
        {
            ApplicationUser newUser = new ApplicationUser()
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.UserName,
                Code = model.Code,
                IsActive = model.IsActive,
                SecurityStamp = Guid.NewGuid().ToString(),
                NationalId = model.NatId,
            };

            var createUserResult = await _userManager.CreateAsync(newUser, model.Password);
            await _context.SaveChangesAsync();

            if (!createUserResult.Succeeded)
            {
                var errorString = "User Creation Failed Beacause: ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }

                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = errorString
                };
            }
            else
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    return new NewAuthServiceResponseDto()
                    {
                        IsSucceed = false,
                        Message = "User Not Found"
                    };
                }
                var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
                if (roleName == null)
                {
                    return new NewAuthServiceResponseDto()
                    {
                        IsSucceed = false,
                        Message = "Role Not Found"
                    };
                }
                var result = await _userManager.AddToRoleAsync(user, roleName);
                await _context.SaveChangesAsync();
                if (result.Succeeded)
                {
                    return new NewAuthServiceResponseDto()
                    {
                        IsSucceed = true,
                        Message = "Role assigned successfully",
                        UserId = newUser.Id,
                        RoleId = model.RoleId,
                        UserName = model.UserName,
                        Password = model.Password
                    };
                }
            }
            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User Created Successfully",
                UserId = newUser.Id,
                RoleId = model.RoleId,
                UserName = model.UserName,
                Password = model.Password
            };
        }

        public ApplicationUser ResetUserPass(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<EditUserInput> UpdateAsync(string UserId, EditUserInput model)
        {
            throw new NotImplementedException();
        }

        public bool ValidateAddUserWithDeps(InsertUserInput model)
        {
            throw new NotImplementedException();
        }
    }
}

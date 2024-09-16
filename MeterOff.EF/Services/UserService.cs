using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Exception;
using MeterOff.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Identity;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;
using System.Data;

namespace MeterOff.EF.Services
{
    
    public class UserService : IAppUser

    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly AccountService _accountService;


        public UserService(DBContext context,
            IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IAuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _authService = authService;
            _roleManager = roleManager;
           
            //_accountService = accountService;
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
                
                var userid = _context.Users.Where(u => u.UserName == model.UserName)
                     .Select(u => u.Id).FirstOrDefault();
                if (userid !=null)
                {
                    List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
                    foreach (var item in model.smallDepartmentsIds)
                    {
                        var smallDepartment_UserDto = new SmallDepartment_UserDto();
                        smallDepartment_UserDto.SmallDepartmentId = item;
                        smallDepartment_UserDto.AppUserId = userid;
                        NewDto.Add(smallDepartment_UserDto);
                        _context.SmallDepartment_Users.Add(new SmallDepartment_User
                        {
                            AppUserId = smallDepartment_UserDto.AppUserId,
                            SmallDepartmentId = item,
                        });
                    }
                    _context.SaveChanges();
                    return model;
                }
                else
                {
                    var result = await Register(input);

                    List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
                    foreach (var item in model.smallDepartmentsIds)
                    {

                        var smallDepartment_UserDto = new SmallDepartment_UserDto();
                        smallDepartment_UserDto.SmallDepartmentId = item;
                        smallDepartment_UserDto.AppUserId = result.UserId;
                        NewDto.Add(smallDepartment_UserDto);
                        _context.SmallDepartment_Users.Add(new SmallDepartment_User
                        {
                            AppUserId = smallDepartment_UserDto.AppUserId,
                            SmallDepartmentId = item,
                        });
                    }
                    _context.SaveChanges();
                    return model;
                }
            }

                return model;
            
            
           

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
                        RoleId = model.RoleId
                    };
                }
            }
            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User Created Successfully",
                UserId = newUser.Id,
                RoleId = model.RoleId
            };
        }



        public async Task<EditUserInput> UpdateAsync(string UserId, EditUserInput model)
        {
            
                var user = await _userManager.FindByIdAsync(UserId); //get user object by userid
                var oldRoles = await _userManager.GetRolesAsync(user);  // Get the role nameList for this user
                var oldRoleId = _context.UserRoles.FirstOrDefault(m=>m.UserId == UserId).RoleId;
                var oldRoleName = _context.Roles.Where(r => r.Id == oldRoleId).Select(r => r.Name).FirstOrDefault();
                var removeResult = await _userManager.RemoveFromRoleAsync(user, oldRoleName);

            if (model != null && user != null)
                {


                // var result = await _userManager.AddToRoleAsync(user, roleName);
                // var role = await _roleManager.FindByIdAsync(model.RoleId); //get the new role to add it with user
                // role.Name = roleName;


                var newRoleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
                var result = await _userManager.AddToRoleAsync(user, newRoleName);


                user.FullName = model.FullName;
                    user.UserName = model.UserName;
                    user.IsActive = model.IsActive;
                    user.NationalId = model.NatId;
                    var resultOfUpdateUser = await _userManager.UpdateAsync(user);
                    

                    List<SmallDepartment_UserDto> oldDto = new List<SmallDepartment_UserDto>();
                    var oldUserDepartment = _context.SmallDepartment_Users.Where(m => m.AppUserId == UserId).ToList();
                    foreach (var item in oldUserDepartment)
                    {
                        item.IsDeleted = true;
                    }

                    List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
                    foreach (var item in model.smallDepartmentsIds)
                    {
                        var smallDepartment_UserDto = new SmallDepartment_UserDto();
                        smallDepartment_UserDto.SmallDepartmentId = item;
                        smallDepartment_UserDto.AppUserId = UserId; 
                        NewDto.Add(smallDepartment_UserDto);
                    _context.SmallDepartment_Users.Update(new SmallDepartment_User
                    {
                        AppUserId = smallDepartment_UserDto.AppUserId,
                        SmallDepartmentId = item,
                        IsDeleted = false
                    });

                }

                _context.SaveChanges();

                }

            return model;
            
        }

        public ApplicationUser DeActiveUserNew(string userId)
        {
            var model = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (model.IsActive)
                model.IsActive = false;
            else { model.IsActive = true; }
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<AppRoleDto> GetAllRoles()
        {
            var roles = _context.Roles

                .Select(x => new AppRoleDto
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                })
                .ToList();
            return roles;
        }

        //public IEnumerable<ApplicationUser> GetAllUsersWithDepartments()
        //{
        //    var users = _context.Users.ToList();
        //    return users;
        //}


        public IEnumerable<SmallDepartmentDto> GetAllSmallDepartments()
        {
            var smallDep = _context.SmallDepartment
                .Select(m => new SmallDepartmentDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    AccountReferenceCounter = m.AccountReferenceCounter,
                    CodeAutoGenerated = m.CodeAutoGenerated,
                    MainDepartmentId = m.MainDepartmentId,
                    RegionCode = m.RegionCode,
                    SectionId = m.SectionId,
                    SouthCairoCode = m.SouthCairoCode
                })
                .ToList();
            return smallDep;

        }

        public IEnumerable<SmallDepartment> GetAllSmallDepartmentsByMainDepId()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<SmallDepartmentUserDtoOutput> GetAllSmallDepartment_UserOutput() 
        {
            var data = _context.SmallDepartment_Users.ToList();

            return _mapper.Map<IEnumerable<SmallDepartmentUserDtoOutput>>(data);
        }

        public ApplicationUser ResetUserPass(string userId)
        {

            var model = _context.Users.FirstOrDefault(u => u.Id == userId);

            string newPassword = "123456";
            string hashedNewPassword = _userManager.PasswordHasher.HashPassword(model, newPassword);
            if (model.PasswordHash != null)
                model.PasswordHash = hashedNewPassword;
            _context.SaveChanges();
            return model;
        }


        public List<SmallDepartment_UserDto> GetUserDataByUserId(string userId)
        {
            var list = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId).ToList();
            var data = _mapper.Map<List<SmallDepartment_UserDto>>(list);

            return data;

        }


        public GetAllUsersWithDepartmentsOutput GetAllUserssByNatId(string NatId)
        {
            var user = _context.Users.FirstOrDefault(u => u.NationalId == NatId);
            return _mapper.Map<GetAllUsersWithDepartmentsOutput>(user);
        }



        public GetSmallDepartmentsByUserIdOutput GetSmallDepartmentsByUserIdOutput(string userId)
        {
            GetSmallDepartmentsByUserIdOutput model = new GetSmallDepartmentsByUserIdOutput();

            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            model.AppUser = _mapper.Map<AppUserDto>(user);

            //model.SmallDepartments
            var SmallDepartment_Users = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId).ToList();
            var SmallDepartment_UsersDtos = _mapper.Map<List<SmallDepartment_UserDto>>(SmallDepartment_Users);

            List<SmallDepartmentDto> newSmallDepartments = new List<SmallDepartmentDto>();
            //List<int> newSmallDepartments = new List<int>();

            foreach (var item in SmallDepartment_UsersDtos)
            {
                newSmallDepartments.Add(item.SmallDepartment);
            }
            model.SmallDepartments = newSmallDepartments;
            var userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
            var userRoleName = _context.Roles.FirstOrDefault(r => r.Id == userRole);
            model.RoleId = userRole;
            return model;

        } //2 Trial


        public GetAllUsersWithDepartmentsOutput GetUserWithDepartments(string userId) // 3 Trial
        {
            var user = _context.Users
                //.Include(u => u.)
                //    .ThenInclude(ud => ud.Department)
                .FirstOrDefault(u => u.Id == userId);
            return _mapper.Map<GetAllUsersWithDepartmentsOutput>(user);
        }

        public async Task<UserDepartmentsRolesOutput> GetUserDataById(string userId)
        {
            var user = _context.Users
              .FirstOrDefault(u => u.Id == userId); 

            var userRoleId = _context.UserRoles
               .Where(ur => ur.UserId == userId)
               .Select(ur => ur.RoleId)
               .FirstOrDefault();

            var userRoles = await _userManager.GetRolesAsync(user);

            var SmallDepartment_Users = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId && u.IsDeleted != true).ToList();
            var SmallDepartment_UsersDtos = _mapper.Map<List<SmallDepartment_UserDto>>(SmallDepartment_Users);

            List<int> newSmallDepartments = new List<int>();

            foreach (var item in SmallDepartment_UsersDtos)
            {
                newSmallDepartments.Add(item.SmallDepartmentId);
            }

            var model = new UserDepartmentsRolesOutput();
            if (userRoleId != null)
            {
                model.UserName = user.UserName;
                model.Id = user.Id;
                model.Code = user.Code;
                model.FullName = user.FullName;
                model.IsActive = user.IsActive;
                model.IsDeleted = user.IsDeleted;
                model.NationalId = user.NationalId;
                model.RoleId = userRoleId;

                model.UserSmallDepartmentIDs = newSmallDepartments;
            }


            return model;

        }

        public IEnumerable<AppUserDto> GetAllUsersBasicData()
        {
            var users = _context.Users
                .Select(m => new AppUserDto
                {
                    Code = m.Code,
                    FullName = m.FullName,
                    IsActive = m.IsActive,
                    IsDeleted = m.IsDeleted,
                    NationalId = m.NationalId
                })
                .ToList();

            return users;
        }

        public string GetRoleNameByRoleId(string roleId)
        {
            var roleName = _context.Roles
                .Where(r => r.Id == roleId)
                .Select(r => r.Name)
                .FirstOrDefault();

            return roleName;
        }

        public bool ValidateAddUserWithDeps(InsertUserInput model)
        {

            if (model == null)
            {
                return false;
            }

            var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
            if (roleName == null)
            {
                throw new UserFriendlyException("User Don`t Have Role");
            }

            //var user = _userManager.FindByNameAsync(model.UserName);
            //if (user == null)
            //{
            //    throw new UserFriendlyException("User Not Found");
            //}

           

            if (model.smallDepartmentsIds.Any(item => item == null) || model.smallDepartmentsIds.Any(item => item == 0))
            {
                throw new UserFriendlyException("يجب ادخال ادارة للمستخدم");
            }

            if (model.NatId == null)
            {
                throw new UserFriendlyException("يجب ادخال هوية المستخدم");
            }

            if (model.RoleId == null)
            {
                throw new UserFriendlyException("يجب اختيار دور للمستخدم");
            }

            if (model.IsActive == null)
            {
                throw new UserFriendlyException("يجب ادخال حالة المستخدم");
            }

            if (model.UserName == null)
            {
                throw new UserFriendlyException("يجب ادخال اسم المستخدم");
            }

            if (model.FullName == null)
            {
                throw new UserFriendlyException("يجب ادخال الاسم بالكامل");
            }

            return true;

        }
        public bool ValidateUpdateUserWithDeps(string userId,EditUserInput model)
        {

            if (model == null)
            {
                return false;
            }

            var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
            if (roleName == null)
            {
                throw new UserFriendlyException("User Don`t Have Role");
            }


            var user = _context.Users
                   .Where(u => u.Id == userId)
                   .FirstOrDefault();
            if (user == null)
            {
                throw new UserFriendlyException("User Not Found");
            }


            if (model.smallDepartmentsIds.Any(item => item == null)|| model.smallDepartmentsIds.Any(item => item == 0))
            {
                throw new UserFriendlyException("يجب ادخال ادارة للمستخدم");
            }

            if (model.NatId == null)
            {
                throw new UserFriendlyException("يجب ادخال هوية المستخدم");
            }

            if (model.RoleId == null)
            {
                throw new UserFriendlyException("يجب اختيار دور للمستخدم");
            }

            if (model.IsActive == null)
            {
                throw new UserFriendlyException("يجب ادخال حالة المستخدم");
            }

            if (model.UserName == null)
            {
                throw new UserFriendlyException("يجب ادخال اسم المستخدم");
            }

            if (model.FullName == null)
            {
                throw new UserFriendlyException("يجب ادخال الاسم بالكامل");
            }

            return true;

        }


        // public async Task<string> GetRoleIdByUser(ApplicationUser user)
        //{
        //    var roleNames = _userManager.GetRolesAsync(user);
        //    var roleIds = _roleManager.Roles.Where(r => roleNames.Result.Contains(r.Name)).Select(r => r.Id).ToList();
        //    return roleIds.FirstOrDefault();
        //}

        Core.Models.Identity.ApplicationUser IAppUser.DeActiveUser(string userId)
        {
            var model = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (model.IsActive)
                model.IsActive = false;
            else { model.IsActive = true; }
            _context.SaveChanges();
            return model;
        }

        Core.Models.Identity.ApplicationUser IAppUser.ResetUserPass(string userId)
        {
            var model = _context.Users.FirstOrDefault(u => u.Id == userId);

            string newPassword = "123456";
            string hashedNewPassword = _userManager.PasswordHasher.HashPassword(model, newPassword);
            if (model.PasswordHash != null)
                model.PasswordHash = hashedNewPassword;
            _context.SaveChanges();
            return model;
        }

        IEnumerable<ApplicationUser> IAppUser.GetAllUsersWithDepartments()
        {
            var users = _context.Users.ToList();
            return users;
        }


    }
}

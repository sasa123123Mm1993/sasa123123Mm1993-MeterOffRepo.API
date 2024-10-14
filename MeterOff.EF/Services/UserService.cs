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
using MeterOff.Core.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using MeterOff.Core.Models.Enum;
using MeterOff.Core.Models.Base_Response.Providers;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MeterOff.Core.Models.Infrastructure;

namespace MeterOff.EF.Services
{

    public class UserService : IAppUser

    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly AccountService _accountService;


        public UserService(DBContext context, SignInManager<ApplicationUser> signInManager,
            IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IAuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _authService = authService;
            _roleManager = roleManager;
            _signInManager = signInManager;
            //_accountService = accountService;
        }
        public Response<string> ChangePassword(ChangePasswordDto model)
        {
            Response<string> response = new Response<string>();
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == model.UserId && u.IsDeleted !=true);

                if (user == null)
                {
                    response.code = Empty.Code;
                    response.message = "لا تتوفر بيانات خاصة بك قم بتسجيل بياناتك";
                    response.status = Empty.Status;
                    response.payload = string.Empty;
                    return response;
                }

                if (user.IsActive == false)
                {
                    response.code = Failed.Code;
                    response.message = "هذا المستخدم غير نشط يرجى الاتصال الاتصال بخدمة العملاء";
                    response.status = Failed.Status;
                    response.payload = string.Empty;
                    return response;
                }
                var passwordValid = _userManager.CheckPasswordAsync(user, model.currentPassword).Result;
                if (!passwordValid)
                {
                    response.code = Failed.Code;
                    response.message = "من فضلك ادخل كلمة المرور الصحيحة";
                    response.status = Failed.Status;
                    response.payload = string.Empty;
                    return response;
                }
                var result = _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);
                if (result.Result.Succeeded)
                {
                    response.payload = model.newPassword;
                    response.code = Updated.Code;
                    response.message = "تم التغيير بنجاح";
                    response.status = Updated.Status;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
        }

        public Response<string> DeActiveUser(string userId)
        {
            Response<string> response = new Response<string>();
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId && u.IsDeleted != true);

                if (user == null)
                {
                    response.code = Empty.Code;
                    response.message = "لا تتوفر بيانات خاصة بك قم بتسجيل بياناتك";
                    response.status = Empty.Status;
                    response.payload = string.Empty;
                    return response;
                }

                //if (user.IsActive == false)
                //{
                //    response.code = Failed.Code;
                //    response.message = "هذا المستخدم غير نشط يرجى الاتصال بخدمة العملاء";
                //    response.status = Failed.Status;
                //    response.payload = string.Empty;
                //    return response;
                //}

                if (user.IsActive)
                {
                    user.IsActive = false;
                    _context.Update(user);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.payload = Success.Status;
                        response.code = Updated.Code;
                        response.message = "تم التغيير بنجاح";
                        response.status = Updated.Status;
                        return response;
                    }
                   
                }
                else 
                { 
                    user.IsActive = true;
                    _context.Update(user);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.payload = Success.Status;
                        response.code = Updated.Code;
                        response.message = "تم التغيير بنجاح";
                        response.status = Updated.Status;
                        return response;
                    }
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
        }

        public Response<IEnumerable<AppRoleDto>> GetAllRoles()
        {
            Response<IEnumerable<AppRoleDto>> response = new Response<IEnumerable<AppRoleDto>>();
            try
            {
                var roles = _context.Roles
                    .Select(x => new AppRoleDto{RoleId = x.Id,RoleName = x.Name}).ToList();

                if (roles != null && roles.Any())
                {
                    response.payload = roles;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            
        }

        public Response<IEnumerable<SmallDepartmentDto>> GetAllSmallDepartments()
        {
            Response<IEnumerable<SmallDepartmentDto>> response = new Response<IEnumerable<SmallDepartmentDto>>();
           
            try
            {
                var smallDep = _context.SmallDepartment
                  .Where(m => m.IsDeleted !=true)
                  .Select(m => new SmallDepartmentDto
                  {
                      Id = m.Id,
                      Name = m.Name,AccountReferenceCounter = m.AccountReferenceCounter,CodeAutoGenerated = m.CodeAutoGenerated,
                      MainDepartmentId = m.MainDepartmentId,
                      RegionCode = m.RegionCode,SectionId = m.SectionId,SouthCairoCode = m.SouthCairoCode
                  })
                  .OrderByDescending(m => m.Id)
                  .ToList();

                if (smallDep != null && smallDep.Any())
                {
                    response.payload = smallDep;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

        }

        //public Response<IEnumerable<SmallDepartment>> GetAllSmallDepartmentsByMainDepId()
        //{
        //    throw new NotImplementedException();
        //}

        public Response<IEnumerable<SmallDepartmentUserDtoOutput>> GetAllSmallDepartment_UserOutput()
        {
            Response<IEnumerable<SmallDepartmentUserDtoOutput>> response = new Response<IEnumerable<SmallDepartmentUserDtoOutput>>();
            try
            {
                var data = _context.SmallDepartment_Users
                    .Where(m=>m.IsDeleted !=true)
                    .OrderByDescending(m=>m.Id)
                    .ToList();
                var smallDepUserDto = _mapper.Map<IEnumerable<SmallDepartmentUserDtoOutput>>(data);
                if (data != null && data.Any())
                {
                    response.payload = smallDepUserDto;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }


        }

        public Response<IEnumerable<AppUserDto>> GetAllUsersBasicData()
        {
            Response<IEnumerable<AppUserDto>> response = new Response<IEnumerable<AppUserDto>>();
            try
            {
                var users = _context.Users
                .Where(m=>m.IsDeleted!=true)
                .Select(m => new AppUserDto
                {
                    Code = m.Code,FullName = m.FullName,IsActive = m.IsActive,IsDeleted = m.IsDeleted,
                    NationalId = m.NationalId
                })
                  .ToList();

                if (users != null && users.Any())
                {
                    response.payload = users;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
        }

        public Response<GetAllUsersWithDepartmentsOutput> GetAllUserssByNatId(string NatId)
        {
            Response<GetAllUsersWithDepartmentsOutput> response = new Response<GetAllUsersWithDepartmentsOutput>();
            try
            {
                var user = _context.Users
                .Where(m => m.IsDeleted != true && m.NationalId == NatId)
                .FirstOrDefault();

                var data = _mapper.Map<GetAllUsersWithDepartmentsOutput>(user);
                if (user != null)
                {
                    response.payload = data;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            response.code = Failed.Code;
            response.message = Failed.messageEn;
            response.status = Failed.Status;
            response.payload = null;
            return response;


        }

        public Response<List<ApplicationUser>> GetAllUsersWithDepartments()
        {
            Response<List<ApplicationUser>> response = new Response<List<ApplicationUser>>();
            try
            {
                var users = _context.Users
                    .Where(n=>n.IsDeleted !=true)

                    .ToList();
               
                if (users != null && users.Any())
                {
                    response.payload = users;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }


        }
        public Response<GetSmallDepartmentsByUserIdOutput> GetSmallDepartmentsByUserIdOutput(string userId)
        {
            Response<GetSmallDepartmentsByUserIdOutput> response = new Response<GetSmallDepartmentsByUserIdOutput>();
            try
            {
                GetSmallDepartmentsByUserIdOutput model = new GetSmallDepartmentsByUserIdOutput();
                var user = _context.Users.Where(u => u.Id == userId && u.IsDeleted !=true).FirstOrDefault();
                model.AppUser = _mapper.Map<AppUserDto>(user);
                var SmallDepartment_Users = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId && u.IsDeleted != true).ToList();
                var SmallDepartment_UsersDtos = _mapper.Map<List<SmallDepartment_UserDto>>(SmallDepartment_Users);
                List<SmallDepartmentDto> newSmallDepartments = new List<SmallDepartmentDto>();
                foreach (var item in SmallDepartment_UsersDtos)
                {
                    newSmallDepartments.Add(item.SmallDepartment);
                }
                model.SmallDepartments = newSmallDepartments;
                var userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                var userRoleName = _context.Roles.FirstOrDefault(r => r.Id == userRole);
                model.RoleId = userRole;
                if (model != null)
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            response.code = Failed.Code;
            response.message = Failed.messageEn;
            response.status = Failed.Status;
            response.payload = null;
            return response;



        }
        public Response<UserDepartmentsRolesOutput> GetUserDataById(string userId)
        {
            Response<UserDepartmentsRolesOutput> response = new Response<UserDepartmentsRolesOutput>();
            try
            {
                var user = _context.Users
                    .Where(n => n.IsDeleted != true && n.Id == userId)
                    .FirstOrDefault();
                var userRoleId = _context.UserRoles.Where(ur => ur.UserId == userId)
                   .Select(ur => ur.RoleId)
                   .FirstOrDefault();
                //var userRoles = await _userManager.GetRolesAsync(user);
                var SmallDepartment_Users = _context.SmallDepartment_Users.
                    Where(u => u.AppUserId == userId && u.IsDeleted != true).ToList();
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


                if (model != null)
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

        }
        public Response<List<SmallDepartment_UserDto>> GetUserDataByUserId(string userId)
        {
            
            Response<List<SmallDepartment_UserDto>> response = new Response<List<SmallDepartment_UserDto>>();
            try
            {
                var users = _context.SmallDepartment_Users
                    .Where(u => u.AppUserId == userId && u.IsDeleted != true)
                    .ToList();

                var data = _mapper.Map<List<SmallDepartment_UserDto>>(users);

                if (data != null && data.Any())
                {
                    response.payload = data;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;


            }
        }
        public Response<GetAllUsersWithDepartmentsOutput> GetUserWithDepartments(string userId)
        {
            Response<GetAllUsersWithDepartmentsOutput> response = new Response<GetAllUsersWithDepartmentsOutput>();
            try
            {
                var user = _context.Users
                    .Where(n => n.IsDeleted != true && n.Id == userId)
                    .FirstOrDefault();

                var data = _mapper.Map<GetAllUsersWithDepartmentsOutput>(user);

                if (data != null)
                {
                    response.payload = data;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;


            }
      
        }
        public Response<bool> Logout()
        {
            Response<bool> response = new Response<bool>();
            try
            {
                var result = _signInManager.SignOutAsync();
                if (result == null)
                {
                    response.code = Failed.Code;
                    response.message = "Logout Failed";
                    response.status = Failed.Status;
                    response.payload = false;
                    return response;
                }
                else
                {
                        response.code = Success.Code;
                        response.payload = true;
                        response.status = Success.Status;
                        response.message = "Logout Successfully";
                        return response;
                    
                }
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = false;
                return response;
            }
        }
        public Response<ApplicationUser> ResetUserPass(string userId)
        {
            Response<ApplicationUser> response = new Response<ApplicationUser>();
            try
            {
                var model = _context.Users
                    .Where(n => n.IsDeleted != true && n.Id == userId)
                    .FirstOrDefault();
                string newPassword = "123456";
                string hashedNewPassword = _userManager.PasswordHasher.HashPassword(model, newPassword);
                if (model.PasswordHash != null)
                {
                    model.PasswordHash = hashedNewPassword;
                    _context.Update(model);
                    var ISSaved = Save() > 0;
                    response.payload = model;
                    response.code = Updated.Code;
                    response.status = Updated.Status;
                    response.message = "تم التغيير بنجاح";
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;


            }

        }
        public async Task<Response<EditUserInput>> UpdateAsync(string UserId, EditUserInput model)
        {
            Response<EditUserInput> updateUserInputResult = new Response<EditUserInput>();
            Task<Response<EditUserInput>> response = Task.FromResult(updateUserInputResult);

            try
            {
                var validResult = ValidateUpdateUserWithDeps(UserId, model);
                if (validResult.status == "Success")
                {
                    var user = await _userManager.FindByIdAsync(UserId); //get user object by userid
                    var oldRoles = await _userManager.GetRolesAsync(user);  // Get the role nameList for this user
                    var oldRoleId = _context.UserRoles.FirstOrDefault(m => m.UserId == UserId).RoleId;
                    var oldRoleName = _context.Roles.Where(r => r.Id == oldRoleId).Select(r => r.Name).FirstOrDefault();
                    var removeResult = await _userManager.RemoveFromRoleAsync(user, oldRoleName);
                    var data = _mapper.Map<EditUserInput>(model);

                    if (model == null)
                    {
                        response.Result.code = EmptyMember.Code;
                        response.Result.message = "هناك بيانات لم يتم ادخالها";
                        response.Result.status = EmptyMember.Status;
                        response.Result.payload = null;
                        return response.Result;
                    }
                    if (user == null)
                    {
                        response.Result.code = EmptyMember.Code;
                        response.Result.message = "لا يوجد مستخدم بهذا الاسم";
                        response.Result.status = EmptyMember.Status;
                        response.Result.payload = null;
                        return response.Result;
                    }

                    if (model != null && user != null)
                    {
                        var newRoleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
                        var result = await _userManager.AddToRoleAsync(user, newRoleName);

                        user.FullName = model.FullName;
                        user.UserName = model.UserName;
                        user.IsActive = model.IsActive;
                        user.NationalId = model.NatId;
                        var resultOfUpdateUser = await _userManager.UpdateAsync(user);


                        List<SmallDepartment_UserDto> oldDto = new List<SmallDepartment_UserDto>();
                        var oldUserDepartment = _context.SmallDepartment_Users.Where(m => m.AppUserId == UserId).ToList();
                        if (oldUserDepartment == null)
                        {
                            response.Result.code = EmptyMember.Code;
                            response.Result.message = "لا توجد ادارة بهذا الاسم";
                            response.Result.status = EmptyMember.Status;
                            response.Result.payload = null;
                            return response.Result;
                        }
                        foreach (var item in oldUserDepartment)
                        {
                            item.IsDeleted = true;
                        }
                        _context.SaveChanges();
                        List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
                        foreach (var item in model.smallDepartmentsIds)
                        {
                            var smallDepartment_UserDto = new SmallDepartment_UserDto();
                            smallDepartment_UserDto.SmallDepartmentId = item;
                            smallDepartment_UserDto.AppUserId = UserId;

                            var oldSmallDepartmentExist = _context.SmallDepartment_Users.
                                  Where(m => m.SmallDepartmentId == item
                                  && m.AppUserId == UserId && m.IsDeleted !=true).Any();
                            if (oldSmallDepartmentExist)
                            {
                                response.Result.payload = null;
                                response.Result.code = Failed.Code;
                                response.Result.message = $"{item}  :تمت اضافة هذا المستخدم مع الادارة رقم";
                                response.Result.status = Failed.Status;
                                return response.Result;
                            }


                            NewDto.Add(smallDepartment_UserDto);
                            _context.SmallDepartment_Users.Update(new SmallDepartment_User
                            {
                                AppUserId = smallDepartment_UserDto.AppUserId,
                                SmallDepartmentId = item,
                                IsDeleted = false
                            });
                        }
                        _context.SaveChanges();
                        var ISSaved = Save() > 0;
                        response.Result.payload = null;
                        response.Result.code = Updated.Code;
                        response.Result.status = Updated.Status;
                        response.Result.message = "تم التغيير بنجاح";
                        return response.Result;
                    }
                }
                else 
                {
                    response.Result.code = validResult.code;
                    response.Result.message = validResult.message;
                    response.Result.status = validResult.status;
                    response.Result.payload = null;
                    return response.Result;
                }
            }
            catch (Exception ex)
            {
                response.Result.code = GeneralException.Code;
                response.Result.message = GeneralException.messageAr;
                response.Result.status = ex.Message;
                response.Result.payload = null;
                return response.Result;
            }

            response.Result.code = Failed.Code;
            response.Result.message = Failed.messageEn;
            response.Result.status = Failed.Status;
            response.Result.payload = null;
            return response.Result;
        }
        public Task<Response<InsertUserInput>> AddAsync(InsertUserInput model)
        {

            Response<InsertUserInput> insertUserInputResult = new Response<InsertUserInput>();
            Task<Response<InsertUserInput>> response = Task.FromResult(insertUserInputResult);

            try
            {
                var result = ValidateAddUserWithDeps(model);
                if (result.status == "Success")
                {
                    List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
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
                    var userid = _context.Users.Where(u => u.UserName == model.UserName && u.IsDeleted != true)
                        .Select(u => u.Id).FirstOrDefault();
                    if (userid == null)
                    {
                        var resultOfRegister = Register(input);
                        foreach (var item in model.smallDepartmentsIds)
                        {
                            var smallDepartment_UserDto = new SmallDepartment_UserDto();
                            smallDepartment_UserDto.SmallDepartmentId = item;
                            smallDepartment_UserDto.AppUserId = resultOfRegister.code;

                            var oldSmallDepartmentExist = _context.SmallDepartment_Users.
                                Where(m => m.SmallDepartmentId == item
                                && m.AppUserId == resultOfRegister.code).Any();
                            if (oldSmallDepartmentExist)
                            {
                                response.Result.payload = null;
                                response.Result.code = Failed.Code;
                                response.Result.message = $"{item}  :تمت اضافة هذا المستخدم مع الادارة رقم";
                                response.Result.status = Failed.Status;
                                return response;
                            }

                            NewDto.Add(smallDepartment_UserDto);
                            _context.SmallDepartment_Users.Add(new SmallDepartment_User
                            {
                                AppUserId = smallDepartment_UserDto.AppUserId,
                                SmallDepartmentId = item,
                            });
                        }
                        var ISSaved = Save() > 0;
                        if (ISSaved)
                        {
                            response.Result.payload = null;
                            response.Result.code = Added.Code;
                            response.Result.message = "تم الاضافة بنجاح";
                            response.Result.status = Added.Status;
                            return response;
                        }

                    }
                    else
                    {
                        foreach (var item in model.smallDepartmentsIds)
                        {
                            var smallDepartment_UserDto = new SmallDepartment_UserDto();
                            smallDepartment_UserDto.SmallDepartmentId = item;
                            smallDepartment_UserDto.AppUserId = userid;
                            var oldSmallDepartmentExist = _context.SmallDepartment_Users.
                                Where(m => m.SmallDepartmentId == item
                                && m.AppUserId == userid).Any();
                            if (oldSmallDepartmentExist)
                            {
                                response.Result.payload = null;
                                response.Result.code = Failed.Code;
                                response.Result.message = $"{item}  :تمت اضافة هذا المستخدم مع الادارة رقم";
                                response.Result.status = Failed.Status;
                                return response;
                            }

                            NewDto.Add(smallDepartment_UserDto);
                            _context.SmallDepartment_Users.Add(new SmallDepartment_User
                            {
                                AppUserId = smallDepartment_UserDto.AppUserId,
                                SmallDepartmentId = item,
                            });
                        }
                        var ISSaved = Save() > 0;
                        if (ISSaved)
                        {
                            //var dto = _mapper.Map<GetAllUsersWithDepartmentsOutput>(model);
                            var InsertUserInputDto = _mapper.Map<Task<InsertUserInput>>(model);

                            response.Result.payload = model;
                            response.Result.code = Updated.Code;
                            response.Result.message = "تم الاضافة بنجاح";
                            response.Result.status = Updated.Status;
                            return response;
                        }
                    }
                }
                else
                {
                    response.Result.payload = null;
                    response.Result.code = result.code;
                    response.Result.status = result.status;
                    response.Result.message = result.message;
                    return response;
                }

                response.Result.payload = null;
                response.Result.code = Failed.Code;
                response.Result.status = Failed.Status;
                response.Result.message = "لم تتم عملية الاضافة بنجاح";
                return response;
            }
            catch (Exception ex)
            {
                response.Result.code = GeneralException.Code;
                response.Result.message = GeneralException.messageAr;
                response.Result.status = ex.Message;
                response.Result.payload = null;
                return response;
            }
        }
        public Response<bool> ValidateAddUserWithDeps(InsertUserInput model)
        {
            Response<bool> response = new Response<bool>();

            if (model == null)
            {
                response.code = Failed.Code;
                response.message = "خطأ فى أحد البيانات المدخلة أثناء التعديل";
                response.status = Failed.Status;
                response.payload = false;
                return response;
            }

            var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
            if (roleName == null)
            {
                response.code = EmptyMember.Code;
                response.message = "This User Don`t Have Role";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }
            //var user = _userManager.FindByNameAsync(model.UserName);
            //if (model.UserName == null)
            //{
            //    response.code = EmptyMember.Code;
            //    response.message = "يجب ادخال اسم المستخدم";
            //    response.status = EmptyMember.Status;
            //    response.payload = false;
            //    return response;
                
            //}
            if (model.smallDepartmentsIds.Any(item => item == null) || model.smallDepartmentsIds.Any(item => item == 0))
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال ادارة للمستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }
            if (model.NatId == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال هوية المستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.RoleId == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب اختيار دور للمستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.IsActive == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال حالة المستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.UserName == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال اسم المستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
            }

            if (model.FullName == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال الاسم بالكامل";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }
            response.code = Success.Code;
            response.message = Success.messageAr;
            response.status = Success.Status;
            response.payload = true;
            return response;
        }

        public Response<bool> ValidateUpdateUserWithDeps(string userId, EditUserInput model)
        {
            Response<bool> response = new Response<bool>();
            if (model == null)
            {
                response.code = Failed.Code;
                response.message = "خطأ فى أحد البيانات المدخلة أثناء التعديل";
                response.status = Failed.Status;
                response.payload = false;
                return response;
            }
            var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
            if (roleName == null)
            {
                response.code = EmptyMember.Code;
                response.message = "This User Don`t Have Role";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                response.code = EmptyMember.Code;
                response.message = "User Not Found";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;

            }


            if (model.smallDepartmentsIds.Any(item => item == null) || model.smallDepartmentsIds.Any(item => item == 0))
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال ادارة للمستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.smallDepartmentsIds.Any(item => item != null) && model.smallDepartmentsIds.Any(item => item != 0))
            {
                var smallDepartmentIList = _context.SmallDepartment.Where(c=>c.IsDeleted!=true).Select(s => s.Id).ToList();  
                foreach (var item in model.smallDepartmentsIds)
                {
                    bool exists = smallDepartmentIList.Any(n => n == item);
                    if (!exists)
                    {
                        response.code = EmptyMember.Code;
                        response.message = $"Department Id :({item}) Not Found";
                        response.status = EmptyMember.Status;
                        response.payload = false;
                        return response;
                    }
                }
            }
                if (model.NatId == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال هوية المستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.RoleId == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب اختيار دور للمستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.IsActive == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال حالة المستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.UserName == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال اسم المستخدم";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            if (model.FullName == null)
            {
                response.code = EmptyMember.Code;
                response.message = "يجب ادخال الاسم بالكامل";
                response.status = EmptyMember.Status;
                response.payload = false;
                return response;
            }

            response.code = Success.Code;
            response.message = Success.messageAr;
            response.status = Success.Status;
            response.payload = true;
            return response;
        }
        public Response<Task<NewAuthServiceResponseDto>> Register(NewRegisterDto model)
        {
            Response<Task<NewAuthServiceResponseDto>> response = new Response<Task<NewAuthServiceResponseDto>>();
            try
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    FullName = model.FullName,Email = model.Email,UserName = model.UserName,Code = model.Code,
                    IsActive = model.IsActive,SecurityStamp = Guid.NewGuid().ToString(),NationalId = model.NatId,
                };
                var createUserResult =  _userManager.CreateAsync(newUser, model.Password);
                 _context.SaveChangesAsync();

                if (!createUserResult.Result.Succeeded)
                {
                    var errorString = "User Creation Failed Beacause: ";
                    foreach (var error in createUserResult.Result.Errors)
                    {
                        errorString += " # " + error.Description;
                    }

                    response.code = Failed.Code;
                    response.message = errorString;
                    response.status = Failed.Status;
                    response.payload = null;
                    return response;
                }
                else
                {
                    var user =  _userManager.FindByNameAsync(model.UserName).Result;
                    if (user == null)
                    {
                        response.code = EmptyMember.Code;
                        response.message = "User Not Found";
                        response.status = EmptyMember.Status;
                        response.payload = null;
                        return response;
                    }
                    var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
                    if (roleName == null)
                    {
                        response.code = EmptyMember.Code;
                        response.message = "Role Not Found";
                        response.status = EmptyMember.Status;
                        response.payload = null;
                        return response;
                    }
                    var result =  _userManager.AddToRoleAsync(user, roleName);
                     _context.SaveChangesAsync();
                    
                    if (result.Result.Succeeded)
                    {
                        response.code = user.Id;
                        response.message = "User Created Successfully";
                        response.status = Success.Status;
                        response.payload = null;
                        return response;
                    }
                }
                response.code = Success.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
        }

        
        public int Save()
        {
            int status = -1;
            try { status = _context.SaveChanges(); }
            catch (Exception ex) { }
            return status;
        }



        






        //public async Task<InsertUserInput> AddAsync(InsertUserInput model)
        //{

        //    if (model != null)
        //    {

        //        //Create User With Role
        //        var input = new NewRegisterDto
        //        {
        //            Email = "Test@gmail.com",
        //            Code = "12345987456",
        //            FullName = model.FullName,
        //            IsActive = model.IsActive,
        //            UserName = model.UserName,
        //            Password = "123456",
        //            NatId = model.NatId,
        //            RoleId = model.RoleId,
        //        };

        //        var userid = _context.Users.Where(u => u.UserName == model.UserName)
        //             .Select(u => u.Id).FirstOrDefault();
        //        if (userid != null)
        //        {
        //            List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
        //            foreach (var item in model.smallDepartmentsIds)
        //            {
        //                var smallDepartment_UserDto = new SmallDepartment_UserDto();
        //                smallDepartment_UserDto.SmallDepartmentId = item;
        //                smallDepartment_UserDto.AppUserId = userid;
        //                NewDto.Add(smallDepartment_UserDto);
        //                _context.SmallDepartment_Users.Add(new SmallDepartment_User
        //                {
        //                    AppUserId = smallDepartment_UserDto.AppUserId,
        //                    SmallDepartmentId = item,
        //                });
        //            }
        //            _context.SaveChanges();
        //            return model;
        //        }
        //        else
        //        {
        //            var result = await Register(input);

        //            List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
        //            foreach (var item in model.smallDepartmentsIds)
        //            {

        //                var smallDepartment_UserDto = new SmallDepartment_UserDto();
        //                smallDepartment_UserDto.SmallDepartmentId = item;
        //                smallDepartment_UserDto.AppUserId = result.UserId;
        //                NewDto.Add(smallDepartment_UserDto);
        //                _context.SmallDepartment_Users.Add(new SmallDepartment_User
        //                {
        //                    AppUserId = smallDepartment_UserDto.AppUserId,
        //                    SmallDepartmentId = item,
        //                });
        //            }
        //            _context.SaveChanges();
        //            return model;
        //        }
        //    }

        //    return model;

        //}


        //public async Task<NewAuthServiceResponseDto> Register(NewRegisterDto model)
        //{
        //    ApplicationUser newUser = new ApplicationUser()
        //    {
        //        FullName = model.FullName,
        //        Email = model.Email,
        //        UserName = model.UserName,
        //        Code = model.Code,
        //        IsActive = model.IsActive,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        NationalId = model.NatId,
        //    };


        //    var createUserResult = await _userManager.CreateAsync(newUser, model.Password);
        //    await _context.SaveChangesAsync();

        //    if (!createUserResult.Succeeded)
        //    {
        //        var errorString = "User Creation Failed Beacause: ";
        //        foreach (var error in createUserResult.Errors)
        //        {
        //            errorString += " # " + error.Description;
        //        }

        //        return new NewAuthServiceResponseDto()
        //        {
        //            IsSucceed = false,
        //            Message = errorString
        //        };
        //    }
        //    else
        //    {
        //        var user = await _userManager.FindByNameAsync(model.UserName);
        //        if (user == null)
        //        {
        //            return new NewAuthServiceResponseDto()
        //            {
        //                IsSucceed = false,
        //                Message = "User Not Found"
        //            };
        //        }

        //        var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
        //        if (roleName == null)
        //        {
        //            return new NewAuthServiceResponseDto()
        //            {
        //                IsSucceed = false,
        //                Message = "Role Not Found"
        //            };
        //        }
        //        var result = await _userManager.AddToRoleAsync(user, roleName);
        //        await _context.SaveChangesAsync();
        //        if (result.Succeeded)
        //        {
        //            return new NewAuthServiceResponseDto()
        //            {
        //                IsSucceed = true,
        //                Message = "Role assigned successfully",
        //                UserId = newUser.Id,
        //                RoleId = model.RoleId
        //            };
        //        }
        //    }
        //    return new NewAuthServiceResponseDto()
        //    {
        //        IsSucceed = true,
        //        Message = "User Created Successfully",
        //        UserId = newUser.Id,
        //        RoleId = model.RoleId
        //    };
        //}
        //public async Task<EditUserInput> UpdateAsync(string UserId, EditUserInput model)
        //{

        //    var user = await _userManager.FindByIdAsync(UserId); //get user object by userid
        //    var oldRoles = await _userManager.GetRolesAsync(user);  // Get the role nameList for this user
        //    var oldRoleId = _context.UserRoles.FirstOrDefault(m => m.UserId == UserId).RoleId;
        //    var oldRoleName = _context.Roles.Where(r => r.Id == oldRoleId).Select(r => r.Name).FirstOrDefault();
        //    var removeResult = await _userManager.RemoveFromRoleAsync(user, oldRoleName);

        //    if (model != null && user != null)
        //    {


        //        // var result = await _userManager.AddToRoleAsync(user, roleName);
        //        // var role = await _roleManager.FindByIdAsync(model.RoleId); //get the new role to add it with user
        //        // role.Name = roleName;


        //        var newRoleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
        //        var result = await _userManager.AddToRoleAsync(user, newRoleName);


        //        user.FullName = model.FullName;
        //        user.UserName = model.UserName;
        //        user.IsActive = model.IsActive;
        //        user.NationalId = model.NatId;
        //        var resultOfUpdateUser = await _userManager.UpdateAsync(user);


        //        List<SmallDepartment_UserDto> oldDto = new List<SmallDepartment_UserDto>();
        //        var oldUserDepartment = _context.SmallDepartment_Users.Where(m => m.AppUserId == UserId).ToList();
        //        foreach (var item in oldUserDepartment)
        //        {
        //            item.IsDeleted = true;
        //        }

        //        List<SmallDepartment_UserDto> NewDto = new List<SmallDepartment_UserDto>();
        //        foreach (var item in model.smallDepartmentsIds)
        //        {
        //            var smallDepartment_UserDto = new SmallDepartment_UserDto();
        //            smallDepartment_UserDto.SmallDepartmentId = item;
        //            smallDepartment_UserDto.AppUserId = UserId;
        //            NewDto.Add(smallDepartment_UserDto);
        //            _context.SmallDepartment_Users.Update(new SmallDepartment_User
        //            {
        //                AppUserId = smallDepartment_UserDto.AppUserId,
        //                SmallDepartmentId = item,
        //                IsDeleted = false
        //            });

        //        }

        //        _context.SaveChanges();

        //    }

        //    return model;

        //}
        //public ApplicationUser DeActiveUserNew(string userId)
        //{
        //    var model = _context.Users.FirstOrDefault(u => u.Id == userId);

        //    if (model.IsActive)
        //        model.IsActive = false;
        //    else { model.IsActive = true; }
        //    _context.SaveChanges();
        //    return model;
        //}
        //public IEnumerable<AppRoleDto> GetAllRoles()
        //{
        //    var roles = _context.Roles

        //        .Select(x => new AppRoleDto
        //        {
        //            RoleId = x.Id,
        //            RoleName = x.Name,
        //        })
        //        .ToList();
        //    return roles;
        //}
        ////public IEnumerable<ApplicationUser> GetAllUsersWithDepartments()
        ////{
        ////    var users = _context.Users.ToList();
        ////    return users;
        ////}
        //public IEnumerable<SmallDepartmentDto> GetAllSmallDepartments()
        //{
        //    var smallDep = _context.SmallDepartment
        //        .Select(m => new SmallDepartmentDto
        //        {
        //            Id = m.Id,
        //            Name = m.Name,
        //            AccountReferenceCounter = m.AccountReferenceCounter,
        //            CodeAutoGenerated = m.CodeAutoGenerated,
        //            MainDepartmentId = m.MainDepartmentId,
        //            RegionCode = m.RegionCode,
        //            SectionId = m.SectionId,
        //            SouthCairoCode = m.SouthCairoCode
        //        })
        //        .ToList();
        //    return smallDep;

        //}
        //public IEnumerable<SmallDepartment> GetAllSmallDepartmentsByMainDepId()
        //{
        //    throw new NotImplementedException();
        //}
        //public IEnumerable<SmallDepartmentUserDtoOutput> GetAllSmallDepartment_UserOutput()
        //{
        //    var data = _context.SmallDepartment_Users.ToList();

        //    return _mapper.Map<IEnumerable<SmallDepartmentUserDtoOutput>>(data);
        //}
        //public ApplicationUser ResetUserPass(string userId)
        //{

        //    var model = _context.Users.FirstOrDefault(u => u.Id == userId);

        //    string newPassword = "123456";
        //    string hashedNewPassword = _userManager.PasswordHasher.HashPassword(model, newPassword);
        //    if (model.PasswordHash != null)
        //        model.PasswordHash = hashedNewPassword;
        //    _context.SaveChanges();
        //    return model;
        //}
        //public List<SmallDepartment_UserDto> GetUserDataByUserId(string userId)
        //{
        //    var list = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId).ToList();
        //    var data = _mapper.Map<List<SmallDepartment_UserDto>>(list);

        //    return data;

        //}
        //public GetAllUsersWithDepartmentsOutput GetAllUserssByNatId(string NatId)
        //{
        //    var user = _context.Users.FirstOrDefault(u => u.NationalId == NatId);
        //    return _mapper.Map<GetAllUsersWithDepartmentsOutput>(user);
        //}


        //public GetSmallDepartmentsByUserIdOutput GetSmallDepartmentsByUserIdOutput(string userId)
        //{
        //    GetSmallDepartmentsByUserIdOutput model = new GetSmallDepartmentsByUserIdOutput();

        //    var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
        //    model.AppUser = _mapper.Map<AppUserDto>(user);

        //    //model.SmallDepartments
        //    var SmallDepartment_Users = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId).ToList();
        //    var SmallDepartment_UsersDtos = _mapper.Map<List<SmallDepartment_UserDto>>(SmallDepartment_Users);

        //    List<SmallDepartmentDto> newSmallDepartments = new List<SmallDepartmentDto>();
        //    //List<int> newSmallDepartments = new List<int>();

        //    foreach (var item in SmallDepartment_UsersDtos)
        //    {
        //        newSmallDepartments.Add(item.SmallDepartment);
        //    }
        //    model.SmallDepartments = newSmallDepartments;
        //    var userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
        //    var userRoleName = _context.Roles.FirstOrDefault(r => r.Id == userRole);
        //    model.RoleId = userRole;
        //    return model;

        //}

        //2 Trial
        //public GetAllUsersWithDepartmentsOutput GetUserWithDepartments(string userId) // 3 Trial
        //{
        //    var user = _context.Users
        //        //.Include(u => u.)
        //        //    .ThenInclude(ud => ud.Department)
        //        .FirstOrDefault(u => u.Id == userId);
        //    return _mapper.Map<GetAllUsersWithDepartmentsOutput>(user);
        //}
        //public async Task<UserDepartmentsRolesOutput> GetUserDataById(string userId)
        //{
        //    var user = _context.Users
        //      .FirstOrDefault(u => u.Id == userId);

        //    var userRoleId = _context.UserRoles
        //       .Where(ur => ur.UserId == userId)
        //       .Select(ur => ur.RoleId)
        //       .FirstOrDefault();

        //    var userRoles = await _userManager.GetRolesAsync(user);

        //    var SmallDepartment_Users = _context.SmallDepartment_Users.Where(u => u.AppUserId == userId && u.IsDeleted != true).ToList();
        //    var SmallDepartment_UsersDtos = _mapper.Map<List<SmallDepartment_UserDto>>(SmallDepartment_Users);

        //    List<int> newSmallDepartments = new List<int>();

        //    foreach (var item in SmallDepartment_UsersDtos)
        //    {
        //        newSmallDepartments.Add(item.SmallDepartmentId);
        //    }

        //    var model = new UserDepartmentsRolesOutput();
        //    if (userRoleId != null)
        //    {
        //        model.UserName = user.UserName;
        //        model.Id = user.Id;
        //        model.Code = user.Code;
        //        model.FullName = user.FullName;
        //        model.IsActive = user.IsActive;
        //        model.IsDeleted = user.IsDeleted;
        //        model.NationalId = user.NationalId;
        //        model.RoleId = userRoleId;

        //        model.UserSmallDepartmentIDs = newSmallDepartments;
        //    }


        //    return model;

        //}
        //public IEnumerable<AppUserDto> GetAllUsersBasicData()
        //{
        //    var users = _context.Users
        //        .Select(m => new AppUserDto
        //        {
        //            Code = m.Code,
        //            FullName = m.FullName,
        //            IsActive = m.IsActive,
        //            IsDeleted = m.IsDeleted,
        //            NationalId = m.NationalId
        //        })
        //        .ToList();

        //    return users;
        //}
        //public string GetRoleNameByRoleId(string roleId)
        //{
        //    var roleName = _context.Roles
        //        .Where(r => r.Id == roleId)
        //        .Select(r => r.Name)
        //        .FirstOrDefault();

        //    return roleName;
        //}
        //public bool ValidateAddUserWithDeps(InsertUserInput model)
        //{

        //    if (model == null)
        //    {
        //        return false;
        //    }

        //    var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
        //    if (roleName == null)
        //    {
        //        throw new UserFriendlyException("User Don`t Have Role");
        //    }

        //    //var user = _userManager.FindByNameAsync(model.UserName);
        //    //if (user == null)
        //    //{
        //    //    throw new UserFriendlyException("User Not Found");
        //    //}



        //    if (model.smallDepartmentsIds.Any(item => item == null) || model.smallDepartmentsIds.Any(item => item == 0))
        //    {
        //        throw new UserFriendlyException("يجب ادخال ادارة للمستخدم");
        //    }

        //    if (model.NatId == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال هوية المستخدم");
        //    }

        //    if (model.RoleId == null)
        //    {
        //        throw new UserFriendlyException("يجب اختيار دور للمستخدم");
        //    }

        //    if (model.IsActive == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال حالة المستخدم");
        //    }

        //    if (model.UserName == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال اسم المستخدم");
        //    }

        //    if (model.FullName == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال الاسم بالكامل");
        //    }

        //    return true;

        //}
        //public bool ValidateUpdateUserWithDeps(string userId, EditUserInput model)
        //{

        //    if (model == null)
        //    {
        //        return false;
        //    }

        //    var roleName = _context.Roles.Where(r => r.Id == model.RoleId).Select(r => r.Name).FirstOrDefault();
        //    if (roleName == null)
        //    {
        //        throw new UserFriendlyException("User Don`t Have Role");
        //    }


        //    var user = _context.Users
        //           .Where(u => u.Id == userId)
        //           .FirstOrDefault();
        //    if (user == null)
        //    {
        //        throw new UserFriendlyException("User Not Found");
        //    }


        //    if (model.smallDepartmentsIds.Any(item => item == null) || model.smallDepartmentsIds.Any(item => item == 0))
        //    {
        //        throw new UserFriendlyException("يجب ادخال ادارة للمستخدم");
        //    }

        //    if (model.NatId == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال هوية المستخدم");
        //    }

        //    if (model.RoleId == null)
        //    {
        //        throw new UserFriendlyException("يجب اختيار دور للمستخدم");
        //    }

        //    if (model.IsActive == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال حالة المستخدم");
        //    }

        //    if (model.UserName == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال اسم المستخدم");
        //    }

        //    if (model.FullName == null)
        //    {
        //        throw new UserFriendlyException("يجب ادخال الاسم بالكامل");
        //    }

        //    return true;

        //}
        //// public async Task<string> GetRoleIdByUser(ApplicationUser user)
        ////{
        ////    var roleNames = _userManager.GetRolesAsync(user);
        ////    var roleIds = _roleManager.Roles.Where(r => roleNames.Result.Contains(r.Name)).Select(r => r.Id).ToList();
        ////    return roleIds.FirstOrDefault();
        ////}
        //Core.Models.Identity.ApplicationUser IAppUser.DeActiveUser(string userId)
        //{
        //    var model = _context.Users.FirstOrDefault(u => u.Id == userId);

        //    if (model.IsActive)
        //        model.IsActive = false;
        //    else { model.IsActive = true; }
        //    _context.SaveChanges();
        //    return model;
        //}
        //Core.Models.Identity.ApplicationUser IAppUser.ResetUserPass(string userId)
        //{
        //    var model = _context.Users.FirstOrDefault(u => u.Id == userId);

        //    string newPassword = "123456";
        //    string hashedNewPassword = _userManager.PasswordHasher.HashPassword(model, newPassword);
        //    if (model.PasswordHash != null)
        //        model.PasswordHash = hashedNewPassword;
        //    _context.SaveChanges();
        //    return model;
        //}
        //IEnumerable<ApplicationUser> IAppUser.GetAllUsersWithDepartments()
        //{
        //    var users = _context.Users.ToList();
        //    return users;
        //}
        //public Response<string> ChangePassword(ChangePasswordDto model)
        //{
        //    Response<string> response = new Response<string>();
        //    try
        //    {
        //        var user = _context.Users.FirstOrDefault(u => u.Id == model.UserId);

        //        if (user == null)
        //        {
        //            response.code = Failed.Code;
        //            response.message = "لا تتوفر بيانات خاصة بك قم بتسجيل بياناتك";
        //            response.status = Failed.Status;
        //            return response;
        //        }

        //        if (user.IsActive == false)
        //        {
        //            response.code = Failed.Code;
        //            response.message = "هذا المستخدم غير نشط يرجى الاتصال الاتصال بخدمة العملاء";
        //            response.status = Failed.Status;
        //            return response;
        //        }
        //        var passwordValid =  _userManager.CheckPasswordAsync(user, model.currentPassword).Result;
        //        if (!passwordValid)
        //        {
        //            response.code = Failed.Code;
        //            response.message = "من فضلك ادخل كلمة المرور الصحيحة";
        //            response.status = Failed.Status;
        //            return response;
        //        }
        //        var result = _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);
        //        if (result.Result.Succeeded)
        //        {
        //            response.payload = model.newPassword;
        //            response.code = Updated.Code;
        //            response.message = "تم التغيير بنجاح";
        //            response.status = Updated.Status;
        //            return response;
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.code = Failed.Code;
        //        response.message = ex.Message;
        //        response.status = Failed.Status;
        //        response.payload = "خطأ عام";
        //        return response;
        //    }

        //}
        ////public PayLoad<ChangePasswordDtoOutput> ChangePassword(ChangePasswordDto model)
        ////{
        ////    var user = _context.Users.FirstOrDefault(u => u.Id == model.UserId);
        ////    if (user == null)
        ////    {
        ////        throw new Exception("User not found.");
        ////    }

        ////    var result =  _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);
        ////    if (result.Result.Succeeded)
        ////    {
        ////        var ChangePasswordDto = new PayLoad<ChangePasswordDtoOutput> 
        ////        {
        ////            Success = true,
        ////            Data = null,
        ////            Code = 200,
        ////            Errors = null,
        ////            Message ="تم التغيير بنجاح",
        ////        };
        ////        return ChangePasswordDto;
        ////    }

        ////    else
        ////    {
        ////        var errors = result.Result.Errors.Select(e => e.Description);
        ////        var errorChangePasswordDto = new PayLoad<ChangePasswordDtoOutput>
        ////        {
        ////            Success =false,
        ////            Data = null,
        ////            Code =6000,
        ////            Errors = null,
        ////            Message = "Request Failed",
        ////        };
        ////        return errorChangePasswordDto;
        ////    }

        ////}
        //public Logout Logout()
        //{
        //   var result =  _signInManager.SignOutAsync();
        //    if (result == null)
        //    {
        //        var errorLogoutDto = new Logout
        //        {
        //            Code = 6000,
        //            Message = "Logout Failed",
        //            Data = null,
        //        };
        //        return errorLogoutDto;
        //    }
        //    var logoutDto = new Logout
        //    {
        //        Code = 200,
        //        Message = "Logout Successfully",
        //        Data = null
        //    };
        //    return logoutDto;
        //}
    }
}

using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class AccountService : IAccountInterface
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly DBContext _context;
        public AccountService(UserManager<ApplicationUser> userManager, /*AuthService authService,*/
            RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> roleManager, DBContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
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
    }
}

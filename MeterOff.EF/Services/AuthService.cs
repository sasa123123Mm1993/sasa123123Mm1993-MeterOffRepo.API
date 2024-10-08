﻿using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Identity;
using MeterOff.Core.Models.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly DBContext _context;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, DBContext context
            , IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }


        public async Task<NewAuthServiceResponseDto> LoginAsync(NewLoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is null)
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Credentials"
                };

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Credentials"
                };

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FullName", user.FullName),
                new Claim("Code", user.Code),

            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GenerateNewJsonWebToken(authClaims);

            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = token,
                UserId = user.Id
            };
        }

        public async Task<NewAuthServiceResponseDto> MakeAdminAsync(NewUpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

            if (user is null)
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid User name!!!!!!!!"
                };

            await _userManager.AddToRoleAsync(user, StaticUserRoles.ADMIN);

            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User is now an ADMIN"
            };
        }

        public async Task<NewAuthServiceResponseDto> MakeOwnerAsync(NewUpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

            if (user is null)
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid User name!!!!!!!!"
                };

            await _userManager.AddToRoleAsync(user, StaticUserRoles.OWNER);

            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User is now an OWNER"
            };
        }

        public async Task<NewAuthServiceResponseDto> RegisterAsync(NewRegisterDto registerDto)
        {
            var isExistsUser = await _userManager.FindByNameAsync(registerDto.UserName);

            if (isExistsUser != null)
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "UserName Already Exists"
                };


            ApplicationUser newUser = new ApplicationUser()
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Code = registerDto.Code,
                IsActive = registerDto.IsActive,
                SecurityStamp = Guid.NewGuid().ToString(),
                NationalId = registerDto.NatId,
            };


            var createUserResult = _userManager.CreateAsync(newUser, registerDto.Password);
            await _context.SaveChangesAsync();

            if (!createUserResult.Result.Succeeded)
            {
                var errorString = "User Creation Failed Beacause: ";
                foreach (var error in createUserResult.Result.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = errorString
                };
            }

            var identityUserDto = new IdentityUserDto
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };
            var user = new IdentityUserDto { UserName = identityUserDto.UserName, Email = identityUserDto.Email };
            string roleName = GetRoleNameByRoleId(registerDto.RoleId).ToString();
            var roleExists = _roleManager.RoleExistsAsync(roleName);
            //if (roleExists ==null)
            //{
            //    var role = new IdentityRole(roleName);
            //     _roleManager.CreateAsync(role);
            //}
            //var output = _userManager.AddToRoleAsync(user, roleName);
            await _context.SaveChangesAsync();

            ////Get UserRoleName using registerDto.RoleId
            //var userRoles = _userManager.GetRolesAsync(newUser);

            //var roleName = userRoles.Result.FirstOrDefault();

            // Add a Default USER Role to all users
            //var user = await _userManager.FindByIdAsync(user);
            //var role = await _roleManager.FindByIdAsync(registerDto.RoleId);

            //var userRole = new AppUserRole
            //{
            //    UserId = user.Id,
            //    RoleId = registerDto.RoleId
            //};
            //_context.UserRoles.Add(userRole);
            //await _context.SaveChangesAsync();

            //await _userManager.AddToRoleAsync(user, roleName);


            //_context.UserRoles.Add(userRole);

            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User Created Successfully",
                UserId = newUser.Id
            };
        }

        public async Task<NewAuthServiceResponseDto> SeedRolesAsync()
        {
            bool isOwnerRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.OWNER);
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.ADMIN);
            bool isUserRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.USER);

            if (isOwnerRoleExists && isAdminRoleExists && isUserRoleExists)
                return new NewAuthServiceResponseDto()
                {
                    IsSucceed = true,
                    Message = "Roles Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.USER));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.ADMIN));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.OWNER));

            return new NewAuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "Role Seeding Done Successfully"
            };
        }

        private string GenerateNewJsonWebToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenObject = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }


        public string GetRoleNameByRoleId(string roleId)
        {
            var roleName = _context.Roles
                .Where(r => r.Id == roleId)
                .Select(r => r.Name)
                .FirstOrDefault();

            return roleName;
        }
    }
}

using MeterOff.Api.Models;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Identity;
using MeterOff.EF;
using MeterOff.EF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeterOff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly DBContext _context;
        //private readonly UserService _userService;
        private readonly ITestRegister _testRegisterService;
        public AccountController(UserManager<ApplicationUser> userManager,
            ITestRegister testRegisterService,
            RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> roleManager, DBContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
                _context = context;
            //_userService = userService;
            _testRegisterService = testRegisterService;
        }


        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] Register model)
        //{
        //    var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        return Ok(new { message = "User registered successfully" });
        //    }

        //    return BadRequest(result.Errors);
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] NewRegisterDto model)
        {
            var registerResult = await _testRegisterService.Register(model);
            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);

        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    SecurityAlgorithms.HmacSha256));

                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    IsSucceed = true,
                    UserId = user.Id
                });
            }

            return Unauthorized();
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var result = await _roleManager.CreateAsync(new Microsoft.AspNetCore.Identity.IdentityRole(role));
                if (result.Succeeded)
                {
                    return Ok(new { message = "Role added successfully" });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest("Role already exists");
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRole model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully" });
            }

            return BadRequest(result.Errors);
        }

      


    }
}

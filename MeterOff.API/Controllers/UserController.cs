using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Dto.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeterOff.API.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IAppUser _appUser;

        public UserController(IAppUser appUser, IMapper mapper)
        {
            _appUser = appUser;
            _mapper = mapper;
        }

        [HttpGet("GetAllUsersWithDepartments")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAllUsersWithDepartments()
        {
            var users = _appUser.GetAllUsersWithDepartments();
            //var data = _mapper.Map<IEnumerable<GetAllUsersWithDepartmentsOutput>>(users);
            return Ok(users);

        }
        [HttpPost("DeactivateUser/{userId}")]
        public IActionResult DeactivateUser(string userId)
        {
            var data = _appUser.DeActiveUser(userId);
            //var dto = _mapper.Map<GetAllUsersWithDepartmentsOutput>(data);
            return Ok(data);
        }

        [HttpPost("ResetPassword/{userId}")]
        public IActionResult ResetPassword(string userId)
        {
            var data = _appUser.ResetUserPass(userId);
            //var dto = _mapper.Map<GetAllUsersWithDepartmentsOutput>(data);
            return Ok(data);
        }

        [HttpPost("GetUserDataById")]
        public IActionResult GetUserDataById(string userId)
        {
            var data = _appUser.GetUserDataById(userId);
            return Ok(data);
        }

        [HttpGet("GetAllSmallDepartments")]
        public IActionResult GetAllSmallDepartments()
        {
            var data = _appUser.GetAllSmallDepartments();
            return Ok(data);
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _appUser.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost("AddUserWithDeps")]
        public async Task<IActionResult> AddUserWithDeps(InsertUserInput input)
        {
                var data = _appUser.AddAsync(input);
                if (data == null)
                    return NotFound();
                //var dto = _mapper.Map<GetAllUsersWithDepartmentsOutput>(data.Result);

                return Ok(data.Result);
            
        }



        [HttpPost("EditUserWithDeps")]
        public async Task<IActionResult> EditUserWithDeps(string userId, EditUserInput input)
        {

            var data = _appUser.UpdateAsync(userId, input);
            if (data == null)
                return NotFound();
            //var dto = _mapper.Map<GetAllUsersWithDepartmentsOutput>(data);
            else return Ok(data.Result);

        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto input)
        {
            var result = _appUser.ChangePassword(input);
            return Ok(result);
            
        }


        [HttpPost("Logout")]
        public  IActionResult Logout()
        {
            var result = _appUser.Logout();
            if (result == null)
                return NotFound();

            else
                return Ok(result);
        }







        //[HttpGet("GetAllSmallDepartment_UserOutput")]
        //public IActionResult GetAllSmallDepartment_UserOutput()
        //{
        //    var users = _appUser.GetAllSmallDepartment_UserOutput();

        //    var data = _mapper.Map<IEnumerable<SmallDepartmentUserDtoOutput>>(users);
        //    return StatusCode(200, data);

        //}

        //[HttpPost("GetUserDataByUserId/{userId}")]
        //public IActionResult GetUserDataByUserId(string userId)
        //{

        //    var data = _appUser.GetUserDataByUserId(userId);

        //    if (data == null)
        //        return NotFound();

        //    //var dto = _mapper.Map<UserDtoDetail>(data);
        //    return StatusCode(200, data);

        //}

        //[HttpPost("GetSmallDepartmentsByUserIdOutput/{userId}")]
        //public IActionResult GetSmallDepartmentsByUserIdOutput(string userId)
        //{

        //    var data = _appUser.GetSmallDepartmentsByUserIdOutput(userId);

        //    if (data == null)
        //        return NotFound();

        //    //var dto = _mapper.Map<UserDtoDetail>(data);
        //    return StatusCode(200, data);

        //}

        //[HttpPost("GetUserWithDepartments/{userId}")]
        //public IActionResult GetUserWithDepartments(string userId)
        //{
        //    var data = _appUser.GetUserWithDepartments(userId);

        //    if (data == null)
        //        return NotFound();
        //    return StatusCode(200, data);
        //}

        //[HttpGet("GetUserBasicData")]
        //public IActionResult GetUserBasicData()
        //{
        //    var data = _appUser.GetAllUsersBasicData();

        //    if (data == null)
        //        return NotFound();
        //    return StatusCode(200, data);
        //}

        //[HttpGet("GetAllUsersByNatId/{natId}")]
        //public async Task<IActionResult> GetAllUsersByNatId(string natId)
        //{
        //    var data = _appUser.GetAllUserssByNatId(natId);
        //    if (data == null)
        //        return NotFound();
        //    return StatusCode(200, data);
        //}



    }
}

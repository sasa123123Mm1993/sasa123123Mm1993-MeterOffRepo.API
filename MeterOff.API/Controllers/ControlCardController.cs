using Asp.Versioning;
using AutoMapper;
using Humanizer;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Dto.ControlCard;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.Core.Models.Static;
using MeterOff.EF.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.Protocols;

namespace MeterOff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/api/[Controller]/[action]")]
    public class ControlCardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IControlCard _ControlCard;
        private readonly ITestRegister _testRegisterService;
        public ControlCardController(IMapper mapper, IControlCard controlCard, ITestRegister testRegisterService)
        {
            _mapper = mapper;
            _ControlCard = controlCard;
            _testRegisterService = testRegisterService;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public  IActionResult GetAll()
        {
               var result = _ControlCard.GetAll();
                return Ok(result);
        }

        [HttpGet("GetAllTampers")]
        public IActionResult GetAllTampers()
        {
                var data = _ControlCard.GetAllTempers();
                return Ok(data);
        }



        [HttpGet("GetAllTechinicions")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAllTechinicions(int? RegionId, string? filter, int? cardFunctionId)
        {
            
                var data = _ControlCard.GetAllTecnicions(RegionId, filter, cardFunctionId);
                return Ok(data);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> InsertControlCard(InsertControlCardInput dto)
        {
                var data = _ControlCard.AddContolCard(dto);
                return Ok(data);
        }

        [HttpGet("GetTechinicianExpirationDate")]
        public IActionResult GetTechinicianExpirationDate()
        {
                var data = _ControlCard.GetTechinicianExpirationDate();
                return Ok(data);

        }

        [HttpGet("GetTechinicianActivationDate")]
        public IActionResult GetTechinicianActivationDate()
        {
           
                var data = _ControlCard.GetTechinicianActivationDate();
                return Ok(data);
           

        }

        [HttpPost("CancelControlCard")]
        public async Task<IActionResult> CancelControlCard(string controlCardId)
        {
            var result = _ControlCard.CancelControlCard(controlCardId);
            return StatusCode(200, result);
        }


        
    }
}

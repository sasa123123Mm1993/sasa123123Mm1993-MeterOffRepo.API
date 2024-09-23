using Asp.Versioning;
using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.Auth;
using MeterOff.Core.Models.Dto.ControlCard;
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _ControlCard.GetAll();
                
                return StatusCode(200, data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

        [HttpGet("GetAllTampers")]
        public async Task<IActionResult> GetAllTampers()
        {
            try
            {
                var data =  _ControlCard.GetAllTempers();

                return StatusCode(200, data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }



        [HttpGet("GetAllTechinicions")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAllTechinicions(int? RegionId, string? filter, int? cardFunctionId)
        {
            var model = _ControlCard.GetAllTecnicions(RegionId, filter, cardFunctionId);
            return StatusCode(200, model);

        }


        [HttpPost("Create")]
        public async Task<IActionResult> InsertControlCard(InsertControlCardInput dto)
        {
            //var data = _mapper.Map<InsertControlCardInput>(dto);
           var result =  _ControlCard.AddContolCard(dto);
           return StatusCode(200, result);
        }

        [HttpGet("GetTechinicianExpirationDate")]
        public IActionResult GetTechinicianExpirationDate()
        {
            var model = _ControlCard.GetTechinicianExpirationDate();
            return StatusCode(200, model);

        }

        [HttpGet("GetTechinicianActivationDate")]
        public IActionResult GetTechinicianActivationDate()
        {
            var model = _ControlCard.GetTechinicianActivationDate();
            return StatusCode(200, model);

        }






        [HttpPost("CancelControlCard")]
        public async Task<IActionResult> CancelControlCard(string controlCardId)
        {
            var result = _ControlCard.CancelControlCard(controlCardId);
            return StatusCode(200, result);
        }


        
    }
}

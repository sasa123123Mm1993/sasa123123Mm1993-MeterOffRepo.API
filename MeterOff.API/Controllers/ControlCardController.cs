using Asp.Versioning;
using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.ControlCard;
using MeterOff.Core.Models.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ControlCardController(IMapper mapper, IControlCard controlCard)
        {
            _mapper = mapper;
            _ControlCard = controlCard;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAll()
        {
            var model = _ControlCard.GetAll();
            //var data = _mapper.Map<IEnumerable<ControlCardOutput>>(model);
            return StatusCode(200, model);
        }

        [HttpGet("GetAllTechinicions")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAllTechinicions(int? RegionId, string? filter, int? cardFunctionId)
        {
            var model = _ControlCard.GetAllTecnicions(RegionId, filter, cardFunctionId);
            return StatusCode(200, model);

        }


        [HttpPost]
        public async Task<IActionResult> InsertControlCard(InsertControlCardInput dto)
        {
            //var data = _mapper.Map<InsertControlCardInput>(dto);
           var result =  _ControlCard.AddContolCard(dto);
            return StatusCode(200, result);
        }



    }
}

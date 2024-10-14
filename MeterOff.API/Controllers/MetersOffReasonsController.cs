using Asp.Versioning;
using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using Humanizer;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.MeterOffReasons;
using MeterOff.Core.Models.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeterOff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/api/[Controller]/[action]")]
    public class MetersOffReasonsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMeterOffReasonsRepository _meterOffReasonsRepository;
        public MetersOffReasonsController(IUnitOfWork unitOfWork, IMapper mapper,
            IMeterOffReasonsRepository meterOffReasonsRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _meterOffReasonsRepository = meterOffReasonsRepository;
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
                var result = _meterOffReasonsRepository.GetAll();
                return Ok(result);
        }




        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
                var result = _meterOffReasonsRepository.GetById(id);
                return Ok(result);
        }



        [HttpGet("GetDataByCustomerCode")]
        public async Task<IActionResult> GetDataByCustomerCode(int code)
        {
                var result = _meterOffReasonsRepository.GetByCode(code);
                return Ok(result);
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create(CUploadMainteneceMetersOffReason dto)
        {
            //var model = _mapper.Map<CUploadMainteneceMetersOffReason>(dto);
                var result = _meterOffReasonsRepository.Add(dto);
                return Ok(result);
          
        }



        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, CUploadMainteneceMetersOffReason dto)
        {
           
                var result = _meterOffReasonsRepository.Update(id,dto);
                return Ok(result);
           

        }




        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
                var result = _meterOffReasonsRepository.Delete(id);
                return Ok(result);
            

        }

    }
}

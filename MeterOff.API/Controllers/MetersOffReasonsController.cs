using Asp.Versioning;
using AutoMapper;
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
            //var data = _mapper.Map<IEnumerable<UploadMeterOffReasonDetails>>(result);
            return StatusCode(200, result);
        }




        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _meterOffReasonsRepository.GetById(id);

            if (model == null)
                return NotFound();

            var dto = _mapper.Map<UploadMeterOffReasonsOutput>(model);

            return StatusCode(200, dto);
        }



        [HttpGet("GetDataByCustomerCode")]
        public async Task<IActionResult> GetDataByCustomerCode(int code)
        {
            var model = await _meterOffReasonsRepository.GetByCode(code);
            //var data = _mapper.Map<IEnumerable<UploadMeterOffReasonsOutput>>(model);

            return StatusCode(200, model);
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create(InsertCUploadMainteneceMetersOffReasonInput dto)
        {
            //var model = _mapper.Map<CUploadMainteneceMetersOffReason>(dto);
            var result = _meterOffReasonsRepository.ValidateAddReason(dto);
            if (result == true)
            {
                var model = new CUploadMainteneceMetersOffReason
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    Note = "Test",
                    CreationTime = DateTime.Now,
                    CreatorById = 1,
                    IsDeleted = false,
                    ModificationTime = DateTime.Now,
                    ModifiedById = 1

                };

                _meterOffReasonsRepository.Add(model);
                return StatusCode(200, dto);
            }
            return BadRequest();
        }



        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, InsertCUploadMainteneceMetersOffReasonInput dto)
        {
            var result = _meterOffReasonsRepository.ValidateAddReason(dto);
            if (result == true)
            {
                var model = await _meterOffReasonsRepository.GetById(id);

                if (model == null)
                    return NotFound($"No Data was found with ID {id}");
                model.Code = dto.Code;
                model.Name = dto.Name;
                model.Note = "Test";
                model.CreationTime = DateTime.Now;
                model.CreatorById = 1;
                model.IsDeleted = false;
                model.ModificationTime = DateTime.Now;
                model.ModifiedById = 1;

                _meterOffReasonsRepository.Update(model);

                return StatusCode(200, model);
            }

            return BadRequest();
        }




        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _meterOffReasonsRepository.GetById(id);

            if (model == null)
                return NotFound($"No Data was found with ID {id}");

            _meterOffReasonsRepository.Delete(model);

            return StatusCode(200, model);
        }

    }
}

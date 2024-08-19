using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace MeterOff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/api/[Controller]/[action]")]

    public class CMaintenenceMetersOffController : ControllerBase
    {
        //ctor
        private readonly IMapper _mapper;
        private readonly ICMaintenenceMetersOff _CMaintenenceMetersOff;
        private readonly IMeterOffReasonsRepository _meterOffReasonsRepository;

        public CMaintenenceMetersOffController(ICMaintenenceMetersOff iCMaintenenceMetersOff, IMapper mapper,
            IMeterOffReasonsRepository meterOffReasonsRepository)
        {
            _CMaintenenceMetersOff = iCMaintenenceMetersOff;
            _mapper = mapper;
            _meterOffReasonsRepository = meterOffReasonsRepository;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetAll()
        {

            var MaintenenceMeters = _CMaintenenceMetersOff.GetAll();
            var data = _mapper.Map<IEnumerable<CMaintenenceMetersOffOutput>>(MaintenenceMeters);
            return StatusCode(200, MaintenenceMeters);

        }

        [HttpGet("GetMaintainceMeterById")]
        public async Task<IActionResult> GetMaintainceMeterById(int id)
        {
            var data = _CMaintenenceMetersOff.GetByIdDtoModel(id);
            if (data == null)
                return NotFound();

            var dto = _mapper.Map<CMaintenenceMetersOffOutput>(data);

            return Ok(dto);
        }




        [HttpGet("GetTableData")]
        public async Task<IActionResult> GetTableData(int id)
        {
            var data = _CMaintenenceMetersOff.GetByIdTableData(id);

            if (data == null)
                return NotFound();

            var dto = _mapper.Map<CMaintenenceMetersOff>(data);

            return Ok(dto);
        }



        [HttpPost]
        public async Task<IActionResult> Create(InsertCMaintenenceMetersOffInput dto)
        {
            var result = _meterOffReasonsRepository.validateInsertCMaintenenceMetersOff(dto);
            if (result == true)
            {
                var CMaintenenceMetersOff = _meterOffReasonsRepository.IsvalidCUploadMainteneceMetersOffReason(dto.CUploadMainteneceMetersOffReasonId);

                if (!CMaintenenceMetersOff)
                    return BadRequest("Invalid Upload Reason ID!");
                //var mm = new CMaintenenceMetersOff {
                //    AccountNo = dto.AccountNo ,
                //    ActivityTypeId = dto.ActivityTypeId ,
                //    Address = dto.Address ,
                //    BranchNo= dto.BranchNo ,
                //    CreationTime = dto.CreationTime,
                //     CreatorById = dto.CreatorById ,
                //     CUploadMainteneceMetersOffReasonId = dto.CUploadMainteneceMetersOffReasonId,
                //     CustomerCode = dto.CustomerCode ,
                //     DailyNo = dto.DailyNo ,
                //     DeliveryDateToLaboratory = dto.DeliveryDateToLaboratory ,
                //       ExaminationDate = dto.ExaminationDate ,
                //       MeterOffDate = dto.MeterOffDate ,
                //       IsDeleted= dto.IsDeleted,
                //       ExaminationNumber = dto.ExaminationNumber ,
                //       IsExaminationdata = dto.IsExaminationdata ,
                //       MainDepartmentId = dto.MainDepartmentId ,
                //       MeterInstallationDate = dto.MeterInstallationDate ,
                //       MeterOffMaintainNote = dto.MeterOffMaintainNote ,
                //        MeterOffStatusId = dto.MeterOffStatusId ,
                //        MeterPreparedDate = dto.MeterPreparedDate ,
                //        MeterTypeId = dto.MeterTypeId ,
                //        ModificationTime = dto.ModificationTime ,
                //        ModifiedById = dto.ModifiedById ,
                //        NationalId = dto.NationalId ,
                //         Name = dto.Name ,
                //         SectionId = dto.SectionId ,
                //         PlaceTypeId= dto.PlaceTypeId ,
                //         MeterOffReason = dto.MeterOffReason ,
                //         RegionNo = dto.RegionNo ,
                //         SerialNumber = dto.SerialNumber ,
                //         VendorCode = dto.VendorCode ,
                //          UploadDate = dto.UploadDate,
                //          SmallDepartmentId= dto.SmallDepartmentId 


                //};
                var data = _mapper.Map<CMaintenenceMetersOff>(dto);
                _CMaintenenceMetersOff.Add(data);
                return Ok(data);
            }
            else return BadRequest();
        }



        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id, InsertCMaintenenceMetersOffInput dto)
        {
            var result = _meterOffReasonsRepository.validateInsertCMaintenenceMetersOff(dto);
            if (result == true)
            {
                var model = _CMaintenenceMetersOff.GetByIdTableData(id);

                if (model == null)
                    return NotFound($"No data was found with ID {id}");


                var CMaintenenceMetersOff = _meterOffReasonsRepository.IsvalidCUploadMainteneceMetersOffReason(dto.CUploadMainteneceMetersOffReasonId);

                if (!CMaintenenceMetersOff)
                    return BadRequest("Invalid Upload Reason ID!");



                //edit here
                var data = _mapper.Map<CMaintenenceMetersOff>(dto);
                _CMaintenenceMetersOff.Update(data);

                return Ok(model);
            }

            else return BadRequest();
        }



        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _CMaintenenceMetersOff.GetByIdTableData(id);

            if (model == null)
                return NotFound($"No data was found with ID {id}");

            _CMaintenenceMetersOff.Delete(model);

            return Ok(model);
        }
        [HttpGet]

        public IActionResult GetAllSections()
        {
            var Sections = _CMaintenenceMetersOff.GetAllSections();
            var data = _mapper.Map<IEnumerable<Core.Models.Section>>(Sections);
            return StatusCode(200, data);

        }

        [HttpGet("GetAllMainDepartments")]
        public IActionResult GetAllMainDepartments()
        {
            var mainDepartments = _CMaintenenceMetersOff.GetAllMainDepartments();
            var data = _mapper.Map<IEnumerable<MainDepartment>>(mainDepartments);
            return StatusCode(200, data);

        }

        [HttpGet("GetAllSmallDepartments")]
        public IActionResult GetAllSmallDepartments()
        {

            var smallDepartments = _CMaintenenceMetersOff.GetAllSmallDepartments();
            var data = _mapper.Map<IEnumerable<SmallDepartment>>(smallDepartments);
            return StatusCode(200, data);

        }

        [HttpGet("GetAllActivityTypes")]
        public IActionResult GetAllActivityTypes()
        {

            var activityTypes = _CMaintenenceMetersOff.GetAllActivityTypes();
            var data = _mapper.Map<IEnumerable<ActivityType>>(activityTypes);
            return StatusCode(200, data);

        }

        [HttpGet("GetAllPlaceTypes")]
        public IActionResult GetAllPlaceTypes()
        {
            var placeTypes = _CMaintenenceMetersOff.GetAllPlaceTypes();
            var data = _mapper.Map<IEnumerable<PlaceType>>(placeTypes);
            return StatusCode(200, data);
        }

        [HttpGet("GetAllMeterTypes")]
        public IActionResult GetAllMeterTypes()
        {

            var meterType = _CMaintenenceMetersOff.GetAllMeterTypes();
            var data = _mapper.Map<IEnumerable<MeterType>>(meterType);
            return StatusCode(200, data);
        }

        [HttpGet("GetDataByRefAddress")]
        public IActionResult GetDataByRefAddress(int dailyNo, int regionNo, int accountNo, int branchNo)
        {
            var data = _CMaintenenceMetersOff.GetDataByRefAddress(dailyNo, regionNo, accountNo, branchNo);

            if (data == null)
                return NotFound();

            //var dto = _mapper.Map<CMaintenenceMetersOffOutput>(data);

            return Ok(data);
        }

        [HttpGet("GetAllPlaceTypesByActivityTypeId")]
        public IActionResult GetAllPlaceTypesByActivityTypeId(int ActivityTypeId)
        {

            var placeTypes = _CMaintenenceMetersOff.GetAllPlaceTypesByActivityTypeId(ActivityTypeId);
            var data = _mapper.Map<IEnumerable<PlaceType>>(placeTypes);
            return StatusCode(200, data);
        }

        [HttpGet("{MainDepId}")]
        public IActionResult GetAllSmallDepartmentsByMainDepId(int MainDepId)
        {

            var smallDep = _CMaintenenceMetersOff.GetAllSmallDepartmentsByMainDepId(MainDepId);
            var data = _mapper.Map<IEnumerable<SmallDepartmentDto>>(smallDep);
            return StatusCode(200, data);
        }

        [HttpGet("{SectionId}")]
        public IActionResult GetAllMainDepartmentsBySectionId(int SectionId)
        {
            var MainDeps = _CMaintenenceMetersOff.GetAllMainDepartmentsBySectionId(SectionId);
            var data = _mapper.Map<IEnumerable<MainDepartment>>(MainDeps);
            return StatusCode(200, data);
        }

        [HttpPost("{id}")]
        public IActionResult AddFixedMeterToTechinicion(FixedMeterToTechinitionInsert dto, int id)
        {
            var result = _meterOffReasonsRepository.ValidateAddFixedMeterToTechinicion(dto);
            if (result == false)
            {
                var model = _CMaintenenceMetersOff.GetByIdTableData(id);

                if (model == null)
                    return NotFound($"No data was found with ID {id}");

                model.MeterInstallationDate = dto.InstallationDate;
                model.DeliveryDateToTechnician = dto.DeliveryDateToTechnician;
                model.MaintenanceDate = dto.MaintenanceDate;
                var data = _mapper.Map<CMaintenenceMetersOff>(model);

                _CMaintenenceMetersOff.AddFixedMeterToTechinition(data);

                return StatusCode(200, data);
            }
            return BadRequest("لم تتم عملية الاضافة بنجاح");

        }

    }
}

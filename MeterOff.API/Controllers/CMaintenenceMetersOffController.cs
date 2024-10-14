using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http.HttpResults;

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
                //var data = _mapper.Map<IEnumerable<CMaintenenceMetersOffOutput>>(MaintenenceMeters);
                return Ok(MaintenenceMeters);
            

        }

        [HttpGet("GetMaintainceMeterById/{id}")]
        public async Task<IActionResult> GetMaintainceMeterById(int id)
        {
            
            
                var data = _CMaintenenceMetersOff.GetByIdDtoModel(id);
                //var dto = _mapper.Map<CMaintenenceMetersOffOutput>(data);
                return Ok(data);
           
        }




        [HttpGet("GetTableData")]
        public async Task<IActionResult> GetTableData(int id)
        {
            
                var data = _CMaintenenceMetersOff.GetByIdTableData(id);
                return Ok(data);
          
        }



        [HttpPost("Create")]
        public  IActionResult Create(InsertCMaintenenceMetersOffInput dto)
        {

           
                var CMaintenenceMetersOff = _meterOffReasonsRepository.IsvalidCUploadMainteneceMetersOffReason(dto.CUploadMainteneceMetersOffReasonId);
                if (!CMaintenenceMetersOff)
                    return BadRequest("Invalid Upload Reason ID!");
                //var mm = new CMaintenenceMetersOff
                //{
                //    AccountNo = dto.AccountNo,
                //    ActivityTypeId = dto.ActivityTypeId,
                //    Address = dto.Address,
                //    BranchNo = dto.BranchNo,
                //    CreationTime = DateTime.Now,
                //    CreatorById = dto.CreatorById,
                //    CUploadMainteneceMetersOffReasonId = dto.CUploadMainteneceMetersOffReasonId,
                //    CustomerCode = dto.CustomerCode,
                //    DailyNo = dto.DailyNo,
                //    DeliveryDateToLaboratory = dto.DeliveryDateToLaboratory,
                //    ExaminationDate = dto.ExaminationDate,
                //    MeterOffDate = dto.MeterOffDate,
                //    IsDeleted = false,
                //    ExaminationNumber = dto.ExaminationNumber,
                //    IsExaminationdata = dto.IsExaminationdata,
                //    MainDepartmentId = dto.MainDepartmentId,
                //    MeterInstallationDate = dto.MeterInstallationDate,
                //    MeterOffMaintainNote = dto.MeterOffMaintainNote,
                //    MeterOffStatusId = dto.MeterOffStatusId,
                //    MeterPreparedDate = dto.MeterPreparedDate,
                //    MeterTypeId = dto.MeterTypeId,
                //    ModificationTime = dto.ModificationTime,
                //    ModifiedById = dto.ModifiedById,
                //    NationalId = dto.NationalId,
                //    CustomerName = dto.CustomerName,
                //    SectionId = dto.SectionId,
                //    PlaceTypeId = dto.PlaceTypeId,
                //    MeterOffReason = dto.MeterOffReason,
                //    RegionNo = dto.RegionNo,
                //    SerialNumber = dto.SerialNumber,
                //    VendorCode = dto.VendorCode,
                //    UploadDate = dto.UploadDate,
                //    SmallDepartmentId = dto.SmallDepartmentId,
                //    MainDepartmentCode = dto.MainDepartmentCode,
                //    SmallDepartmentCode = dto.SmallDepartmentCode,

                //};
                //var data = _mapper.Map<CMaintenenceMetersOff>(mm);
                var data = _CMaintenenceMetersOff.Add(dto);
                return Ok(data);
            

        }



        [HttpPost("Update/{id}")]
        public IActionResult Update(int id,InsertCMaintenenceMetersOffInput dto)
        {
           
                var model = _CMaintenenceMetersOff.GetByIdTableData(id);

                if (model == null)
                    return NotFound($"No data was found with ID {id}");


                var CMaintenenceMetersOff = _meterOffReasonsRepository.IsvalidCUploadMainteneceMetersOffReason(dto.CUploadMainteneceMetersOffReasonId);

                if (!CMaintenenceMetersOff)
                    return BadRequest("Invalid Upload Reason ID!");


                //model.AccountNo = dto.AccountNo;
                //model.ActivityTypeId = dto.ActivityTypeId;
                //model.Address = dto.Address;
                //model.BranchNo = dto.BranchNo;
                //model.CreationTime = dto.CreationTime;
                //model.CreatorById = dto.CreatorById;
                //model.CUploadMainteneceMetersOffReasonId = dto.CUploadMainteneceMetersOffReasonId;
                //model.CustomerCode = dto.CustomerCode;
                //model.DailyNo = dto.DailyNo;
                //model.DeliveryDateToLaboratory = dto.DeliveryDateToLaboratory;
                //model.ExaminationDate = dto.ExaminationDate;
                //model.MeterOffDate = dto.MeterOffDate;
                //model.IsDeleted = dto.IsDeleted;
                //model.ExaminationNumber = dto.ExaminationNumber;
                //model.IsExaminationdata = dto.IsExaminationdata;
                //model.MainDepartmentId = dto.MainDepartmentId;
                //model.MeterInstallationDate = dto.MeterInstallationDate;
                //model.MeterOffMaintainNote = dto.MeterOffMaintainNote;
                //model.MeterOffStatusId = dto.MeterOffStatusId;
                //model.MeterPreparedDate = dto.MeterPreparedDate;
                //model.MeterTypeId = dto.MeterTypeId;
                //model.ModificationTime = dto.ModificationTime;
                //model.ModifiedById = dto.ModifiedById;
                //model.NationalId = dto.NationalId;
                //model.CustomerName = dto.CustomerName;
                //model.SectionId = dto.SectionId;
                //model.PlaceTypeId = dto.PlaceTypeId;
                //model.MeterOffReason = dto.MeterOffReason;
                //model.RegionNo = dto.RegionNo;
                //model.SerialNumber = dto.SerialNumber;
                //model.VendorCode = dto.VendorCode;
                //model.UploadDate = dto.UploadDate;
                //model.SmallDepartmentId = dto.SmallDepartmentId;
                //model.MainDepartmentCode = dto.MainDepartmentCode;
                //model.SmallDepartmentCode = dto.SmallDepartmentCode;


                _CMaintenenceMetersOff.Update(id,dto);

                return Ok(model);
           
   
        }



        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
           
             var model = _CMaintenenceMetersOff.Delete(id);
                return Ok(model);
           
        }

        [HttpGet("GetAllSections")]
        public IActionResult GetAllSections()
        {
            
                var model = _CMaintenenceMetersOff.GetAllSections();
                return Ok(model);
           

        }

        [HttpGet("GetAllMainDepartments")]
        public IActionResult GetAllMainDepartments()
        {
            
                var model = _CMaintenenceMetersOff.GetAllMainDepartments();
                return Ok(model);
            
        }

        [HttpGet("GetAllSmallDepartments")]
        public IActionResult GetAllSmallDepartments()
        {

            
                var model = _CMaintenenceMetersOff.GetAllSmallDepartments();
                return Ok(model);
           

        }

        [HttpGet("GetAllActivityTypes")]
        public IActionResult GetAllActivityTypes()
        {

            
                var model = _CMaintenenceMetersOff.GetAllActivityTypes();
                return Ok(model);
           

        }

        [HttpGet("GetAllPlaceTypes")]
        public IActionResult GetAllPlaceTypes()
        {
            
                var model = _CMaintenenceMetersOff.GetAllPlaceTypes();
                return Ok(model);
           
        }

        [HttpGet("GetAllMeterTypes")]
        public IActionResult GetAllMeterTypes()
        {

                var model = _CMaintenenceMetersOff.GetAllMeterTypes();
                return Ok(model);
            
        }

        [HttpGet("GetDataByRefAddress")]
        public IActionResult GetDataByRefAddress(int dailyNo, int regionNo, int accountNo, int branchNo)
        {
            
                var model = _CMaintenenceMetersOff.GetDataByRefAddress(dailyNo, regionNo, accountNo, branchNo);
                return Ok(model);
            
        }

        [HttpGet("GetAllPlaceTypesByActivityTypeId/{ActivityTypeId}")]
        public IActionResult GetAllPlaceTypesByActivityTypeId(int ActivityTypeId)
        {
           
                var placeTypes = _CMaintenenceMetersOff.GetAllPlaceTypesByActivityTypeId(ActivityTypeId);
                //var data = _mapper.Map<IEnumerable<PlaceType>>(placeTypes);
                return Ok(placeTypes);
            
        }

        [HttpGet("GetAllSmallDepartmentsByMainDepId/{MainDepId}")]
        public IActionResult GetAllSmallDepartmentsByMainDepId(int MainDepId)
        {
           
                var smallDep = _CMaintenenceMetersOff.GetAllSmallDepartmentsByMainDepId(MainDepId);
                //var data = _mapper.Map<IEnumerable<SmallDepartmentDto>>(smallDep);
                return Ok(smallDep);
           
        }

        [HttpGet("GetAllMainDepartmentsBySectionId/{SectionId}")]
        public IActionResult GetAllMainDepartmentsBySectionId(int SectionId)
        {
           
                var MainDeps = _CMaintenenceMetersOff.GetAllMainDepartmentsBySectionId(SectionId);
                //var data = _mapper.Map<IEnumerable<MainDepartment>>(MainDeps);
                return Ok(MainDeps);
            
           
        }

  
        [HttpPost("AddFixedMeterToTechinicion/{id}")]
        public IActionResult AddFixedMeterToTechinicion(int id, FixedMeterToTechinitionInsert dto)
        {
                var model = _CMaintenenceMetersOff.AddFixedMeterToTechinition(id, dto);
                return Ok(model);
        }
    }
}

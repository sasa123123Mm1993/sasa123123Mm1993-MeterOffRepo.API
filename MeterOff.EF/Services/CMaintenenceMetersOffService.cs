using MeterOff.Core.Models;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Enum;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class CMaintenenceMetersOffService : ICMaintenenceMetersOff
    {
        private readonly DBContext _context;
        public CMaintenenceMetersOffService(DBContext context)
        {
            _context = context;
        }

        public CMaintenenceMetersOff Add(CMaintenenceMetersOff model)
        {
            _context.AddAsync(model);
            _context.SaveChanges();
            return model;

        }

        public CMaintenenceMetersOff Delete(CMaintenenceMetersOff model)
        {
            _context.Remove(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<CMaintenenceMetersOffOutput> GetAll()
        {
            var meterStatus = new MeterStatusEnum();
            string value;
            var model = _context.CMaintenenceMetersOff
                 //.Include(m => m.UploadMainteneceMetersOffReason)
                 .Select(k => new CMaintenenceMetersOffOutput
                 {
                     AccountNo = k.AccountNo,
                     ActivityName = k.activityType.Name,
                     CustomerName = k.CustomerName,
                     Address = k.Address,
                     BranchNo = k.BranchNo,
                     CustomerCode = k.CustomerCode,
                     DailyNo = k.DailyNo,
                     DeliveryDateToLaboratory = k.DeliveryDateToLaboratory,
                     ExaminationDate = k.ExaminationDate,
                     ExaminationNumber = k.ExaminationNumber,
                     Id = k.Id,
                     IsExaminationdata = k.IsExaminationdata,
                     MainDepartmentName = k.mainDepartment.Name,
                     MeterInstallationDate = k.MeterInstallationDate,
                     MeterOffDate = k.MeterOffDate,
                     MeterOffMaintainNote = k.MeterOffMaintainNote,
                     MeterOffReason = k.MeterOffReason,
                     MeterOffStatus = "1",
                     MeterPreparedDate = k.MeterPreparedDate,
                     MeterTypeId = k.meterType.Id,
                     PlaceTypeName = k.placeType.Name,
                     SectionName = k.section.Name,
                     UploadReason = k.UploadMainteneceMetersOffReason.Name,
                     SmallDepartmentName = k.smallDepartment.Name,
                     SerialNumber = k.SerialNumber,
                     VendorCode = k.VendorCode,
                     NationalId = k.NationalId,
                     RegionNo = k.RegionNo,
                     UploadDate = k.UploadDate,
                     MainDepartmentCode = k.MainDepartmentCode,
                     SmallDepartmentCode = k.SmallDepartmentCode,
                     IsMeterRecieved = k.IsMeterRecieved,
                     cUploadMainteneceMetersOffReasonId = k.CUploadMainteneceMetersOffReasonId,
                     SmallDepartmentId = k.SmallDepartmentId,
                     SectionId = k.section.Id,
                     ActivityTypeId = k.activityType.Id,
                     MainDepartmentId = k.mainDepartment.Id,
                     meterOffStatusId = k.MeterOffStatusId,
                     PlaceTypeId = k.placeType.Id,
                     IsEnded = k.IsEnded,
                     IsMeterInstalled = k.IsMeterInstalled,
                     MaintenanceDate = k.MaintenanceDate




                 })
               .OrderByDescending(c => c.Id).ToList();
            return model;


            //return await _context.CMaintenenceMetersOff
            //   .Where(m => m.UploadReasonId == uploadReasonId || uploadReasonId == 0)
            //   .OrderByDescending(m => m.Id)
            //   .Include(m => m.UploadMainteneceMetersOffReason)
            //   .ToListAsync();
        }

        public IEnumerable<ActivityType> GetAllActivityTypes()
        {
            var result = _context.ActivityType.ToList();
            return result;
        }

        public IEnumerable<MainDepartment> GetAllMainDepartments()
        {
            var result = _context.MainDepartment.ToList();
            return result;
        }

        public IEnumerable<MainDepartment> GetAllMainDepartmentsBySectionId(int sectionId)
        {
            var model = _context.MainDepartment
               .Where(m => m.sectionId == sectionId).ToList();
            return model;
        }


        public IEnumerable<CMaintenenceMetersOffOutput> GetDataByRefAddress(int dailyNo, int regionNo, int accountNo, int branchNo)
        {
            var model = _context.CMaintenenceMetersOff
                .Where(m => m.DailyNo == dailyNo && m.RegionNo == regionNo && m.AccountNo == accountNo && m.BranchNo == branchNo).ToList()
                .Select(k => new CMaintenenceMetersOffOutput
                {
                    AccountNo = k.AccountNo,
                    ActivityName = k.activityType.Name,
                    CustomerName = k.CustomerName,
                    Address = k.Address,
                    BranchNo = k.BranchNo,
                    CustomerCode = k.CustomerCode,
                    DailyNo = k.DailyNo,
                    DeliveryDateToLaboratory = k.DeliveryDateToLaboratory,
                    ExaminationDate = k.ExaminationDate,
                    ExaminationNumber = k.ExaminationNumber,
                    Id = k.Id,
                    IsExaminationdata = k.IsExaminationdata,
                    MainDepartmentName = k.mainDepartment.Name,
                    MeterInstallationDate = k.MeterInstallationDate,
                    MeterOffDate = k.MeterOffDate,
                    MeterOffMaintainNote = k.MeterOffMaintainNote,
                    MeterOffReason = k.MeterOffReason,
                    MeterOffStatus = "1",
                    MeterPreparedDate = k.MeterPreparedDate,
                    MeterTypeId = k.meterType.Id,
                    PlaceTypeName = k.placeType.Name,
                    SectionName = k.section.Name,
                    UploadReason = k.UploadMainteneceMetersOffReason.Name,
                    SmallDepartmentName = k.smallDepartment.Name,
                    SerialNumber = k.SerialNumber,
                    VendorCode = k.VendorCode,
                    NationalId = k.NationalId,
                    RegionNo = k.RegionNo,
                    UploadDate = k.UploadDate,
                    MainDepartmentCode = k.MainDepartmentCode,
                    SmallDepartmentCode = k.SmallDepartmentCode,
                    IsMeterRecieved = k.IsMeterRecieved,
                    ActivityTypeId = k.activityType.Id,
                    cUploadMainteneceMetersOffReasonId = k.CUploadMainteneceMetersOffReasonId,
                    MainDepartmentId = k.MainDepartmentId,
                    meterOffStatusId = k.MeterOffStatusId,
                    PlaceTypeId = k.placeType.Id,
                    SectionId = k.section.Id,
                    SmallDepartmentId = k.smallDepartment.Id,
                    IsEnded = k.IsEnded,
                    IsMeterInstalled = k.IsMeterInstalled,
                    MaintenanceDate = k.MaintenanceDate



                })
              .OrderByDescending(c => c.Id).ToList();
            return model;
        }

        public IEnumerable<MeterType> GetAllMeterTypes()
        {
            var result = _context.MeterType.ToList();
            return result;
        }

        public IEnumerable<PlaceType> GetAllPlaceTypes()
        {
            var result = _context.PlaceType.ToList();
            return result;
        }

        public IEnumerable<PlaceType> GetAllPlaceTypesByActivityTypeId(int ActivityTypeId)
        {
            var model = _context.PlaceType
              .Where(m => m.TariffTypeId == ActivityTypeId).ToList();
            return model;
        }

        public IEnumerable<Section> GetAllSections()
        {
            var result = _context.Section.ToList();
            return result;
        }

        public IEnumerable<SmallDepartmentDto> GetAllSmallDepartments()
        {
            var smallDep = _context.SmallDepartment
                .Select(m => new SmallDepartmentDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    AccountReferenceCounter = m.AccountReferenceCounter,
                    CodeAutoGenerated = m.CodeAutoGenerated,
                    MainDepartmentId = m.MainDepartmentId,
                    RegionCode = m.RegionCode,
                    SectionId = m.SectionId,
                    SouthCairoCode = m.SouthCairoCode
                })
                .ToList();
            return smallDep;
        }

        public IEnumerable<SmallDepartment> GetAllSmallDepartmentsByMainDepId(int MainDepId)
        {
            var model = _context.SmallDepartment
             .Where(m => m.MainDepartmentId == MainDepId).ToList();
            return model;
        }
        public CMaintenenceMetersOffOutput GetByIdDtoModel(int id)
        {
            var model = _context.CMaintenenceMetersOff
                //.Include(m => m.UploadMainteneceMetersOffReason)
                .Select(k => new CMaintenenceMetersOffOutput
                {
                    AccountNo = k.AccountNo,
                    ActivityName = k.activityType.Name,
                    CustomerName = k.CustomerName,
                    Address = k.Address,
                    BranchNo = k.BranchNo,
                    CustomerCode = k.CustomerCode,
                    DailyNo = k.DailyNo,
                    DeliveryDateToLaboratory = k.DeliveryDateToLaboratory,
                    ExaminationDate = k.ExaminationDate,
                    ExaminationNumber = k.ExaminationNumber,
                    Id = k.Id,
                    IsExaminationdata = k.IsExaminationdata,
                    MainDepartmentName = k.mainDepartment.Name,
                    MeterInstallationDate = k.MeterInstallationDate,
                    MeterOffDate = k.MeterOffDate,
                    MeterOffMaintainNote = k.MeterOffMaintainNote,
                    MeterOffReason = k.MeterOffReason,
                    MeterOffStatus = "1",
                    MeterPreparedDate = k.MeterPreparedDate,
                    MeterTypeId = k.meterType.Id,
                    PlaceTypeName = k.placeType.Name,
                    SectionName = k.section.Name,
                    UploadReason = k.UploadMainteneceMetersOffReason.Name,
                    SmallDepartmentName = k.smallDepartment.Name,
                    SerialNumber = k.SerialNumber,
                    VendorCode = k.VendorCode,
                    NationalId = k.NationalId,
                    RegionNo = k.RegionNo,
                    UploadDate = k.UploadDate,
                    MainDepartmentCode = k.MainDepartmentCode,
                    SmallDepartmentCode = k.SmallDepartmentCode,
                    ActivityTypeId = k.activityType.Id,
                    MainDepartmentId = k.mainDepartment.Id,
                    SmallDepartmentId = k.smallDepartment.Id,
                    PlaceTypeId = k.placeType.Id,
                    SectionId = k.section.Id,
                    cUploadMainteneceMetersOffReasonId = k.CUploadMainteneceMetersOffReasonId,
                    meterOffStatusId = k.MeterOffStatusId,
                    IsMeterRecieved = k.IsMeterRecieved,
                    IsEnded = k.IsEnded,
                    IsMeterInstalled = k.IsMeterInstalled,
                    MaintenanceDate = k.MaintenanceDate


                })
                .SingleOrDefault(m => m.Id == id);
            return model;
        }

        public CMaintenenceMetersOff GetByIdTableData(int id)
        {
            var model = _context.CMaintenenceMetersOff
                .SingleOrDefault(m => m.Id == id);
            return model;
        }
        public CMaintenenceMetersOff Update(CMaintenenceMetersOff model)
        {
            _context.Update(model);
            _context.SaveChanges();

            return model;
        }

        public CMaintenenceMetersOff AddFixedMeterToTechinition(CMaintenenceMetersOff model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }


    }
}

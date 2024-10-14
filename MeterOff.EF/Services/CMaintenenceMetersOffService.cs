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
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Base_Response.Providers;
using MeterOff.Core.Models.Dto.CardFunctionDto;
using static System.Collections.Specialized.BitVector32;
using System.Security.AccessControl;
using MeterOff.Core.Models.Dto.MeterOffReasons;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Humanizer;
using Section = MeterOff.Core.Models.Section;
using System.Data.Entity;

namespace MeterOff.EF.Services
{
    public class CMaintenenceMetersOffService : ICMaintenenceMetersOff
    {
        private readonly DBContext _context;
        public CMaintenenceMetersOffService(DBContext context)
        {
            _context = context;
        }

        public Response<CMaintenenceMetersOff> Add(InsertCMaintenenceMetersOffInput model)
        {

            Response<CMaintenenceMetersOff> response = new Response<CMaintenenceMetersOff>();
            try
            {
                var resultOfValidation = validateInsertCMaintenenceMetersOff(model);
                if (resultOfValidation) { }
                var data = new CMaintenenceMetersOff
                {

                    CreationTime = DateTime.Now,
                    CreatorById = 1,
                    IsDeleted = false,
                    AccountNo = model.AccountNo,
                    MeterOffStatusId = model.MeterOffStatusId,
                    MeterOffReason = model.MeterOffReason,
                    MeterInstallationDate = DateTime.Now,
                    MainDepartmentCode = model.MainDepartmentCode,
                    MainDepartmentId = model.MainDepartmentId,
                    ActivityTypeId = model.ActivityTypeId,
                    Address = model.Address,
                    BranchNo = model.BranchNo,
                    CUploadMainteneceMetersOffReasonId = model.CUploadMainteneceMetersOffReasonId,
                    CustomerCode = model.CustomerCode,
                    CustomerName = model.CustomerName,
                    DailyNo = model.DailyNo,
                    VendorCode = model.VendorCode,
                    SmallDepartmentId = model.SmallDepartmentId,
                    ExaminationDate = model.ExaminationDate,
                    DeliveryDateToLaboratory = model.DeliveryDateToLaboratory,
                    DeliveryDateToTechnician = model.DeliveryDateToLaboratory,
                    ExaminationNumber = model.ExaminationNumber,
                    IsEnded = false,
                    IsMeterInstalled = false,
                    IsMeterRecieved = false,
                    MaintenanceDate = DateTime.Now,
                    MeterTypeId = model.MeterTypeId,
                    NationalId = model.NationalId,
                    PlaceTypeId = model.PlaceTypeId,
                    SmallDepartmentCode = model.SmallDepartmentCode,
                    SerialNumber = model.SerialNumber,
                    SectionId = model.SectionId,
                    MeterOffMaintainNote = model.MeterOffMaintainNote,

                };
                var result = _context.AddAsync(data);
                var ISSaved = Save() > 0;
                if (ISSaved)
                {
                    response.code = Added.Code;
                    response.payload = data;
                    response.status = Added.Status;
                    response.message = Added.messageAr;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

        }

        public Response<bool> Delete(int id)
        {

            Response<bool> response = new Response<bool>();
            try
            {
                var model = _context.CMaintenenceMetersOff.FirstOrDefault(r => r.IsDeleted != true && r.Id == id);
                if (model == null)
                {
                    response.code = Empty.Code;
                    response.message = "لا يوجد سبب لهذا العطل";
                    response.status = Empty.Status;
                    response.payload = false;
                    return response;
                }
                else
                {
                    model.IsDeleted = true;
                    _context.Update(model);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.code = DeleteSuccess.Code;
                        response.payload = ISSaved;
                        response.status = DeleteSuccess.Status;
                        response.message = DeleteSuccess.messageAr;
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = false;
                return response;
            }

            response.code = Failed.Code;
            response.message = "حدث خطا أثناء حذف معلومات العميل";
            response.status = Failed.Status;
            response.payload = false;
            return response;


            
        }

        public Response<List<CMaintenenceMetersOffOutput>> GetAll()
        {
            Response<List<CMaintenenceMetersOffOutput>> response = new Response<List<CMaintenenceMetersOffOutput>>();
            try
            {
                var model = _context.CMaintenenceMetersOff.AsNoTracking().Where(r => r.IsDeleted != true)
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
                      MaintenanceDate = k.MaintenanceDate,
                  })
               .OrderByDescending(c => c.Id).ToList();

                if (model != null && model.Any())
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (model == null || model.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;


            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

         

            //return await _context.CMaintenenceMetersOff
            //   .Where(m => m.UploadReasonId == uploadReasonId || uploadReasonId == 0)
            //   .OrderByDescending(m => m.Id)
            //   .Include(m => m.UploadMainteneceMetersOffReason)
            //   .ToListAsync();
        }

        public Response<List<ActivityType>> GetAllActivityTypes()
        {
            Response<List<ActivityType>> response = new Response<List<ActivityType>>();
            try
            {
                var activityType = _context.ActivityType.AsNoTracking().Where(r => r.IsDeleted != true)
                    .OrderByDescending(m=>m.Id)
                  .ToList();

                if (activityType != null && activityType.Any())
                {
                    response.payload = activityType;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                if (activityType == null || activityType.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }

        public Response<List<MainDepartment>> GetAllMainDepartments()
        {
            Response<List<MainDepartment>> response = new Response<List<MainDepartment>>();
            try
            {
                var mainDepartment = _context.MainDepartment.AsNoTracking().Where(r => r.IsDeleted != true)
                    .OrderByDescending(m => m.Id)
                  .ToList();

                if (mainDepartment != null && mainDepartment.Any())
                {
                    response.payload = mainDepartment;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                if (mainDepartment == null || mainDepartment.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }

        public Response<List<MainDepartment>> GetAllMainDepartmentsBySectionId(int sectionId)
        {
            Response<List<MainDepartment>> response = new Response<List<MainDepartment>>();
            try
            {
                var mainDepartment = _context.MainDepartment.AsNoTracking()
                    .Where(r => r.IsDeleted != true && r.sectionId == sectionId)
                    .OrderByDescending(m => m.Id)
                  .ToList();

                if (mainDepartment != null && mainDepartment.Any())
                {
                    response.payload = mainDepartment;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (mainDepartment == null || mainDepartment.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            
           
        }


        public Response<List<CMaintenenceMetersOffOutput>> GetDataByRefAddress(int dailyNo, int regionNo, int accountNo, int branchNo)
        {

            Response<List<CMaintenenceMetersOffOutput>> response = new Response<List<CMaintenenceMetersOffOutput>>();
            try
            {
                var model = _context.CMaintenenceMetersOff.AsNoTracking()
                .Where(m => m.DailyNo == dailyNo || m.RegionNo == regionNo || m.AccountNo == accountNo || m.BranchNo == branchNo
                && m.IsDeleted != true).ToList()
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

                if (model != null && model.Any())
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (model == null || model.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }

            catch (Exception ex)
            {
                response.code = Failed.Code;
                response.message = ex.Message;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
          
        }

        public Response<List<MeterType>> GetAllMeterTypes()
        {
            Response<List<MeterType>> response = new Response<List<MeterType>>();
            try
            {
                var meterType = _context.MeterType.AsNoTracking().Where(r => r.IsDeleted != true)
                    .OrderByDescending(m => m.Id)
                  .ToList();

                if (meterType != null && meterType.Any())
                {
                    response.payload = meterType;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (meterType == null || meterType.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
          
        }

        public Response<List<PlaceType>> GetAllPlaceTypes()
        {
            Response<List<PlaceType>> response = new Response<List<PlaceType>>();
            try
            {
                var placeType = _context.PlaceType.AsNoTracking().Where(r => r.IsDeleted != true)
                    .OrderByDescending(m => m.Id)
                  .ToList();

                if (placeType != null && placeType.Any())
                {
                    response.payload = placeType;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                if (placeType == null || placeType.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
          
        }

        public Response<List<PlaceType>> GetAllPlaceTypesByActivityTypeId(int ActivityTypeId)
        {
            

            Response<List<PlaceType>> response = new Response<List<PlaceType>>();
            try
            {
                var model = _context.PlaceType.AsNoTracking()
              .Where(m => m.TariffTypeId == ActivityTypeId && m.IsDeleted !=true)
              .OrderByDescending (m => m.Id)
              .ToList();

                if (model != null && model.Any())
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                if (model == null || model.Count ==0)
                {
                 
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
          
        }

        public Response<List<Section>> GetAllSections()
        {
            Response<List<Section>> response = new Response<List<Section>>();
            try
            {
                var model = _context.Section.AsNoTracking().Where(r => r.IsDeleted != true)
                    .OrderByDescending(m => m.Id)
                  .ToList();

                if (model != null && model.Any())
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (model == null || model.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }

        public Response<List<SmallDepartmentDto>> GetAllSmallDepartments()
        {
          
            Response<List<SmallDepartmentDto>> response = new Response<List<SmallDepartmentDto>>();
            try
            {
                var smallDep = _context.SmallDepartment
                    .AsNoTracking()
                 .Where(r => r.IsDeleted != true)
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
                .OrderByDescending(m => m.Id)
                .ToList();

                if (smallDep != null && smallDep.Any())
                {
                    response.payload = smallDep;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (smallDep == null || smallDep.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           

        }

        public Response<List<SmallDepartment>> GetAllSmallDepartmentsByMainDepId(int MainDepId)
        {
            
            Response<List<SmallDepartment>> response = new Response<List<SmallDepartment>>();
            try
            {
                var model = _context.SmallDepartment
                     .AsNoTracking()
                     .Where(m => m.MainDepartmentId == MainDepId && m.IsDeleted !=true)
                     .OrderByDescending(m => m.Id)
                     .ToList();

                if (model != null && model.Any())
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (model == null || model.Count == 0)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            
        }
        public Response<CMaintenenceMetersOffOutput> GetByIdDtoModel(int id)
        {
            Response<CMaintenenceMetersOffOutput> response = new Response<CMaintenenceMetersOffOutput>();
            try
            {
                var model = _context.CMaintenenceMetersOff
                .AsNoTracking()
                //.Include(m => m.UploadMainteneceMetersOffReason)
                .Where(m => m.IsDeleted != true && m.Id == id)
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
                .FirstOrDefault();


                if (model != null)
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                if (model == null)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;

            }

            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           

        }

        public Response<CMaintenenceMetersOff> GetByIdTableData(int id)
        {
          
            Response<CMaintenenceMetersOff> response = new Response<CMaintenenceMetersOff>();
            try
            {
                var model = _context.CMaintenenceMetersOff.AsNoTracking()
                .Where(m => m.IsDeleted != true && m.Id == id)
                .FirstOrDefault();


                if (model != null)
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }

                if (model == null)
                {
                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }

                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }
        public Response<CMaintenenceMetersOff> Update(int id, InsertCMaintenenceMetersOffInput model)
        {
            Response<CMaintenenceMetersOff> response = new Response<CMaintenenceMetersOff>();
            try
            {
                var result = validateUpdateCMaintenenceMetersOff(model);

                var data = _context.CMaintenenceMetersOff.FirstOrDefault(r => r.IsDeleted != true && r.Id == id);
                if (data == null)
                {
                    response.status = EmptyMember.Status;
                    response.code = EmptyMember.Code;
                    response.message = EmptyMember.messageAr;
                    response.status = EmptyMember.Status;
                    return response;
                }

                else
                {
                    data.IsDeleted = false;
                    data.Id = id;
                    data.IsEnded = false;
                    data.Address = model.Address;
                    data.IsMeterRecieved = false;
                    data.MainDepartmentId = model.MainDepartmentId;
                    data.CreationTime = data.CreationTime;
                    data.ModificationTime = DateTime.Now;
                    data.ModifiedById = 1;
                    data.NationalId  = model.NationalId;
                    data.PlaceTypeId = model.PlaceTypeId;
                    data.SmallDepartmentId = model.SmallDepartmentId;
                    data.MainDepartmentCode = model.MainDepartmentCode;
                    data.MeterOffStatusId = model.MeterOffStatusId;
                    data.MeterOffReason = model.MeterOffReason;
                    data.CreatorById = 1;
                   
                    _context.Update(data);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.code = Updated.Code;
                        response.payload = data;
                        response.status = Updated.Status;
                        response.message = Updated.messageAr;
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

            response.code = Failed.Code;
            response.message = Failed.messageEn;
            response.status = Failed.Status;
            response.payload = null;
            return response;
        }

        //public Response<CMaintenenceMetersOff> AddFixedMeterToTechinition(int id, FixedMeterToTechinitionInsert model)
        //{
            
        //    Response<CMaintenenceMetersOff> response = new Response<CMaintenenceMetersOff>();
        //    try
        //    {
        //        var resultOfValidation = ValidateAddFixedMeterToTechinicion(model);
        //        if (resultOfValidation)
        //        {
        //            var cmaintainancemeteroff = GetByIdTableData(id);
        //            if (cmaintainancemeteroff !=null)
        //            {
        //                cmaintainancemeteroff.payload.MeterInstallationDate= model.InstallationDate;
        //                cmaintainancemeteroff.payload.DeliveryDateToTechnician = model.DeliveryDateToTechnician;
        //                cmaintainancemeteroff.payload.MaintenanceDate = model.MaintenanceDate;
                        
        //            }
        //            var result = _context.Update(resultOfValidation);
        //            var ISSaved = Save() > 0;
        //            if (ISSaved)
        //            {
        //                response.code = Added.Code;
        //                response.payload = null;
        //                response.status = Added.Status;
        //                response.message = Added.messageAr;
        //                return response;
        //            }
        //        }

        //        response.code = Failed.Code;
        //        response.message = Failed.messageEn;
        //        response.status = Failed.Status;
        //        response.payload = null;
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.code = GeneralException.Code;
        //        response.message = GeneralException.messageAr;
        //        response.status = ex.Message;
        //        response.payload = null;
        //        return response;
        //    }
           
        //}


        public bool validateUpdateCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput model)
        {
            var isExist = _context.CMaintenenceMetersOff.Any(g => g.SerialNumber == model.SerialNumber);
            if (model == null)
            {
                return false;
            }
            //if (isExist && model.MeterOffStatusId == 1)
            //{
            //    throw new Exception("لا يمكن الاضافة حيث أن العداد معطل بالفعل");
            //}

            if (!isExist)
            {
                throw new Exception("هذا العداد غير موجود بالاعطال");
            }

            if (model.SerialNumber == null)
            {
                throw new Exception("ادخل رقم العداد");
            }

            if (model.MainDepartmentCode == null)
            {
                throw new Exception("كود الادارة الرئيسية فارغ");
            }

            if (model.SmallDepartmentCode == null)
            {
                throw new Exception("كود الادارة الفرعية فارغ");
            }
            if (model.MeterOffMaintainNote == null)
            {
                throw new Exception("ادخل الملاحظات");
            }
            if (model.MeterOffReason == null)
            {
                throw new Exception("ادخل سبب العطل");
            }
            if (model.MeterOffStatusId == null)
            {
                throw new Exception("اختر حالة العداد");
            }
            if (model.CUploadMainteneceMetersOffReasonId == null)
            {
                throw new Exception("اختر سبب العطل");
            }
            if (model.RegionNo == null)
            {
                throw new Exception("اختر كود المنطقة");
            }
            if (model.DailyNo == null)
            {
                throw new Exception("ادخل رقم اليومية");
            }
            if (model.AccountNo == null)
            {
                throw new Exception("ادخل رقم الحساب");
            }
            if (model.BranchNo == null)
            {
                throw new Exception("ادخل القطاع");
            }
            if (model.SmallDepartmentId == null)
            {
                throw new Exception("اختر الادارة الفرعية");
            }
            if (model.MainDepartmentId == null)
            {
                throw new Exception("اختر الادارة الرئيسية");
            }
            if (model.SectionId == null)
            {
                throw new Exception("اختر القطاع");
            }
            if (model.ActivityTypeId == null)
            {
                throw new Exception("اختر النشاط");
            }
            if (model.PlaceTypeId == null)
            {
                throw new Exception("اختر وصف المكان");
            }
            if (model.Address == null)
            {
                throw new Exception("ادخل العنوان");
            }
            if (model.NationalId == null)
            {
                throw new Exception("ادخل هوية المستخدم");
            }
            if (model.CustomerName == null)
            {
                throw new Exception("ادخل اسم المشترك");
            }
            if (model.CustomerCode == null)
            {
                throw new Exception("ادخل كود المشترك");
            }
            if (model.VendorCode == null)
            {
                throw new Exception("ادخل كود الشركة المصنعة");
            }
            return true;
        }
        public bool validateInsertCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput model)
        {
            var isExist = _context.CMaintenenceMetersOff.Any(g => g.SerialNumber == model.SerialNumber);
            if (model == null)
            {
                return false;
            }
            //if (isExist && model.MeterOffStatusId == 1)
            //{
            //    throw new Exception("لا يمكن الاضافة حيث أن العداد معطل بالفعل");
            //}

            if (isExist)
            {
                throw new Exception("لا يمكن الاضافة حيث أن العداد معطل بالفعل");
            }

            if (model.SerialNumber == null)
            {
                throw new Exception("ادخل رقم العداد");
            }

            if (model.MainDepartmentCode == null)
            {
                throw new Exception("كود الادارة الرئيسية فارغ");
            }

            if (model.SmallDepartmentCode == null)
            {
                throw new Exception("كود الادارة الفرعية فارغ");
            }
            if (model.MeterOffMaintainNote == null)
            {
                throw new Exception("ادخل الملاحظات");
            }
            if (model.MeterOffReason == null)
            {
                throw new Exception("ادخل سبب العطل");
            }
            if (model.MeterOffStatusId == null)
            {
                throw new Exception("اختر حالة العداد");
            }
            if (model.CUploadMainteneceMetersOffReasonId == null)
            {
                throw new Exception("اختر سبب العطل");
            }
            if (model.RegionNo == null)
            {
                throw new Exception("اختر كود المنطقة");
            }
            if (model.DailyNo == null)
            {
                throw new Exception("ادخل رقم اليومية");
            }
            if (model.AccountNo == null)
            {
                throw new Exception("ادخل رقم الحساب");
            }
            if (model.BranchNo == null)
            {
                throw new Exception("ادخل القطاع");
            }
            if (model.SmallDepartmentId == null)
            {
                throw new Exception("اختر الادارة الفرعية");
            }
            if (model.MainDepartmentId == null)
            {
                throw new Exception("اختر الادارة الرئيسية");
            }
            if (model.SectionId == null)
            {
                throw new Exception("اختر القطاع");
            }
            if (model.ActivityTypeId == null)
            {
                throw new Exception("اختر النشاط");
            }
            if (model.PlaceTypeId == null)
            {
                throw new Exception("اختر وصف المكان");
            }
            if (model.Address == null)
            {
                throw new Exception("ادخل العنوان");
            }
            if (model.NationalId == null)
            {
                throw new Exception("ادخل هوية المستخدم");
            }
            if (model.CustomerName == null)
            {
                throw new Exception("ادخل اسم المشترك");
            }
            if (model.CustomerCode == null)
            {
                throw new Exception("ادخل كود المشترك");
            }
            if (model.VendorCode == null)
            {
                throw new Exception("ادخل كود الشركة المصنعة");
            }
            return true;
        }

        public bool ValidateAddFixedMeterToTechinicion(FixedMeterToTechinitionInsert model)
        {
            if (model.InstallationDate > model.DeliveryDateToTechnician)
            {
                throw new Exception("تاريخ الاصلاح يجب أن يكون قبل تاريخ التسليم للفنى");
            }

            if (model.DeliveryDateToTechnician > model.MaintenanceDate)
            {
                throw new Exception("تاريخ التسليم للفنى يجب أن يكون قبل تاريخ التركيب");
            }

            if (model.InstallationDate > model.MaintenanceDate)
            {
                throw new Exception("تاريخ الاصلاح يجب أن يكون قبل تاريخ تركيب العداد");
            }
            return true;
        }

      
        public int Save()
        {
            int status = -1;
            try { status = _context.SaveChanges(); }
            catch (Exception ex) { }
            return status;
        }

        public Response<CMaintenenceMetersOff> AddFixedMeterToTechinition(int id, FixedMeterToTechinitionInsert model)
        {
            Response<CMaintenenceMetersOff> response = new Response<CMaintenenceMetersOff>();
            try
            {
               
                var result = ValidateAddFixedMeterToTechinicion(model);
                if (result)
                {
                    var data = _context.CMaintenenceMetersOff.AsNoTracking()
                        .FirstOrDefault(r => r.IsDeleted != true && r.Id == id);
                    if (data == null)
                    {
                        response.status = EmptyMember.Status;
                        response.code = EmptyMember.Code;
                        response.message = "لا يوجد عطل بهذا الرقم";
                        response.payload = null;
                        return response;
                    }
                    else
                    {
                        data.MeterInstallationDate = model.MaintenanceDate;
                        data.DeliveryDateToTechnician = model.MaintenanceDate;
                        data.MaintenanceDate = model.MaintenanceDate;
                        _context.Update(data);
                        var ISSaved = Save() > 0;
                        if (ISSaved)
                        {
                            response.code = Updated.Code;
                            response.payload = data;
                            response.status = Updated.Status;
                            response.message = Updated.messageAr;
                            return response;
                        }
                    }
                }
                else
                {
                    response.status = EmptyMember.Status;
                    response.code = EmptyMember.Code;
                    response.message = EmptyMember.messageAr;
                    response.payload = null;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

           
        }
        
    }
}

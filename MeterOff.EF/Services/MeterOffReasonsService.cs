using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.MeterOffReasons;
using MeterOff.Core.Models.Exception;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class MeterOffReasonsService : IMeterOffReasonsRepository
    {
        private readonly DBContext _context;

        public MeterOffReasonsService(DBContext context)
        {
            _context = context;
        }

        public async Task<CUploadMainteneceMetersOffReason> Add(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        {
            await _context.AddAsync(cuploadMeterOffReasonsOutput);
            _context.SaveChanges();

            return cuploadMeterOffReasonsOutput;

        }

        public CUploadMainteneceMetersOffReason Delete(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        {

            cuploadMeterOffReasonsOutput.IsDeleted = true;
            _context.Update(cuploadMeterOffReasonsOutput);
            //_context.Remove(cuploadMeterOffReasonsOutput);
            _context.SaveChanges();

            return cuploadMeterOffReasonsOutput;
        }

        public IEnumerable<CUploadMainteneceMetersOffReason> GetAll()
        {
            var m = _context.CUploadMainteneceMetersOffReason.ToList();
            //var aa = await _context.CUploadMainteneceMetersOffReason.ToListAsync();
            return m;

        }

        public async Task<CUploadMainteneceMetersOffReason> GetByCode(int Code)
        {
            var model = _context.CUploadMainteneceMetersOffReason.SingleOrDefault(m => m.Code == Code);
            return model;

        }

        public async Task<CUploadMainteneceMetersOffReason> GetById(int id)
        {
            var model = _context.CUploadMainteneceMetersOffReason.SingleOrDefault(m => m.Id == id);
            return model;
        }

        public CUploadMainteneceMetersOffReason Update(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        {
            _context.Update(cuploadMeterOffReasonsOutput);
            _context.SaveChanges();

            return cuploadMeterOffReasonsOutput;
        }

        public bool IsvalidCUploadMainteneceMetersOffReason(int? uploadReasonId)
        {
            var isFound = _context.CUploadMainteneceMetersOffReason.Any(g => g.Id == uploadReasonId);
            return isFound;
        }

        public bool validateInsertCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput model)
        {
            var isExist = _context.CMaintenenceMetersOff.Any(g => g.SerialNumber == model.SerialNumber);
            if (model == null)
            {
                return false;
            }
            if (isExist && model.MeterOffStatusId == 1)
            {
                throw new UserFriendlyException("لا يمكن الاضافة حيث أن العداد معطل بالفعل");
            }

            if (model.SerialNumber == null)
            {
                throw new UserFriendlyException("ادخل رقم العداد");
            }

            if (model.MainDepartmentCode == null)
            {
                throw new UserFriendlyException("كود الادارة الرئيسية فارغ");
            }

            if (model.SmallDepartmentCode == null)
            {
                throw new UserFriendlyException("كود الادارة الفرعية فارغ");
            }
            if (model.MeterOffMaintainNote == null)
            {
                throw new UserFriendlyException("ادخل الملاحظات");
            }
            if (model.MeterOffReason == null)
            {
                throw new UserFriendlyException("ادخل سبب العطل");
            }
            if (model.MeterOffStatusId == null)
            {
                throw new UserFriendlyException("اختر حالة العداد");
            }
            if (model.CUploadMainteneceMetersOffReasonId == null)
            {
                throw new UserFriendlyException("اختر سبب العطل");
            }
            if (model.RegionNo == null)
            {
                throw new UserFriendlyException("اختر كود المنطقة");
            }
            if (model.DailyNo == null)
            {
                throw new UserFriendlyException("ادخل رقم اليومية");
            }
            if (model.AccountNo == null)
            {
                throw new UserFriendlyException("ادخل رقم الحساب");
            }
            if (model.BranchNo == null)
            {
                throw new UserFriendlyException("ادخل القطاع");
            }
            if (model.SmallDepartmentId == null)
            {
                throw new UserFriendlyException("اختر الادارة الفرعية");
            }
            if (model.MainDepartmentId == null)
            {
                throw new UserFriendlyException("اختر الادارة الرئيسية");
            }
            if (model.SectionId == null)
            {
                throw new UserFriendlyException("اختر القطاع");
            }
            if (model.ActivityTypeId == null)
            {
                throw new UserFriendlyException("اختر النشاط");
            }
            if (model.PlaceTypeId == null)
            {
                throw new UserFriendlyException("اختر وصف المكان");
            }
            if (model.Address == null)
            {
                throw new UserFriendlyException("ادخل العنوان");
            }
            if (model.NationalId == null)
            {
                throw new UserFriendlyException("ادخل هوية المستخدم");
            }
            if (model.CustomerName == null)
            {
                throw new UserFriendlyException("ادخل اسم المشترك");
            }
            if (model.CustomerCode == null)
            {
                throw new UserFriendlyException("ادخل كود المشترك");
            }
            if (model.VendorCode == null)
            {
                throw new UserFriendlyException("ادخل كود الشركة المصنعة");
            }
            return true;
        }

        public bool ValidateAddFixedMeterToTechinicion(FixedMeterToTechinitionInsert model)
        {
            if (model.InstallationDate > model.DeliveryDateToTechnician)
            {
                throw new UserFriendlyException("تاريخ الاصلاح يجب أن يكون قبل تاريخ التسليم للفنى");
            }

            if (model.DeliveryDateToTechnician > model.MaintenanceDate)
            {
                throw new UserFriendlyException("تاريخ التسليم للفنى يجب أن يكون قبل تاريخ التركيب");
            }
           
            if (model.InstallationDate > model.MaintenanceDate)
            {
                throw new UserFriendlyException("تاريخ الاصلاح يجب أن يكون قبل تاريخ تركيب العداد");
            }
            return true;
        }

        public bool ValidateAddReason(InsertCUploadMainteneceMetersOffReasonInput model)
        {
            if (model == null)
            {
                return false;
            }
            if (model.Code == null)
            {
                throw new UserFriendlyException("يجب ادخال كود لسبب العطل");
            }
            if (model.Name == null)
            {
                throw new UserFriendlyException("يجب ادخال سبب للعطل");
            }
            return true;
        }

    }
}

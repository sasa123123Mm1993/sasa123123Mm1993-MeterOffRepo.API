using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.CMaintenenceMetersOff
{
    public class InsertCMaintenenceMetersOffInput : BaseDto
    {
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatorById { get; set; }
        public int? ModifiedById { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public int VendorCode { get; set; }
        public string CustomerCode { get; set; }
        public int? SerialNumber { get; set; }
        public string CustomerName { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public int PlaceTypeId { get; set; }
        public int ActivityTypeId { get; set; }
        public int SectionId { get; set; }
        public int MainDepartmentId { get; set; }
        public int SmallDepartmentId { get; set; }
        public int BranchNo { get; set; }
        public int AccountNo { get; set; }
        public int DailyNo { get; set; }
        public int RegionNo { get; set; }
        public DateTime? MeterPreparedDate { get; set; }
        public DateTime? MeterInstallationDate { get; set; }
        public DateTime? MeterOffDate { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? DeliveryDateToLaboratory { get; set; }
        public int CUploadMainteneceMetersOffReasonId { get; set; } // سبب الرفع
        public int MeterOffStatusId { get; set; } //حالة العداد عند الرفع(Enum)
        public string MeterOffReason { get; set; } // سبب العطل
        public string MeterOffMaintainNote { get; set; }
        public string? ExaminationNumber { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public int? MeterTypeId { get; set; }  //نوع العداد
        public bool? IsExaminationdata { get; set; }
        public int MainDepartmentCode { get; set; }
        public int SmallDepartmentCode { get; set; }
    }
}

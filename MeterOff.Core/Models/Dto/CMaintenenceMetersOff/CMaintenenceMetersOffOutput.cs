using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.CMaintenenceMetersOff
{
    public class CMaintenenceMetersOffOutput : BaseDto
    {
        public int VendorCode { get; set; }
        public string CustomerCode { get; set; }
        public int? SerialNumber { get; set; }
        public string CustomerName { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string PlaceTypeName { get; set; }
        public string ActivityName { get; set; }
        public string SectionName { get; set; }
        public string MainDepartmentName { get; set; }
        public string SmallDepartmentName { get; set; }
        public int BranchNo { get; set; }
        public int AccountNo { get; set; }
        public int DailyNo { get; set; }
        public int RegionNo { get; set; }
        public DateTime? MeterPreparedDate { get; set; }
        public DateTime? MeterInstallationDate { get; set; }
        public DateTime? MeterOffDate { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? DeliveryDateToLaboratory { get; set; }
        public DateTime? DeliveryDateToTechnician { get; set; }

        public string UploadReason { get; set; } // سبب الرفع
        public string MeterOffStatus { get; set; }//حالة العداد عند الرفع
        public string MeterOffReason { get; set; } // سبب العطل
        public string MeterOffMaintainNote { get; set; }
        public string? ExaminationNumber { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public int? MeterTypeId { get; set; }  //نوع العداد
        public bool? IsExaminationdata { get; set; }
        public int MainDepartmentCode { get; set; }
        public int SmallDepartmentCode { get; set; }
        public int ActivityTypeId { get; set; }
        public int SmallDepartmentId { get; set; }
        public int MainDepartmentId { get; set; }
        public int SectionId { get; set; }
        public int PlaceTypeId { get; set; }
        public int meterOffStatusId { get; set; }
        public int cUploadMainteneceMetersOffReasonId { get; set; }
        public bool? IsMeterRecieved { get; set; } //حالة تسليم العداد للفنى
        public bool? IsEnded { get; set; }
        public bool? IsMeterInstalled { get; set; }
        public DateTime? MaintenanceDate { get; set; }



    }
}

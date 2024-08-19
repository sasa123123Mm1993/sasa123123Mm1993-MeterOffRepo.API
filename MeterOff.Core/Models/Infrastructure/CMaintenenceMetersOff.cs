using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public class CMaintenenceMetersOff : BaseEntity
    {
        public int VendorCode { get; set; }
        [MaxLength(50)]
        public string CustomerCode { get; set; }
        public int? SerialNumber { get; set; }

        [MaxLength(250)]
        public string CustomerName { get; set; }

        [MaxLength(50)]
        public string NationalId { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }


        //[ForeignKey(nameof(PlaceType))] //اوصاف المكان
        public int PlaceTypeId { get; set; }
        public virtual PlaceType placeType { get; set; }




        //[ForeignKey(nameof(ActivityType))]
        public int ActivityTypeId { get; set; }
        public virtual ActivityType activityType { get; set; }// الانشطة



        //[ForeignKey(nameof(Section))]
        public int SectionId { get; set; }
        public virtual Section section { get; set; } //القطاعات

        



       
        //[ForeignKey(nameof(MainDepartment))]
        public int MainDepartmentId { get; set; }
        public virtual MainDepartment mainDepartment { get; set; } //الادارات الرئيسية


        //[ForeignKey(nameof(SmallDepartment))]
        public int SmallDepartmentId { get; set; }
        public virtual SmallDepartment smallDepartment { get; set; } //الادارات الفرعية



        public int BranchNo { get; set; }
        public int AccountNo { get; set; }
        public int DailyNo { get; set; }
        public int RegionNo { get; set; }
        public DateTime? MeterPreparedDate { get; set; }
        public DateTime? MeterInstallationDate { get; set; }
        public DateTime? MeterOffDate { get; set; }
        public DateTime? UploadDate { get; set; }// تاريخ رفع العداد
        public DateTime? DeliveryDateToLaboratory { get; set; }

        
        public bool? IsMeterRecieved { get; set; } //هل تم تسليم العداد للفنى ؟

        public int CUploadMainteneceMetersOffReasonId { get; set; } // سبب الرفع
        public virtual  CUploadMainteneceMetersOffReason UploadMainteneceMetersOffReason { get; set; }




        public int MeterOffStatusId { get; set; } //حالة العداد عند الرفع(Enum)
        public string MeterOffReason { get; set; } // سبب العطل
        public string MeterOffMaintainNote { get; set; }

        public string? ExaminationNumber { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public DateTime? DeliveryDateToTechnician { get; set; }
        public DateTime? MaintenanceDate { get; set; } // تاريخ اصلاح العداد

        

        //[ForeignKey(nameof(MeterType))]
        public int? MeterTypeId { get; set; }  //نوع العداد
        public virtual MeterType meterType { get; set; }


        public bool? IsExaminationdata { get; set; }
        public bool? IsEnded { get; set; } //0 : معطل or 1 : منهى
        public bool? IsMeterInstalled { get; set; } // هل تم تسليم العداد للفنى
        

        public int MainDepartmentCode { get; set; }
        public int SmallDepartmentCode { get; set; }

    }
}

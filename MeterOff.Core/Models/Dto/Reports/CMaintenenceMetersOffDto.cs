using MeterOff.Core.Models.Constant;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MeterOff.Core.Models.Dto.Reports
{
    public class CMaintenenceMetersOffDto : BaseDto
    {
        public int? CUploadMainteneceMetersOffReasoniD { get; set; }//
        public int? CMMOiD { get; set; }//
        public string? Name { get; set; }//
        public string? Note { get; set; }//
        public int? Code { get; set; }//
        public int? PlaceTypeId { get; set; }//
        

        public string? CustomerCode { get; set; }//
        public int? VendorCode { get; set; }//
        public string CustomerName { get; set; }//
        public string NationalId { get; set; }//
        public string? Address { get; set; }//
        public int? ActivityTypeId { get; set; }//
        public int? SectionId { get; set; }//
        public int? MainDepartmentId { get; set; }//
        public int? SmallDepartmentId { get; set; }//
        public int? BranchNo { get; set; }//
        public int? AccountNo { get; set; }//
        public int? DailyNo { get; set; }//
        public int? RegionNo { get; set; }//
        public DateTime? MeterPreparedDate { get; set; }//
        public DateTime? MeterInstallationDate { get; set; }//
        public DateTime? MeterOffDate { get; set; }//
        //public DateTime? UploadDate { get; set; }
        public DateTime? DeliveryDateToLaboratory { get; set; }//
        public bool? IsMeterRecieved { get; set; }//
        //public int? MeterOffStatusId { get; set; }
        public string? MeterOffReason { get; set; }//
        public DateTime? DeliveryDateToTechnician { get; set; }//
        public DateTime? MaintenanceDate { get; set; }//
        //public string? MeterOffMaintainNote { get; set; }
        //public string? ExaminationNumber { get; set; }
        //public DateTime? ExaminationDate  {get; set;}
        //public bool? MeterTypeId { get; set; }
        //public DateTime? IsExaminationdata { get; set; }
        //public bool? IsEnded { get; set; }
        public int? MainDepartmentCode { get; set; }//
        //public bool? IsMeterInstalled { get; set; }
        public int? SmallDepartmentCode { get; set; }//
        
        public int? SerialNumber { get; set; }//


    }
}

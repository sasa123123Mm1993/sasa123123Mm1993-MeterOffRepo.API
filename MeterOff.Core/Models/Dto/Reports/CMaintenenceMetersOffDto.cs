using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.Reports
{
    public class CMaintenenceMetersOffDto : BaseDto
    {
        public int VendorCode { get; set; }
        public int MeterId1 { get; set; }
        public DateTime? MeterOffDate1 { get; set; }
        public DateTime? UploadDate1 { get; set; }
        public DateTime? DeliveryDateToTechnician { get; set; }
        public DateTime? DeliveryDateToLaboratory { get; set; }
        public DateTime? MaintenanceDate1 { get; set; }
        public DateTime? InstallationDate1 { get; set; }
        public string MeterOffReason1 { get; set; }
        public string UploadReason1 { get; set; }
        public string UploadMeterStatus1 { get; set; }
        public string MeterOffStatus1 { get; set; }
        public string Notes1 { get; set; }
        public int UploadReasonId1 { get; set; }
        public string PlaceName { get; set; }
        public string ActivityName { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string RefferenceAddress { get; set; }
        public string NationalId { get; set; }
        public int? SerialNumber { get; set; }
        public int? DepartmentNo { get; set; }
        public int SmallDepartmentNo { get; set; }
        public DateTime? MeterInstallationDate { get; set; }
        public DateTime? MeterPreparedDate { get; set; }
        public int OrganizationLevelId { get; set; }
        public string DepartName { get; set; }
        public int? RegionCode { get; set; }
        public string smalldepartment { get; set; }
        public string Department { get; set; }
        public string Sector { get; set; }
        public int BranchNo { get; set; }
        public int AccountNo { get; set; }
        public int DailyNo { get; set; }
        public int RegionNo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class InsertControlCardInput
    {
        public int EmployeeId { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public int Limitation { get; set; }//0 one meter   1 many meters  2 unlimited
        public int PropertyId { get; set; }
        public int? DateTimeMode { get; set; }
        public double? CutoffAlarmLimitBalance { get; set; }
        public string? MeterSerial { get; set; }
        public int MeterType { get; set; }
        public string? MeterTypeModel { get; set; }
        //public string Company { get; set; }
        public int? TariffTypeId { get; set; }
        public bool? ModificationStyle { get; set; }
        public string AutomaticDate { get; set; }
        public DateTime AutomaticTime { get; set; }
        public List<string?>? ControledMetersList { get; set; }
        public List<string?>? TampersCodes { get; set; }
        public bool IsActive { get; set; }
        public string? OldMeterSerial { get; set; }
        public string? NewMeterSerial { get; set; }
        public string? OldDistributionCompanyCode { get; set; }
        public string? NewDistributionCompanyCode { get; set; }
        public string? LabTestCardAvailableTime { get; set; }
        public string? LabTestCardAvailableKWh { get; set; }
        public string? ReverseCardRecoveryTime { get; set; }
        public string Company { get; set; }

    }

   
}






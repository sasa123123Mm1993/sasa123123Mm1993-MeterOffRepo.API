using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class DbSetting : BaseEntity
    {
        public int DbSerial { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyLogoPrint { get; set; }
        public string CompanyNameAr { get; set; }
        public string CompanyNameEn { get; set; }
        public string CompanyNameFr { get; set; }
    }
}

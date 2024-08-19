using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class DataTable : BaseEntity
    {
        [MaxLength(50)]
        public string TableFullName { get; set; }
        [MaxLength(50)]
        public string TableNameAr { get; set; }
        [MaxLength(50)]
        public string TableNameEn { get; set; }
    }
}

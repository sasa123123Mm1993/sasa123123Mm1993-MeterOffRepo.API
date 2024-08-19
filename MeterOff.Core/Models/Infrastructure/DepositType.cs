using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class DepositType : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsClear { get; set; }
        public int Code { get; set; }//percentage

    }
}

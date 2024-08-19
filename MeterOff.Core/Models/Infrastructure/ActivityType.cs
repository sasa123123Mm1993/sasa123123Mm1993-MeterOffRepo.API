using MeterOff.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ActivityType : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal MinimumCharge { get; set; }
        public decimal MaximumCharge { get; set; }
        public int TariffTypeCode { get; set; }
        public bool ISsmall { get; set; }
        public bool ISBig { get; set; }
        public int StutsBigSmall { get; set; }
        public virtual ICollection<Tariff> Tariffs { get; set; }

    }
}


using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class TamperDto
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public bool IsMustPay { get; set; }
        public bool IsAvailableInCharge { get; set; }
        public bool IsStopRecharge { get; set; }
        public virtual ICollection<ConsumerTamper> AccountTampers { get; set; }
        public virtual ICollection<TariffTamper> TariffTampers { get; set; }

    }
}

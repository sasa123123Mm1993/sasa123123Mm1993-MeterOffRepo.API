using MeterOff.Core.Models.Enum;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class AccountStatusLog : BaseEntity
    {
        public int AccountId { get; set; }
        public AccountStatusEnum AccountStatusEnum { get; set; }

        public AccountSuspendReasonEnum? AccountSuspendReasonEnum { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
    }
}

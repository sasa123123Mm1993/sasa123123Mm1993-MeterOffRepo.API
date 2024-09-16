using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class AllControlCardDto : BaseDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Limitation { get; set; }//0 one meter   1 many meters  2 unlimited
        public string MeterSerial { get; set; }
        public string CardTitle { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsBlocked { get; set; }
        public string CardId { get; set; }
        public int? ControlCardOperationTypeEnum { get; set; }
        public UserDto User { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}

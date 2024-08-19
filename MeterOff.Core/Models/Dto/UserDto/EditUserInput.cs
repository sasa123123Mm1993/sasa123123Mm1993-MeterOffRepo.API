using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.UserDto
{
    public class EditUserInput : BaseDto
    {
        public string NatId { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<int> smallDepartmentsIds { get; set; }
    }
}

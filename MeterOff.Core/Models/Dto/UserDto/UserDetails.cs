using MeterOff.Core.Models;
using MeterOff.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.UserDto
{
    public class UserDetails : BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public int NatId { get; set; }
        public bool IsActive { get; set; }
        public SmallDepartment smallDepartment { get; set; }


    }
}

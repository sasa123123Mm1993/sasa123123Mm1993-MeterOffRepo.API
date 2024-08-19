using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.Auth
{
    public class NewAuthServiceResponseDto
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

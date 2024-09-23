using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Exception
{
    public class UserFriendlyException : IOException
    {
        public UserFriendlyException(string message, string description = "", int? code = null) : base(message)
        {
            Code = code;
            Description = description;
            Message = message;
        }
        public int? Code { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}

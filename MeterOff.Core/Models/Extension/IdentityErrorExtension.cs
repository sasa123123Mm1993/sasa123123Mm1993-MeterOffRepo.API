using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Extension
{
    public static class IdentityErrorExtension
    {
        public static string ToErrorString(this IEnumerable<IdentityError> errors)
        {
            var error = new StringBuilder();
            foreach (var item in errors)
            {
                error.Append($"Error - {item.Description} ");
            }
            return error.ToString();
        }
    }
}

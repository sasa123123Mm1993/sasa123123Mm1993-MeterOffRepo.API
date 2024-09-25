using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class ApiResponse<T> where T :class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public string ErrorCode { get; set; } // For custom business errors

        public ApiResponse(T data)
        {
            Success = true;
            Message = "Request successful";
            Data = data;
            Errors = null;
            ErrorCode = null;
        }

        public ApiResponse(List<string> errors, string errorCode = null)
        {
            Success = false;
            Message = "Request failed";
            Data = default;
            Errors = errors;
            ErrorCode = errorCode; // Provide custom error codes for business errors
        }
    }

}

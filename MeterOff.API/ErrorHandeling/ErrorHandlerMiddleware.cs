using MeterOff.Core.Models.Exception;
using Newtonsoft.Json;
using static MeterOff.API.Error_Handeling.ErrorHandlerMiddleware;

namespace MeterOff.API.Error_Handeling
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
           
            catch (Exception error)
            {
                var response = context.Response;
                //Set response ContentType
                response.ContentType = "application/json";

                //Set custome error message for response model
                var responseContent = new ResponseContent()
                {
                    code = 6000,
                    error = error.Message
                };
                //handler many Exception types
                switch (error)
                {
                    case ArgumentException _ae:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case UserFriendlyException _ue:
                        var res = new ResponseContent()
                        {
                            code = _ue.Code.Value,
                            error = error.Message
                        };
                        responseContent = res;
                        break;

                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                //Using Newtonsoft.Json to convert object to json string
                var jsonResult = JsonConvert.SerializeObject(responseContent);
                await response.WriteAsync(jsonResult);
            }
        }
        //Response Model
        public class ResponseContent
        {
            public string error { get; set; }
            public int? code { get; set; }
        }
    }
}

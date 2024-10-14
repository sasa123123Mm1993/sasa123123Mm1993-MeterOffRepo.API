using Azure;
using MeterOff.API.ErrorHandeling;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Base_Response.Providers;
using MeterOff.Core.Models.Exception;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
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
                //if (context.Session== "InvalidOperationException") { }
                await _next(context);
            }

            catch (BusinessException businessEx)
            {
                await HandleBusinessExceptionAsync(context, businessEx);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }

            //catch (HttpRequestException HttpRequestEx) when (HttpRequestEx.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    await HandleGeneralException(context, HttpRequestEx);
            //}

            catch (InvalidOperationException HttpRequestEx)
            {
                await HandleGeneralException(context, HttpRequestEx);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }



        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            
            Core.Models.Base.Response<HttpContext> response = new Core.Models.Base.Response<HttpContext>();
            response.code = GeneralException.Code;
            response.message = ex.Message;
            response.status = "خطأ عام --- ValidationException";
            response.payload = null;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }


        private Task HandleBusinessExceptionAsync(HttpContext context, BusinessException exception)
        {
            Core.Models.Base.Response<HttpContext> response = new Core.Models.Base.Response<HttpContext>();
            response.code = GeneralException.Code;
            response.message = exception.Message;
            response.status = "خطأ عام --- BusinessException";
            response.payload = null;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));

            //var response = new ApiResponse<string>(new List<string> { exception.Message }, exception.ErrorCode);
            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        private Task HandleGeneralException(HttpContext context, InvalidOperationException basicException)
        {
            Core.Models.Base.Response<HttpContext> response = new Core.Models.Base.Response<HttpContext>();

            response.code = GeneralException.Code;
            response.message = GeneralException.messageAr;
            response.status = "خطأ عام --- GeneralException";
            response.payload = null;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Core.Models.Base.Response<HttpContext> response = new Core.Models.Base.Response<HttpContext>();

            response.code = GeneralException.Code;
            response.message = GeneralException.messageAr;
            response.status = "خطأ عام --- Exception";
            response.payload = null;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    try
        //    {
        //        await _next(context);
        //    }

        //    catch (Exception error)
        //    {
        //        await HandleExceptionAsync(context, error);
        //        var response = context.Response;
        //        //Set response ContentType
        //        response.ContentType = "application/json";

        //        //Set custome error message for response model
        //        var responseContent = new ResponseContent()
        //        {
        //            code = 6000,
        //            error = error.Message
        //        };
        //        //handler many Exception types
        //        switch (error)
        //        {
        //            case ArgumentException _ae:
        //                response.StatusCode = StatusCodes.Status400BadRequest;
        //                break;
        //            case UserFriendlyException _ue:
        //                var res = new ResponseContent()
        //                {
        //                    code = _ue.Code.Value,
        //                    error = error.Message
        //                };
        //                responseContent = res;
        //                break;

        //            default:
        //                response.StatusCode = StatusCodes.Status500InternalServerError;
        //                break;
        //        }

        //        //Using Newtonsoft.Json to convert object to json string
        //        var jsonResult = JsonConvert.SerializeObject(responseContent);
        //        await response.WriteAsync(jsonResult);
        //    }
        //}




        //Response Model
        public class ResponseContent
        {
            public string error { get; set; }
            public int? code { get; set; }
        }

        public class ValidationErrorResponse
        {
            public string Type { get; set; }
            public string Title { get; set; }
            public int Status { get; set; }
            public string TraceId { get; set; }
            public Dictionary<string, List<string>> Errors { get; set; }
        }
    }

   



}

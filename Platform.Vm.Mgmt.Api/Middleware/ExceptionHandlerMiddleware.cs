using Platform.Vm.Mgmt.Application.Responses;
using System.Net;
using System.Text.Json;

namespace Platform.Vm.Mgmt.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;
            var response = new BaseResponse() { Success = false };

            switch (exception)
            {
                case Application.Exceptions.ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.ValidationErrors = validationException.ValdationErrors;
                    response.Message = $"error : {httpStatusCode} : {validationException.Message}";
                    
                    break;
                case Application.Exceptions.BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.Message = $"error : {httpStatusCode} : {badRequestException.Message}";

                    break;
                case Application.Exceptions.NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    response.Message = $"error : {httpStatusCode} : {notFoundException.Message}";

                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    response.Message = $"error : {httpStatusCode} : {ex.Message}";

                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            result = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(result);
        }
    }
}
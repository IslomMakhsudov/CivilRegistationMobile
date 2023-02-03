using System.Diagnostics.CodeAnalysis;

namespace CivilRegistrationMobile.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionAsync(context,
                    ex.Message,
                    HttpStatusCode.BadRequest,
                    
                    "Произошла ошибка сервера, пожалуйста повторите ваш запрос или обратитесь в службу поддержки  -  ");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            string exMessage,
            HttpStatusCode statusCode,
            string message)
        {
            _logger.LogError(exMessage);

            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;

            byte[] bytes = Encoding.UTF8.GetBytes(message);
            message = Encoding.UTF8.GetString(bytes);

            ErrorDto errorDto = new ErrorDto { Message = message, StatusCode = (int)statusCode };

            await response.WriteAsync(message + exMessage);
        }
    }
}

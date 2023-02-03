using System.Runtime.InteropServices;

namespace CivilRegistrationMobile.Middleware
{
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly BaseService _baseService;
        public SessionCheckMiddleware(RequestDelegate next, BaseService baseService)
        {
            _next = next;
            _baseService = baseService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path != "/General/Index" && context.Request.Path != "/")
            {
                string? exId = context.Session.GetString("externalID");
                if (string.IsNullOrWhiteSpace(exId) || exId == "0")
                {
                    bool hashStatus = _baseService.CheckHash(context);
                    if (!hashStatus)
                    {
                        context.Response.StatusCode = 454;
                    }
                    else
                    {
                        await _next.Invoke(context);
                    }
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else 
            {
                string? exId = context.Session.GetString("externalID");
                if (string.IsNullOrWhiteSpace(exId) || exId == "0")
                {
                    bool hashStatus = _baseService.CheckHash(context);
                    if (!hashStatus)
                    {
                        context.Response.StatusCode = 454;
                    }
                    else
                    {
                        await _next.Invoke(context);
                    }
                }
                else
                {
                    await _next.Invoke(context);
                }
            }


        }
    }
}

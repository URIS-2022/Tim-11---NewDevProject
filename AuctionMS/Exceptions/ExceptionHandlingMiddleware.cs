using Newtonsoft.Json;
using System.Net;

namespace AuctionMS.Exceptions
{
    public class ErrorHandlingMiddleware : IMiddleware 
    {
        public ErrorHandlingMiddleware() { }

        private static Task HandleExceptionAsync(HttpContext context, BaseException ex)
        {
            if (ex.code == 0)
            {
                ex.code = HttpStatusCode.InternalServerError;
            }

            var result = JsonConvert.SerializeObject(new
            {
                messsage = ex.Message,
                status = ex.code,
                requested_uri = context.Request.Path,
                timestamp = DateTime.Now
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)ex.code;

            return context.Response.WriteAsync(result);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BaseException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
    }
}

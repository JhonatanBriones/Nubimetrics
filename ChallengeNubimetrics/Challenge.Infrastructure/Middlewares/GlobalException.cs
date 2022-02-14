using Challenge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;

namespace Challenge.Infrastructure.Middlewares
{
    public class GlobalException
    {
        private readonly RequestDelegate next;
        public GlobalException(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await ResponseMessage.WriteException(context, ex, true);
            }
        }
    }
}

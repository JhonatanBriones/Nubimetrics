using Challenge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
#nullable disable
namespace Challenge.Infrastructure.Middlewares
{
    public class GlobalFormatResponse
    {
        private readonly RequestDelegate _next;

        public GlobalFormatResponse(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Object contentNew;
            String newContent;
            Stream originBody = context.Response.Body;
            try
            {
                using (MemoryStream newBody = new MemoryStream())
                {
                    context.Response.Body = newBody;

                    await _next(context);

                    context.Response.Body = originBody;
                    newBody.Seek(0L, SeekOrigin.Begin);

                    using (StreamReader reader = new StreamReader(newBody))
                    {
                        newContent = await reader.ReadToEndAsync();
                    }
                    var contentType = !string.IsNullOrEmpty(context.Response.ContentType) ? context.Response.ContentType : String.Empty;
                    if (ResponseMessage.IsValidJson(newContent))
                    {
                        contentNew = ResponseMessage.ToNewContent(newContent);
                    }
                    else
                    {
                        contentNew = newContent;
                    }
                    await WriteAsJsonAsync(context, contentNew);
                }
            }
            catch (Exception ex)
            {
                await ResponseMessage.WriteException(context, ex, false);
            }
        }
        private async Task WriteAsJsonAsync(HttpContext httpContext, Object data)
        {
            httpContext.Response.ContentLength = null;
            var appResponse = new
            {
                Success = httpContext.Response.StatusCode == (int)HttpStatusCode.OK,
                Message = httpContext.Response.StatusCode == (int)HttpStatusCode.OK ? "Success" : "Error controlado",
                Data = data
            };
            httpContext.Response.ContentType = "application/json";
            var appResponseSerialized = JsonConvert.SerializeObject(appResponse);
            await httpContext.Response.WriteAsync(appResponseSerialized);
        }

    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalFormatResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalFormatResponse>();
        }
    }
}

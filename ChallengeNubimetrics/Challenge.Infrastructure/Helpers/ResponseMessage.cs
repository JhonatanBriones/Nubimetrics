using Challenge.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Net;

namespace Challenge.Infrastructure.Helpers
{
    public static class ResponseMessage
    {
        public static async Task<Object> ToObject(HttpResponseMessage? responseMessage)
        {
            Object? result;
            if (responseMessage != null)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new AppException(content);
                }
                result = content;
            }
            else
            {
                throw new AppException("responseMessage vacío");
            }
            return result;
        }
        public static Object? ToNewContent(string newContent)
        {
            Object? contentNew;
            var settings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            settings.Converters.Add(new ObjectReferenceExpandoObjectConverter());
            if (newContent.StartsWith("{") && newContent.EndsWith("}"))
                contentNew = JsonConvert.DeserializeObject<ExpandoObject>(newContent, settings);
            else
                contentNew = JsonConvert.DeserializeObject<List<ExpandoObject>>(newContent, settings);
            return contentNew;
        }
        public static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || 
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static async Task WriteException(HttpContext context, object ex, bool isGlobalExeption)
        {
            if (ex.GetType() == typeof(UnauthorizedAccessException))
            {
                await FormatResponse(context, (int)HttpStatusCode.Unauthorized, "Unauthorized", isGlobalExeption, ((UnauthorizedAccessException)ex).Message);
            }
            else if (ex.GetType() == typeof(KeyNotFoundException))
            {
                await FormatResponse(context, (int)HttpStatusCode.NotFound, "Not Found", isGlobalExeption, ((KeyNotFoundException)ex).Message);
            }
            else if (ex.GetType() == typeof(AppException))
            {
                await FormatResponse(context, (int)HttpStatusCode.BadRequest, "Error controlado", isGlobalExeption, ((AppException)ex).Message);
            }
            else
            {
                await FormatResponse(context, (int)HttpStatusCode.InternalServerError, "Error no controlado - Comuníquese con el Administrador", isGlobalExeption, ((Exception)ex).Message);
            }
        }
        private static async Task FormatResponse(HttpContext context, int statusCode, string message, bool isGlobalExeption, Object? data = null)
        {
            if (isGlobalExeption)
            {
                string? res = string.Empty;
                if (data != null)
                    res = data.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(string.IsNullOrEmpty(res) ? string.Empty : res);
            }
            else
            {
                var appResponse = new
                {
                    Success = false,
                    Message = message,
                    Data = data
                };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                var appResponseSerialized = JsonConvert.SerializeObject(appResponse);
                await context.Response.WriteAsync(appResponseSerialized);
            }
        }
    }
}

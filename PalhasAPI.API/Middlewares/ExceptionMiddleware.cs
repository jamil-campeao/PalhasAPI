using Microsoft.IdentityModel.Tokens;
using PalhasAPI.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace PalhasAPI.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await EscreverResposta(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (BusinessException ex)
            {
                await EscreverResposta(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await EscreverResposta(context, HttpStatusCode.InternalServerError, "Ocorreu um erro inesperado");
            }
        }


        private static async Task EscreverResposta(HttpContext context, HttpStatusCode statusCode, string mensagem)
        {

            var opcoes = new JsonSerializerOptions { WriteIndented = false, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var resposta = new { erro = mensagem };
            await context.Response.WriteAsync(JsonSerializer.Serialize(resposta, opcoes));

        }
    }
}

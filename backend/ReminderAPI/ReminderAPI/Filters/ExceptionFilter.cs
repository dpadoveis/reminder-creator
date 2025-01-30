using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReminderAPI.Exceptions;
using ReminderAPI.Responses;
using System.Net;

namespace PassIn.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Manipula exceções lançadas durante a execução das requisições da API.
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            var result = context.Exception is ReminderException;
            if (result)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        /// <summary>
        /// Trata exceções específicas do projeto e define a resposta apropriada.
        /// </summary>
        /// <param name="context"></param>
        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundObjectResult(new ResponseErrorJson(context.Exception.Message));
            }

            else if (context.Exception is ErrorOnValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(context.Exception.Message));
            }
        }

        /// <summary>
        /// Trata erros desconhecidos, retornando um erro interno do servidor.
        /// </summary>
        /// <param name="context"></param>
        private static void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson("Erro desconhecido."));
        }
    }


}
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using ProvaTecnica.WebApi.Models;

namespace ProvaTecnica.WebApi.App_Start
{
    /// <summary>
    /// Implementação de <see cref="ExceptionHandler"/>.
    /// </summary>
    public class ApiExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Sobreescreve <see cref="ExceptionHandler.Handle"/>
        /// </summary>
        /// <param name="context">Instancia de <see cref="ExceptionHandlerContext"/>.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            var correlationId = Guid.NewGuid();

            var metadata = new ErrorInfoModel
            {
                Message = "Um erro não esperado aconteceu!",
                TimeStamp = DateTime.UtcNow,
                RequestUri = context.Request.RequestUri,
                ErrorId = correlationId
            };

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
            context.Result = new ResponseMessageResult(response);
        }
    }
}
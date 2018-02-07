using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using ProvaTecnica.WebApi.Models;

namespace ProvaTecnica.WebApi.App_Start
{
    /// <summary>
    /// Implementação de <see cref="ExceptionLogger"/>.
    /// </summary>
    public class ApiExceptionLogger : ExceptionLogger
    {
        /// <summary>
        /// Sobrescreve <see cref="ExceptionLogger.LogAsync"/>
        /// </summary>
        /// <param name="context">Instancia de <see cref="ExceptionLoggerContext"/>.</param>
        /// <param name="cancellationToken">Token para cancelar</param>
        /// <returns></returns>
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            var request = await CreateRequest(context.Request);
        }

        private static async Task<HttpRequestModel> CreateRequest(HttpRequestMessage message)
        {
            var request = new HttpRequestModel
            {
                Body = await message.Content.ReadAsStringAsync(),
                Method = message.Method.Method,
                Scheme = message.RequestUri.Scheme,
                Host = message.RequestUri.Host,
                Protocol = string.Empty,
                PathBase = message.RequestUri.PathAndQuery,
                Path = message.RequestUri.AbsoluteUri,
                QueryString = message.RequestUri.Query
            };

            return request;
        }
    }
}
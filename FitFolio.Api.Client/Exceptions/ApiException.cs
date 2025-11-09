using System.Net;

namespace FitFolio.Api.Client.Exceptions
{
    /// <summary>
    /// Exception thrown when an API request fails.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the failed request.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the response content from the failed request.
        /// </summary>
        public string? ResponseContent { get; }

        /// <summary>
        /// Gets the request URI that failed.
        /// </summary>
        public string? RequestUri { get; }

        public ApiException(
            string message, 
            HttpStatusCode statusCode, 
            string? responseContent = null,
            string? requestUri = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
            RequestUri = requestUri;
        }

        public override string ToString()
        {
            var baseMessage = base.ToString();
            return $"{baseMessage}\nStatus Code: {StatusCode}\nRequest URI: {RequestUri}\nResponse: {ResponseContent}";
        }
    }
}


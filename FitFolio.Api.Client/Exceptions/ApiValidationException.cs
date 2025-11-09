using System.Net;

namespace FitFolio.Api.Client.Exceptions
{
    /// <summary>
    /// Exception thrown when API returns a validation error (400 Bad Request).
    /// </summary>
    public class ApiValidationException : ApiException
    {
        /// <summary>
        /// Gets the validation errors from the API response.
        /// </summary>
        public IDictionary<string, string[]>? ValidationErrors { get; }

        public ApiValidationException(
            string message,
            HttpStatusCode statusCode,
            string? responseContent = null,
            string? requestUri = null,
            IDictionary<string, string[]>? validationErrors = null,
            Exception? innerException = null)
            : base(message, statusCode, responseContent, requestUri, innerException)
        {
            ValidationErrors = validationErrors;
        }
    }
}


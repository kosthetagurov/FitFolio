using FitFolio.Api.Client.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FitFolio.Api.Client
{
    /// <summary>
    /// Base class for API clients providing common HTTP operations and error handling.
    /// </summary>
    public abstract class ApiClientBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientBase"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client instance (managed by IHttpClientFactory).</param>
        /// <param name="logger">The logger instance.</param>
        protected ApiClientBase(
            HttpClient httpClient,
            ILogger logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
        }

        /// <summary>
        /// Gets the HTTP client instance.
        /// </summary>
        protected HttpClient HttpClient => _httpClient;

        /// <summary>
        /// Sends a GET request and deserializes the response.
        /// </summary>
        protected async Task<T> GetAsync<T>(
            string requestUri, 
            CancellationToken cancellationToken = default) where T : class
        {
            _logger.LogDebug("GET {RequestUri}", requestUri);

            try
            {
                var response = await _httpClient.GetAsync(requestUri, cancellationToken);
                return await HandleResponseAsync<T>(response, requestUri, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for GET {RequestUri}", requestUri);
                throw new ApiException(
                    $"HTTP request failed: {ex.Message}",
                    HttpStatusCode.ServiceUnavailable,
                    requestUri: requestUri,
                    innerException: ex);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timeout for GET {RequestUri}", requestUri);
                throw new ApiException(
                    "Request timeout",
                    HttpStatusCode.RequestTimeout,
                    requestUri: requestUri,
                    innerException: ex);
            }
        }

        /// <summary>
        /// Sends a POST request with JSON content and deserializes the response.
        /// </summary>
        protected async Task<T> PostAsync<T>(
            string requestUri,
            object? content,
            CancellationToken cancellationToken = default) where T : class
        {
            _logger.LogDebug("POST {RequestUri}", requestUri);

            try
            {
                var response = await _httpClient.PostAsJsonAsync(requestUri, content, _jsonOptions, cancellationToken);
                return await HandleResponseAsync<T>(response, requestUri, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for POST {RequestUri}", requestUri);
                throw new ApiException(
                    $"HTTP request failed: {ex.Message}",
                    HttpStatusCode.ServiceUnavailable,
                    requestUri: requestUri,
                    innerException: ex);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timeout for POST {RequestUri}", requestUri);
                throw new ApiException(
                    "Request timeout",
                    HttpStatusCode.RequestTimeout,
                    requestUri: requestUri,
                    innerException: ex);
            }
        }

        /// <summary>
        /// Sends a POST request with JSON content without expecting a response body.
        /// </summary>
        protected async Task PostAsync(
            string requestUri,
            object? content,
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("POST {RequestUri}", requestUri);

            try
            {
                var response = await _httpClient.PostAsJsonAsync(requestUri, content, _jsonOptions, cancellationToken);
                await EnsureSuccessStatusCodeAsync(response, requestUri, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for POST {RequestUri}", requestUri);
                throw new ApiException(
                    $"HTTP request failed: {ex.Message}",
                    HttpStatusCode.ServiceUnavailable,
                    requestUri: requestUri,
                    innerException: ex);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timeout for POST {RequestUri}", requestUri);
                throw new ApiException(
                    "Request timeout",
                    HttpStatusCode.RequestTimeout,
                    requestUri: requestUri,
                    innerException: ex);
            }
        }

        /// <summary>
        /// Sends a PUT request with JSON content and deserializes the response.
        /// </summary>
        protected async Task<T> PutAsync<T>(
            string requestUri,
            object? content,
            CancellationToken cancellationToken = default) where T : class
        {
            _logger.LogDebug("PUT {RequestUri}", requestUri);

            try
            {
                var response = await _httpClient.PutAsJsonAsync(requestUri, content, _jsonOptions, cancellationToken);
                return await HandleResponseAsync<T>(response, requestUri, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for PUT {RequestUri}", requestUri);
                throw new ApiException(
                    $"HTTP request failed: {ex.Message}",
                    HttpStatusCode.ServiceUnavailable,
                    requestUri: requestUri,
                    innerException: ex);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timeout for PUT {RequestUri}", requestUri);
                throw new ApiException(
                    "Request timeout",
                    HttpStatusCode.RequestTimeout,
                    requestUri: requestUri,
                    innerException: ex);
            }
        }

        /// <summary>
        /// Sends a PUT request with JSON content without expecting a response body.
        /// </summary>
        protected async Task PutAsync(
            string requestUri,
            object? content,
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("PUT {RequestUri}", requestUri);

            try
            {
                var response = await _httpClient.PutAsJsonAsync(requestUri, content, _jsonOptions, cancellationToken);
                await EnsureSuccessStatusCodeAsync(response, requestUri, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for PUT {RequestUri}", requestUri);
                throw new ApiException(
                    $"HTTP request failed: {ex.Message}",
                    HttpStatusCode.ServiceUnavailable,
                    requestUri: requestUri,
                    innerException: ex);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timeout for PUT {RequestUri}", requestUri);
                throw new ApiException(
                    "Request timeout",
                    HttpStatusCode.RequestTimeout,
                    requestUri: requestUri,
                    innerException: ex);
            }
        }

        /// <summary>
        /// Sends a DELETE request without expecting a response body.
        /// </summary>
        protected async Task DeleteAsync(
            string requestUri,
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("DELETE {RequestUri}", requestUri);

            try
            {
                var response = await _httpClient.DeleteAsync(requestUri, cancellationToken);
                await EnsureSuccessStatusCodeAsync(response, requestUri, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for DELETE {RequestUri}", requestUri);
                throw new ApiException(
                    $"HTTP request failed: {ex.Message}",
                    HttpStatusCode.ServiceUnavailable,
                    requestUri: requestUri,
                    innerException: ex);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timeout for DELETE {RequestUri}", requestUri);
                throw new ApiException(
                    "Request timeout",
                    HttpStatusCode.RequestTimeout,
                    requestUri: requestUri,
                    innerException: ex);
            }
        }

        /// <summary>
        /// Handles HTTP response and deserializes the content.
        /// </summary>
        private async Task<T> HandleResponseAsync<T>(
            HttpResponseMessage response,
            string requestUri,
            CancellationToken cancellationToken) where T : class
        {
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions, cancellationToken);
                    if (result == null)
                    {
                        throw new ApiException(
                            "Response deserialization returned null",
                            response.StatusCode,
                            requestUri: requestUri);
                    }
                    return result;
                }
                catch (JsonException ex)
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken);
                    _logger.LogError(ex, "Failed to deserialize response from {RequestUri}. Content: {Content}", 
                        requestUri, content);
                    throw new ApiException(
                        $"Failed to deserialize response: {ex.Message}",
                        response.StatusCode,
                        responseContent: content,
                        requestUri: requestUri,
                        innerException: ex);
                }
            }

            await ThrowApiExceptionAsync(response, requestUri, cancellationToken);
            // This line will never be reached but is required for compilation
            throw new InvalidOperationException("Unreachable code");
        }

        /// <summary>
        /// Ensures the response has a success status code.
        /// </summary>
        private async Task EnsureSuccessStatusCodeAsync(
            HttpResponseMessage response,
            string requestUri,
            CancellationToken cancellationToken)
        {
            if (!response.IsSuccessStatusCode)
            {
                await ThrowApiExceptionAsync(response, requestUri, cancellationToken);
            }
        }

        /// <summary>
        /// Creates and throws an appropriate API exception based on the response.
        /// </summary>
        private async Task ThrowApiExceptionAsync(
            HttpResponseMessage response,
            string requestUri,
            CancellationToken cancellationToken)
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            
            _logger.LogWarning(
                "API request failed. Status: {StatusCode}, URI: {RequestUri}, Response: {Content}",
                response.StatusCode, requestUri, content);

            // Handle validation errors (400 Bad Request)
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                try
                {
                    var validationErrors = JsonSerializer.Deserialize<Dictionary<string, string[]>>(
                        content, _jsonOptions);
                    
                    throw new ApiValidationException(
                        "Validation failed",
                        response.StatusCode,
                        responseContent: content,
                        requestUri: requestUri,
                        validationErrors: validationErrors);
                }
                catch (JsonException)
                {
                    // If we can't parse validation errors, fall through to generic exception
                }
            }

            var message = response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => "Authentication required",
                HttpStatusCode.Forbidden => "Access forbidden",
                HttpStatusCode.NotFound => "Resource not found",
                HttpStatusCode.Conflict => "Resource conflict",
                HttpStatusCode.InternalServerError => "Server error occurred",
                HttpStatusCode.ServiceUnavailable => "Service unavailable",
                _ => $"API request failed with status {(int)response.StatusCode}"
            };

            throw new ApiException(message, response.StatusCode, content, requestUri);
        }
    }
}

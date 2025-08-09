using System.Text.Json;

namespace FitFolio.Api.Client
{
    public abstract class ApiClientBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Uri _baseAddress;

        protected ApiClientBase(IHttpClientFactory httpClientFactory, Uri baseAddress)
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }

            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            _baseAddress = baseAddress;
            _httpClientFactory = httpClientFactory;
        }

        protected HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = _baseAddress;
            return client;
        }

        protected async Task<string> ResponseAsStringAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(responseMessage.StatusCode.ToString());
            }

            var resposne = await responseMessage.Content.ReadAsStringAsync();
            return resposne;
        }

        protected T? ResponseStringAsType<T>(string response) where T : class
        {
            var parsedValue = JsonSerializer.Deserialize<T>(response);
            return parsedValue;
        }
    }
}

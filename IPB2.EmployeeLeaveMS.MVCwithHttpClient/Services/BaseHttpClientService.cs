using System.Net.Http.Json;
using System.Text.Json;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services
{
    public abstract class BaseHttpClientService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;

        protected BaseHttpClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["WebApiSettings:BaseUrl"] ?? throw new ArgumentNullException("WebApiSettings:BaseUrl is missing");
        }

        protected async Task<TResponse?> GetAsync<TResponse>(string endpoint)
        {
            return await _httpClient.GetFromJsonAsync<TResponse>($"{_baseUrl}{endpoint}");
        }

        protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}{endpoint}", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        protected async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}{endpoint}", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        protected async Task<TResponse?> DeleteAsync<TResponse>(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }
        
        protected async Task<TResponse?> DeleteWithBodyAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
             // HttpClient.DeleteAsync doesn't support body easily, using SendAsync
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = JsonContent.Create(request),
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseUrl}{endpoint}")
            };
            var response = await _httpClient.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }
    }
}

using System.Text.Json;

namespace weatherweb
{
    public class DataApiService : IDataApiService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public DataApiService(IConfiguration configuration, HttpClient httpClient) 
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        { 
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{_httpClient.BaseAddress}WeatherForecast");
            var response = await _httpClient.SendAsync( request );
            string weatherForecastString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(weatherForecastString);
        }
    }
}

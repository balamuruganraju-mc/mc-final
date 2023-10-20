using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using simpleWebApp;

namespace simpleWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async void OnGet()
    {
        try
            {            
                HttpClient _httpClient = new HttpClient();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://20.204.200.23:8080/WeatherForecast");
                var response = _httpClient.Send( request );
                string weatherForecastString = await response.Content.ReadAsStringAsync();
                ViewData["pagedata"] = $"Response: {weatherForecastString}";
                IList<WeatherForecast> WeatherForecastLists = JsonSerializer.Deserialize<IList<WeatherForecast>>(weatherForecastString);
                ViewData["WeatherData"] = WeatherForecastLists;
            }
            catch
            {
                ViewData["pagedata"] = "Error occured";
            }
    }
}

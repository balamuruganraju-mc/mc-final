using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace weatherweb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDataApiService _iDataApiService;
        public IEnumerable<WeatherForecast> WeatherForecast { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDataApiService iDataApiService)
        {
            _logger = logger;
            _iDataApiService = iDataApiService;
        }

        public async Task OnGet()
        {
            WeatherForecast = await _iDataApiService.GetWeatherForecastsAsync();
        }
    }
}
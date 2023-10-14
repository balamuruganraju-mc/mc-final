namespace weatherweb
{
    public interface IDataApiService 
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
    }
}

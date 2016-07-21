using System.Collections.Generic;

namespace WeatherForecastApplication.Models
{
    public interface IForecast
    {
        City City { get; set; }
        int Cnt { get; set; }
        string Cod { get; set; }
        List<List> List { get; set; }
        double Message { get; set; }
    }
}
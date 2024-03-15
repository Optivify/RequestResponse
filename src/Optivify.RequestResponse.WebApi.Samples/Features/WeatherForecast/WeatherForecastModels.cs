using System.ComponentModel.DataAnnotations;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast
{
    #region Get Weather Forecast

    public class GetWeatherForecastInput
    {
        [Required]
        public string? City { get; set; }
    }

    public class GetWeatherForecastResponse : DataResponse<WeatherForecast?>
    {
    }

    public class GetWeatherForecastRequest : Request<GetWeatherForecastInput, GetWeatherForecastResponse>
    {
    }

    #endregion

    #region List Weather Forecast

    public class ListWeatherForecastInput : ListInput
    {
    }

    public class ListWeatherForecastResponse : PagedEnumerableResponse<WeatherForecast?>
    {
    }

    public class ListWeatherForecastRequest : Request<ListWeatherForecastInput, ListWeatherForecastResponse>
    {
    }

    #endregion
}

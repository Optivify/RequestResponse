using Optivify.RequestResponse.Responses;
using System.ComponentModel.DataAnnotations;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast
{
    #region Get Weather Forecast

    public class GetWeatherForecastInput
    {
        [Required]
        public string? City { get; set; }
    }

    public class GetWeatherForecastResponse : SingleItemResponse<WeatherForecast?>
    {
    }

    public class GetWeatherForecastRequest : ResultRequest<GetWeatherForecastInput, GetWeatherForecastResponse>
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

    public class ListWeatherForecastRequest : ResultRequest<ListWeatherForecastInput, ListWeatherForecastResponse>
    {
    }

    #endregion
}

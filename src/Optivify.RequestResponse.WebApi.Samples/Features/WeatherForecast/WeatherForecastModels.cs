using System.ComponentModel.DataAnnotations;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast
{
    #region Get Weather Forecast

    public record GetWeatherForecastInput
    {
        [Required]
        public string? City { get; init; }
    }

    public record GetWeatherForecastResponse : DataResponse<WeatherForecast?>
    {
    }

    public record GetWeatherForecastRequest : Request<GetWeatherForecastInput, GetWeatherForecastResponse>
    {
    }

    #endregion

    #region List Weather Forecast

    public record ListWeatherForecastInput : ListInput
    {
    }

    public record ListWeatherForecastResponse : PagedEnumerableResponse<WeatherForecast?>
    {
    }

    public record ListWeatherForecastRequest : Request<ListWeatherForecastInput, ListWeatherForecastResponse>
    {
    }

    #endregion
}

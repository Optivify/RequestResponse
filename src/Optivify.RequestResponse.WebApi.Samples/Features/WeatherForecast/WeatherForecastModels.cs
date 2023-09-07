using System.ComponentModel.DataAnnotations;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast;

public record GetWeatherForecastInput
{
    [Required]
    public string? City { get; init; }
}

public record GetWeatherForecastResponse : DataResponse<WeatherForecast?>;

public record GetWeatherForecastRequest : ResultRequest<GetWeatherForecastInput, GetWeatherForecastResponse>;


public record ListWeatherForecastInput : ListInput;

public record ListWeatherForecastResponse : PagedEnumerableResponse<WeatherForecast?>;

public record ListWeatherForecastRequest : ResultRequest<ListWeatherForecastInput, ListWeatherForecastResponse>;
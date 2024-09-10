using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast;

public record GetWeatherForecastInput
{
    [Required]
    [NotNull]
    public string? City { get; init; }
}

public record GetWeatherForecastResponse : Response<WeatherForecast>;

public record GetWeatherForecastRequest : Request<GetWeatherForecastInput, GetWeatherForecastResponse>;

public record ListWeatherForecastInput : ListInput;

public record ListWeatherForecastResponse : PagedResponse<WeatherForecast>;

public record ListWeatherForecastRequest : Request<ListWeatherForecastInput, ListWeatherForecastResponse>;
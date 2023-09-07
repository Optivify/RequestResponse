using Optivify.RequestResponse;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast;

public class WeatherForecastRequestHandler :
    IResultRequestHandler<GetWeatherForecastRequest, GetWeatherForecastResponse?>,
    IResultRequestHandler<ListWeatherForecastRequest, ListWeatherForecastResponse?>
{
    private static string[] Cities = new[] { "London", "Paris", "Amsterdam", "Berlin", "Cape Town", "Stockholm", "Tokyo", "Seoul", "Hanoi", "San Francisco" };

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    private WeatherForecast GetWeatherForecast(string city, DateTime dateTime)
    {
        return new WeatherForecast
        {
            City = city,
            DateTime = dateTime,
            TemperatureC = Random.Shared.Next(10, 40),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }

    public async Task<Result<GetWeatherForecastResponse?>> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Data);

        var input = request.Data;

        var city = Cities.FirstOrDefault(x => string.Equals(x, input.City, StringComparison.OrdinalIgnoreCase));

        if (city is null)
        {
            return Result.NotFound("City not found.");
        }

        var response = new GetWeatherForecastResponse
        {
            Data = this.GetWeatherForecast(city, DateTime.UtcNow)
        };

        return response;
    }

    public async Task<Result<ListWeatherForecastResponse?>> Handle(ListWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var input = request.Data;

        if (input is null)
        {
            return Result.Invalid(new ValidationError { ErrorMessage = "Invalid input." });
        }

        var now = DateTime.UtcNow;
        var response = new ListWeatherForecastResponse
        {
            Data = Cities.Skip(input.Skip).Take(input.Take).Select(x => this.GetWeatherForecast(x, now)),
            Pagination = new PaginationData
            {
                Page = input.Page,
                ItemsPerPage = input.ItemsPerPage,
                TotalCount = Cities.Count()
            }
        };

        return Result.Success(response);
    }
}

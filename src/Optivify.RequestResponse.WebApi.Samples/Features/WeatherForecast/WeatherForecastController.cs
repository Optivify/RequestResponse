using Microsoft.AspNetCore.Mvc;
using Optivify.RequestResponse.AspNetCore;
using Optivify.ServiceResult.AspNetCore;

namespace Optivify.RequestResponse.WebApi.Samples.Features.WeatherForecast
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetWeatherForecastInput data)
        {
            var request = new GetWeatherForecastRequest { Data = data };
            var result = await this.DispatchAsync(request);

            return result.ToActionResult(this);
        }

        [HttpGet("List")]
        public async Task<IActionResult> List([FromQuery] ListWeatherForecastInput data)
        {
            var request = new ListWeatherForecastRequest { Data = data };
            var result = await this.DispatchAsync(request);

            return result.ToActionResult(this);
        }
    }
}
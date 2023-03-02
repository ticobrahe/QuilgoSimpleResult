using Microsoft.AspNetCore.Mvc;
using SimpleResult.Models;
using SimpleResult.Services;

namespace SimpleResult.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            var result = _weatherForecastService.GetWeatherForecasts();
            var response = new BaseResponse<IEnumerable<WeatherForecast>>()
            {
                Message = "Data retreived successfully",
                Success = true,
                Data = result
            };

            return Ok(response);
        }
    }
}
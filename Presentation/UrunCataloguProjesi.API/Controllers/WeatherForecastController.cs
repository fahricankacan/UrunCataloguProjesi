using Microsoft.AspNetCore.Mvc;
using UrunCataloguProjesi.Application.Repostories;

namespace UrunCataloguProjesi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWorkRepository)
        {
            _logger = logger;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("sa")]
        public IActionResult sa()
        {
            //_unitOfWorkRepository.BrandWriteRepository.Add(new Domain.Entities.Brand
            //{
            //    Name = "Nescafe"
            //});
            //_unitOfWorkRepository.Commit();

            var result = _unitOfWorkRepository.BrandReadRepository.GetAll();
            return Ok(result);
        }
    }
}
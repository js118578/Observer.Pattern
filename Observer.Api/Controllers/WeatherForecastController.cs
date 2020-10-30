using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Observer.Models;
using Observer.Core;

namespace Observer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPublisher _publisher;
        public WeatherForecastController(IPublisher publisher, ILogger<WeatherForecastController> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPut]
        public async Task<bool> Add(Event e)
        {
            return await _publisher.Add(e);
        }
        [HttpPost]
        public async Task<Event> Update(Event e)
        {
            return await _publisher.Update(e);
        }
        [HttpDelete]
        public async Task<bool> Delete(Event e)
        {
            return await _publisher.Delete(e);
        }
    }
}

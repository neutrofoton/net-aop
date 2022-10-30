using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using NetAOP.WebApi.Aop;
using NetAOP.WebApi.Interceptors;
using NetAOP.WebApi.Model;
using NetAOP.WebApi.Services;
using NetAOP.WebApi.Services.Impl;

namespace NetAOP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<HelloService> _logger;
        private readonly IHelloService helloService;

        public WeatherForecastController(ILogger<HelloService> logger, IHelloService helloService)
        {
            _logger = logger;
            this.helloService = helloService;
        }

        

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            string note = this.helloService.Hi();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Note = note
            })
            .ToArray();

            return result;
        }

        [HttpGet("GetWeatherForecastAsync")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
        {
            string note = await this.helloService.HiAsync();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Note = note
            })
            .ToArray();

            return await Task.FromResult(result);
        }

        [HttpGet("DoMultiInterceptors")]
        public IEnumerable<WeatherForecast> DoMultiInterceptors()
        {
            string note = ProxyFactory.GetProxiedInstance<IHelloService>(
                    new ProxyGenerator(),
                    new HelloService(_logger), 
                    new IInterceptor[]
                    {
                        //the order on this array defines the interceptor call order.
                        new ConsoleAInterceptor(_logger),
                        new ConsoleBInterceptor(_logger)
                        
                    })!.Hi();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Note = note
            })
            .ToArray();

            return result;
        }

        [HttpGet("DoClassInterceptor")]
        public string DoClassInterceptor()
        {
            var person = ProxyFactory.GetProxiedInstance<Person>(
                    new ProxyGenerator(),
                    new Person() { Id=1, Name="my name"},
                    new IInterceptor[]
                    {
                        new ModelInterceptor()

                    });

            person.Name = "My Name modified";

            foreach(var change in person.PropertyChangeList)
            {
                this._logger.LogDebug($"{change.Field}");
            }

            return "done";
        }
    }
}
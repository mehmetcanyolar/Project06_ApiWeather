using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project06_ApiWeather.Context;
using Project06_ApiWeather.Entities;

namespace Project06_ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context = new WeatherContext();
        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Citys.ToList();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateWeatherCity(City city)
        {
            context.Citys.Add(city);
            context.SaveChanges();
            return Ok("The city has been added successfully");
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id) 
        {
                var values= context.Citys.Find(id);
                context.Citys.Remove(values);
                context.SaveChanges();
                return Ok("The city has been removed");


        }
        [HttpPut]
        public IActionResult UpdateWeatherCity(City city ) 
        {
            var values= context.Citys.Find(city.CityId);
            values.CityName = city.CityName;
            values.Temperature = city.Temperature;
            values.Country = city.Country;
            values.Detail = city.Detail;
            context.SaveChanges();
         
            return Ok("The city has been successfully updated");
        }

        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIdWeatherCity(int id) { var value = context.Citys.Find(id);
            return Ok(value);
        }
        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        { 
            var values = context.Citys.Count();
            return Ok(values);
        }

        [HttpGet("MaxTemperatureCity")]

        public IActionResult MaxTemperatureCity()
        {
            var value = context.Citys.OrderByDescending(x=>x.Temperature).Select(y=> y.Temperature).FirstOrDefault() + " " +
             context.Citys.OrderByDescending(z=>z.Temperature).Select(t=> t.CityName).FirstOrDefault();
            return Ok(value);
           
        }
        [HttpGet("MinTemperatureCity")]
        public IActionResult MinTemperatureCity()
        {
            var value = context.Citys.OrderBy(x => x.Temperature).Select(y => y.Temperature).FirstOrDefault() + " " +
             context.Citys.OrderBy(z => z.Temperature).Select(t => t.CityName).FirstOrDefault();
            return Ok(value);

        }

    }
}

using Example.ApplicationLayer.Interfaces;
using Example.ApplicationLayer.Service;
using Example.DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetCityList()
        {
           // var city = new CityService();
           //return Ok(city.GetCityList);
           var city = _cityService.GetCityList();
            return Ok(city);
        }
    }
}

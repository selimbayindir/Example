
using Example.ApplicationLayer.Interfaces;
using Example.ApplicationLayer.Service;
using Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistrictController : Controller
    {
        public readonly IDistrictService districtService;

        public DistrictController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }

        [HttpGet]
        public IActionResult GetDistrictList()
        {
            //var districtList = new DistrictService();
            //return Ok(districtList.GetDistrictList);

            var district = districtService.GetDistrictList();
            return Ok(district);

        }

        [HttpGet("{cityCode}")]
 
        public IActionResult GetDistrictListByCityCode(string cityCode)
        {
            //var districtList = new DistrictService();

            //var result = districtList.GetDistrictListByCityCode(cityCode);
            //return Ok(result);
            return Ok(districtService.GetDistrictListByCityCode(cityCode));
        }
    }
}

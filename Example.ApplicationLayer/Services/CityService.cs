using Example.ApplicationLayer.Interfaces;
using Example.DomainLayer.Entities;

namespace Example.ApplicationLayer.Service
{

    public class CityService : ICityService
    { 
        //public readonly List<City> CityList = new List<City>()
        //{
        //  new City() { CityCode="IST" ,Name ="Istanbul" },
        //  new City() { CityCode="Ank" ,Name ="Ankara" },
        //};

        //public List<City> GetCityList()
        //{
        //    return CityList;
        //}

        private readonly ICityService _cityService;

        public CityService(ICityService cityService)
        {
            _cityService = cityService;
        }

        public List<City> GetCityList()
        {
           var cityList = _cityService.GetCityList();
            return cityList;
        }
    }
}

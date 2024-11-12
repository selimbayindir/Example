using Example.ApplicationLayer.Interfaces;
using Example.DatabaseLayer;
using Example.Models;
using System.Collections.Generic;
using System.Linq;

namespace Example.ApplicationLayer.Service
{
    public class DistrictService : IDistrictService
    {
        //public readonly List<District> Districts = new List<District>()
        //{
        //  new District() { CityCode="Ist" ,Name ="Sancaktepe" },
        //  new District() { CityCode="Ist" ,Name ="Ataşehir" },
        //  new District() { CityCode="Ank" ,Name ="Pursaklar" },
        //};

        //public List<District> GetDistrictList()
        //{
        //    return (Districts);
        //}


        //public List<District> GetDistrictListByCityCode(string cityCode)
        //{
        //    var result = Districts.Where(p => p.CityCode == cityCode).ToList();
        //    return (result);
        //}
        private readonly ExampleAppContext _context;

        public DistrictService(ExampleAppContext context)
        {
            _context = context;
        }

        public List<District> GetDistrictList()
        {
            return _context.di
        }

        public List<District> GetDistrictListByCityCode(string cityCode)
        {
            var result = _context.Districts.Where(p => p.CityCode == cityCode).ToList();
            return result;
        }
    }
}

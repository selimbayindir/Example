using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationLayer.Interfaces
{
    public interface IDistrictService
    {
        List<District> GetDistrictList();
        List<District> GetDistrictListByCityCode(string cityCode);
    }
}

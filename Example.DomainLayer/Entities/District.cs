using Example.DomainLayer.Entities;
using Example.DomainLayer.Shared;

namespace Example.Models
{
    public class District
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public DataStatus Status { get; set; }

        public string Name { get; set; }

    }
}

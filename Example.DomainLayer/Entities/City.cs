using Example.DomainLayer.Shared;
using Example.Models;

namespace Example.DomainLayer.Entities
{
    public class City
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DataStatus Status { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}

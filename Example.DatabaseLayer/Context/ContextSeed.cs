using Example.DomainLayer.Entities;
using Example.DomainLayer.Shared;
using Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Example.DatabaseLayer.Context
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<City>().HasData(new City
            {
                Id = 1,
                Name = "Istanbul"
            });
            // District verisini ekliyoruz ve City ile ilişkilendiriyoruz
            builder.Entity<District>().HasData(
                new District
                {
                    Id = 1,
                    CityId = 1,  // İstanbul ile ilişkilendiriyoruz
                    Name = "Sancaktepe",
                    Status = DataStatus.Active // Durum örneği
                }
            );
        }
    }
}

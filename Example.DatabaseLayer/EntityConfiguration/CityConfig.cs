using Example.DomainLayer.Entities;
using Example.DomainLayer.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DatabaseLayer.EntityConfiguration
{
    internal class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
           builder.ToTable(nameof(City),"dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(DataStatus.Active);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

        }
    }
}

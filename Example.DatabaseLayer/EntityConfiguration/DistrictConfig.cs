using Example.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Models;
using Example.DomainLayer.Shared;

namespace Example.DatabaseLayer.EntityConfiguration
{
    internal class DistrictConfig : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable(nameof(District), "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(DataStatus.Active);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.HasOne(s=>s.City).WithMany(s=>s.Districts).HasForeignKey(s => s.CityId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            // Cascade : City Tablosunda Silinen veri olduğunda Tüm District  bilgileride silinir
            //NoAction olarak ayarlarsan bu şekilde olmaz
        }

    }
}

using Example.DatabaseLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DatabaseLayer
{
    public class ExampleAppContext : DbContext
    {
        public ExampleAppContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleAppContext).Assembly).Seed();
       
    }
}

using MVC5App.DAL.Configuration;
using MVC5App.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Context
{
    public class CountryContext : DbContext
    {
        public CountryContext() : base ("name=MVC5AppDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryInfoConfiguration());
        }

        public DbSet<CountryInfo> CountryInfos { get; set; }
    }
}

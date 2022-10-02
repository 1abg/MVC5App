using MVC5App.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Configuration
{
    public class CountryInfoConfiguration : EntityTypeConfiguration<CountryInfo>
    {
        public CountryInfoConfiguration()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(x => x.CapitalCity)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(x => x.Currency)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(x => x.ShortCode)
                .IsRequired()
                .HasMaxLength(5);
        }
    }
}
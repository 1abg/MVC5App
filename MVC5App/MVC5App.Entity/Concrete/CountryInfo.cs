using MVC5App.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.Entity.Concrete
{
    public class CountryInfo : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public string ShortCode { get; set; }
        public string Currency { get; set; }
    }
}
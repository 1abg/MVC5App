using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.Core.DTOs.Concrete
{
    public class CountryAddDto
    {
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public string ShortCode { get; set; }
        public string Currency { get; set; }
    }
}

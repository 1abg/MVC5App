using AutoMapper;
using MVC5App.BLL.CountryInfoService;
using MVC5App.Core.DTOs.Concrete;
using MVC5App.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<tCountryCodeAndName, CountryListDto>()
                .ForMember(o => o.ISOCode, d => d.MapFrom(s => s.sISOCode))
                .ForMember(o => o.Name, d => d.MapFrom(s => s.sName));

            CreateMap<CountryAddDto, CountryInfo>();
        }
    }
}

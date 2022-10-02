using Autofac;
using AutoMapper;
using MVC5App.BLL.CountryInfoService;
using MVC5App.BLL.DependencyResolvers.Autofac;
using MVC5App.Core.DTOs.Concrete;
using MVC5App.DAL.Abstract;
using MVC5App.DAL.Abstract.UnitOfWork;
using MVC5App.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.BLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private CountryInfoServiceSoapTypeClient _client;


        public CountryService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacBusinessModule>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                _mapper = scope.Resolve<IMapper>();
                _unitOfWork = scope.Resolve<IUnitOfWork>();
            }

            _client =
                 new CountryInfoServiceSoapTypeClient(new BasicHttpBinding { MaxReceivedMessageSize = 9000000 },
                                                      new EndpointAddress(
                                                          "http://www.oorsprong.org/websamples.countryinfo/CountryInfoService.wso"));


        }

        public List<CountryListDto> GetListOfCountryNamesByCode()
        {
            //var client =
            //     new CountryInfoServiceSoapTypeClient(new BasicHttpBinding { MaxReceivedMessageSize = 9000000 },
            //                                          new EndpointAddress(
            //                                              "http://www.oorsprong.org/websamples.countryinfo/CountryInfoService.wso"));

            var countries = _client.ListOfCountryNamesByCode().ToList();
            return _mapper.Map<List<tCountryCodeAndName>, List<CountryListDto>>(countries);
        }


        public CountryInfoByServiceDto GetCountryInfoByName(string name)
        {
            var isoCode = _client.CountryISOCode(name);
            var capitalCity = _client.CapitalCity(isoCode);
            var currency = _client.CountryCurrency(isoCode);

            return new CountryInfoByServiceDto
            {
                CapitalCity = capitalCity,
                Currency = $"{currency.sISOCode}({currency.sName})",
                ISOCode = isoCode
            };
        }


        

        public void AddCountry(CountryAddDto countryAddDto)
        {
            var country = _mapper.Map<CountryAddDto, CountryInfo>(countryAddDto);
            _unitOfWork.countryInfoDal.Add(country);
            _unitOfWork.Commit();
        }





    }
}

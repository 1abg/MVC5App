using MVC5App.Core.DTOs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MVC5App.BLL
{
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        List<CountryListDto> GetListOfCountryNamesByCode();

        [OperationContract]
        void AddCountry(CountryAddDto countryAddDto);

        [OperationContract]
        CountryInfoByServiceDto GetCountryInfoByName(string name);
    }

   
}

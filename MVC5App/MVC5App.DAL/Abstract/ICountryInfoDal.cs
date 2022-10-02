using MVC5App.DAL.Abstract.Repository;
using MVC5App.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Abstract
{
    public interface ICountryInfoDal : IGenericRepository<CountryInfo>
    {
    }
}

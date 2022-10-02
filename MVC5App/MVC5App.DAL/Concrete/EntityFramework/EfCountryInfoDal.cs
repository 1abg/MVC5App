using MVC5App.DAL.Abstract;
using MVC5App.DAL.Concrete.EntityFramework.Repository;
using MVC5App.DAL.Context;
using MVC5App.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Concrete.EntityFramework
{
    public class EfCountryInfoDal : EfGenericRepository<CountryInfo>, ICountryInfoDal
    {
        public EfCountryInfoDal(CountryContext context) : base(context)
        {
        }
    }
}

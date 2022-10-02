using MVC5App.DAL.Abstract;
using MVC5App.DAL.Abstract.UnitOfWork;
using MVC5App.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Concrete.EntityFramework.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly CountryContext _countryContext;
        public ICountryInfoDal countryInfoDal { get; private set; }

        public EfUnitOfWork(CountryContext countryContext)
        {
            _countryContext = countryContext;
            countryInfoDal = countryInfoDal ?? new EfCountryInfoDal(_countryContext);
        }


        public int Commit()
        {
            return _countryContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _countryContext.SaveChangesAsync();
        }
    }
}

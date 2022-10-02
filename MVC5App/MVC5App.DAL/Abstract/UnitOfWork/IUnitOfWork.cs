using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.DAL.Abstract.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICountryInfoDal countryInfoDal { get; }

        Task<int> CommitAsync();
        int Commit();
    }
}

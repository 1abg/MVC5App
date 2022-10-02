using Autofac;
using AutoMapper;
using MVC5App.BLL.Mapping;
using MVC5App.DAL.Abstract;
using MVC5App.DAL.Abstract.Repository;
using MVC5App.DAL.Abstract.UnitOfWork;
using MVC5App.DAL.Concrete.EntityFramework;
using MVC5App.DAL.Concrete.EntityFramework.Repository;
using MVC5App.DAL.Concrete.EntityFramework.UnitOfWork;
using MVC5App.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5App.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EfGenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //builder.RegisterType<EfCountryInfoDal>().As<ICountryInfoDal>();

            builder.Register<IMapper>((comp) => new Mapper(new MapperConfiguration(cfg =>
            {
                // entity maps
                cfg.AddProfile<MappingProfile>();
            })));
        }
    }
}

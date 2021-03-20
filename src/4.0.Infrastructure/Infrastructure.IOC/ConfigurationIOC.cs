using Autofac;
using Application.Interfaces;
using Application.Services;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Services;
using Domain.Entities;
using Infrastructure.Adapter.Interfaces;
using Infrastructure.Adapter.Map;
using Infrastructure.Repository;

namespace Infrastructure.IOC
{
    public class ConfigurationIOC
    {
        public static void  Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClinicUnitApplicationService>().As<IClinicUnitApplicationService>();    

            builder.RegisterType<ClinicUnitService>().As<IClinicUnitService>();

            builder.RegisterType<Repository<ClinicUnit>>().As<IRepository<ClinicUnit>>();
            builder.RegisterType<Repository<Schedule>>().As<IRepository<Schedule>>();
            builder.RegisterType<Repository<User>>().As<IRepository<User>>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<ClinicUnitMapper>().As<IClinicUnitMapper>();
        }
    }
}
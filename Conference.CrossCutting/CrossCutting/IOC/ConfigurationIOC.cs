using Autofac;
using AutoMapper;
using Conferencia.Aplication.Interface;
using Conferencia.Aplication.Mappers;
using Conferencia.Aplication.mapping;
using Conferencia.Aplication.Servicos;
using Conferencia.Domain.IRepository;
using Conferencia.Infra.Repository;

namespace Conferencia.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UploadExcelService>().As<IUploadExcelService>();
            builder.RegisterType<OrderMapping>().As<IOrderMapping>();
            builder.RegisterType<RepositoryOrder>().As<IRepositoryOrder>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToDto());
                cfg.AddProfile(new DtoToModel());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}

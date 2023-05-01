using Autofac;
using FilmLibrary.Core.Repositories;
using FilmLibrary.Core.Services;
using FilmLibrary.Repoository;
using FilmLibrary.Repoository.Repositories;
using FilmLibrary.Repoository.UnitOfWorks;
using FilmLibrary.Service.Mapping;
using FilmLibrary.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace FilmLibrary.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericService<>))
                .As(typeof(IGenericService<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<UnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

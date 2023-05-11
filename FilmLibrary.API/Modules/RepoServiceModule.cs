using Autofac;
using FilmLibrary.Core.Repositories;
using FilmLibrary.Core.Services;
using FilmLibrary.Core.UnitOfWorks;
using FilmLibrary.Repository;
using FilmLibrary.Repository.Repositories;
using FilmLibrary.Repository.UnitOfWorks;
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

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericService<>))
                .As(typeof(IGenericService<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            //    .Where(x => x.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<FilmService>().As<IFilmService>();
            builder.RegisterType<StudioService>().As<IStudioService>();
            builder.RegisterType<PersonService>().As<IPersonService>();


        }
    }
}

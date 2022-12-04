using Autofac;
using Ebebul.Core.Repositories;
using Ebebul.Core.Services;
using Ebebul.Core.UnitofWorks;
using Ebebul.Repository;
using Ebebul.Repository.Repositories;
using Ebebul.Repository.UnitofWorks;
using Ebebul.Service.Mapping;
using Ebebul.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace Ebebul.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            // builder.Services.AddScoped<IUnitofWork, UnitofWork>(); => Program.cs
            builder.RegisterType<UnitofWork>().As<IUnitofWork>();

            var apiAssembly =Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            //builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            //InstancePerLifetimeScope => Scope
            //InstancePerDependency => Transient

            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository
            //builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.Services.AddScoped<ICategoryService, CategoryService>();
            //builder.Services.AddScoped<IUserService, UserService>();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
               
        }
    }
}

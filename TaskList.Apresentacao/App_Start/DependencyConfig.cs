using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI;
using TaskList.Modelo.Injetor;

namespace TaskList.Apresentacao.App_Start
{
    public static class DependencyConfig
    {
        public static IContainer RegisterDependencyResolvers()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterDependencyMappingDefaults(builder);
            IoC.RegisterBuilder(builder);
            IContainer container = builder.Build();
            // Set Up MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterDependencyMappingDefaults(ContainerBuilder builder)
        {
            Assembly coreAssembly = Assembly.GetAssembly(typeof(IStateManager));
            Assembly webAssembly = Assembly.GetAssembly(typeof(MvcApplication));
            builder.RegisterAssemblyTypes(coreAssembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(webAssembly);
            builder.RegisterModule(new AutofacWebTypesModule());
        }
    }
}
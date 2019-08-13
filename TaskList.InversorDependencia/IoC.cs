using Autofac;
using TaskList.Data.Repositorios;
using TaskList.Dominio;

namespace TaskList.Modelo.Injetor
{
    public static class IoC
    {
        public static T Resolve<T>()
        {
            return RegisterBuilder(new ContainerBuilder()).Build().Resolve<T>();
        }

        public static ContainerBuilder RegisterBuilder(ContainerBuilder builder)
        {
            RepositorioRegistrador.Registrar(ref builder);
            ServicoRegistrador.Registrar(ref builder);

            return builder;
        }
    }
}

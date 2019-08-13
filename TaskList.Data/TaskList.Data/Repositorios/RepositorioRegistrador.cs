using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskList.Data.Repositorios
{
    public static class RepositorioRegistrador
    {
        public static void Registrar(ref ContainerBuilder builder)
        {
            List<Type> tiposRepositoriosEContextos = typeof(RepositorioRegistrador).Assembly.GetTypes().Where(p => p.Name.ToUpper().Contains("REPOSITORIO") && !p.IsInterface).ToList();

            ContainerBuilder tempBuilder = builder;

            tiposRepositoriosEContextos.ForEach(p => tempBuilder.RegisterType(p).AsImplementedInterfaces());

            builder = tempBuilder;
        }
    }
}

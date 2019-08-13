using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskList.Dominio
{
    public static class ServicoRegistrador
    {
        public static void Registrar(ref ContainerBuilder builder)
        {
            List<Type> tiposRepositoriosEContextos = typeof(ServicoRegistrador).Assembly.GetTypes().Where(p => p.Name.ToUpper().Contains("SERVICO") && !p.IsInterface).ToList();

            ContainerBuilder tempBuilder = builder;

            tiposRepositoriosEContextos.ForEach(p => tempBuilder.RegisterType(p).AsImplementedInterfaces());

            builder = tempBuilder;
        }
    }
}

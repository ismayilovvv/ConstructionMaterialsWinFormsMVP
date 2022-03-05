using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC
{
    public static class IOC
    {
        private static IContainer container;
        private static ContainerBuilder builder;

        static IOC()
        {
            builder = new ContainerBuilder();
        }

        public static void Register<TImplementation, TInterface>()
        {
            builder.RegisterType<TImplementation>()
                .As<TInterface>();
        }

        public static void Register<TImplementation>()
        {
            builder.RegisterType<TImplementation>();
        }

        public static void Build()
        {
            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}






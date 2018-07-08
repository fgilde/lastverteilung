using Autofac;
using Lastverteilung.Contracts;

namespace Lastverteilung
{
    public static class IoC
    {
        public static IContainer Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonResourceLoader>().As<IResourceLoader>();
            builder.RegisterType<Balancer>();
            return builder.Build();
        }
    }
}
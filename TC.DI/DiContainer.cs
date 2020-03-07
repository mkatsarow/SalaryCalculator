using System;
using Microsoft.Extensions.DependencyInjection;

namespace TC.DI
{
    public class DiContainer : IDiContainer
    {
        public IServiceProvider BuildContainer()
        {
            var serviceProvider = new ServiceCollection();

            RegisterTypes(serviceProvider);

            return serviceProvider.BuildServiceProvider();
        }
        protected void RegisterTypes(IServiceCollection services)
        {

        }
    }
}

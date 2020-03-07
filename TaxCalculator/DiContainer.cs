using System;
using Microsoft.Extensions.DependencyInjection;
using TC.Core;
using TC.Core.Contracts;
using TC.Core.Utilities.IO;
using TC.Core.Utilities.IO.Contracts;
using TC.Services;
using TC.Services.Contracts;

namespace TaskTaxCalculator
{
    public class DiContainer
    {
        public IServiceProvider BuildContainer()
        {
            var serviceProvider = new ServiceCollection();

            RegisterTypes(serviceProvider);

            return serviceProvider.BuildServiceProvider();
        }
        private void RegisterTypes(IServiceCollection services)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IWriter, Writer>();
            services.AddSingleton<IEngine, Engine>();
            services.AddSingleton<ITaxCalculator, IncomeTaxService>();
            services.AddSingleton<ITaxCalculator, SocialTaxService>();
            services.AddSingleton<ISalaryService, SalaryService>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using TC.Core.Contracts;

namespace TaskTaxCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var builder = new DiContainer();

            var container = builder.BuildContainer();

            var engine = container.GetService<IEngine>();

            engine.Run();
        }
    }
}

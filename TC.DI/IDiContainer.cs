using System;

namespace TC.DI
{
    public interface IDiContainer
    {
        IServiceProvider BuildContainer();
    }
}
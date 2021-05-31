using System;
using RS.SorteOnline.Agenda.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace RS.Agenda.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

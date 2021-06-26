using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MinhaAgendaMinhaVida.Infra.Managers;
using MinhaAgendaMinhaVida.Service.Services;

namespace MinhaAgendaMinhaVida.IoC
{
    public class NativeInjector
    {
        private const string NAMESPACEBASE = "MinhaAgendaMinhaVida";

        public static void RegisterServices(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.ManifestModule.Name.Contains(NAMESPACEBASE)).ToList();

            assemblies.Add(typeof(BaseService).Assembly);

            AutoInjector(services, assemblies, "Infra");
            AutoInjector(services, assemblies, "Service");

            services.AddScoped<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetService));

            services.AddScoped<MinhaAgendaMinhaVidaConnectionManager>();
        }

        private static void AutoInjector(IServiceCollection services, IEnumerable<Assembly> assemblies, string prefix)
        {
            var serviceAssembly = assemblies.FirstOrDefault(x => x.ManifestModule.Name.Contains(prefix));

            if (serviceAssembly is null) return;
            {
                foreach (var type in serviceAssembly.ExportedTypes)
                {
                    var interfaces = type.GetInterfaces().Where(x => x.Namespace.Contains(NAMESPACEBASE));

                    if (!type.Name.StartsWith("Base") && interfaces.Count() != 0)
                        services.AddTransient(interfaces.First(), type);
                }
            }
        }
    }
}
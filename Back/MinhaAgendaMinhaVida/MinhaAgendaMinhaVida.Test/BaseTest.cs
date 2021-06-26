using System.IO;
using Microsoft.Extensions.DependencyInjection;
using MinhaAgendaMinhaVida.Api;
using MinhaAgendaMinhaVida.CrossCutting;
using MinhaAgendaMinhaVida.Domain.AutoMapper;
using MinhaAgendaMinhaVida.IoC;

namespace MinhaAgendaMinhaVida.Test
{
    public class BaseTest
    {
        public BaseTest()
        {
            var connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={CurrentPath}\\MinhaAgendaMinhaVida.Infra\\DataBase\\MinhaAgendaMinhaVida.mdf;Integrated Security=True";
            ConnectionStrings.MinhaAgendaMinhaVidaConnection =
                connectionString.Replace("{CurrentPath}",
                    Directory.GetParent(
                            Directory.GetParent(
                                    Directory.GetParent(
                                            Directory.GetParent(
                                                Directory.GetCurrentDirectory())?.FullName)
                                ?.FullName)
                            ?.FullName)
                        ?.FullName);

            var services = new ServiceCollection();

            services.AddAutoMapper(conf => AutoMapperConfiguration.RegisterMappings(conf), typeof(Startup).Assembly);

            NativeInjector.RegisterServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider _serviceProvider { get; set; }
    }
}
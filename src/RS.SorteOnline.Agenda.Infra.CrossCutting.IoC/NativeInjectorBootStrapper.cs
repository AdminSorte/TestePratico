using RS.SorteOnline.Agenda.Application.Interfaces;
using RS.SorteOnline.Agenda.Application.Services;
using RS.SorteOnline.Agenda.Domain.Interfaces;
using RS.SorteOnline.Agenda.Infra.Data.Context;
using RS.SorteOnline.Agenda.Infra.Data.Repository;
using RS.SorteOnline.Agenda.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace RS.SorteOnline.Agenda.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IAgendaAppService, AgendaAppService>();

            // Infra - Data
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<RSContext>();
        }
    }
}

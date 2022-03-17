using Microsoft.Extensions.DependencyInjection;
using SO.Agenda.Application.AppServices.Implementations;
using SO.Agenda.Application.AppServices.Interfaces;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Domain.Model.Interfaces.Services;
using SO.Agenda.Domain.Model.UnitOfWork;
using SO.Agenda.Domain.Service.Services;
using SO.Agenda.Domain.Service.Specifications;
using SO.Agenda.Infrastructure.Data.Context;
using SO.Agenda.Infrastructure.Data.Repositories;
using SO.Agenda.Infrastructure.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Infrastructure.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ITaskItemAppService, TaskItemAppService>();
            
            // Domain.Services
            services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<TaskItemMustHaveUniqueTitle>();

            // Infrastructure.Data
            services.AddDbContext<AgendaContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();

        }
    }
}

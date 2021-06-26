using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Business;
using Todo.Application.Business.Interface;
using Todo.Application.Repository;
using Todo.Application.Service;
using Todo.Application.Service.Interface;
using Todo.Infrastructure.Repository;

namespace Todo.CrossCutting.IoC.Configuration
{
    public static class DependenceInjection
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITodoTaskRepository, TodoTaskRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<ITodoTaskBusiness, TodoTaskBusiness>();
        }
    }
}
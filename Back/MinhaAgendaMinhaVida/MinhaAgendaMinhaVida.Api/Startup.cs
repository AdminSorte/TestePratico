using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MinhaAgendaMinhaVida.CrossCutting;
using MinhaAgendaMinhaVida.Domain.AutoMapper;
using MinhaAgendaMinhaVida.IoC;

namespace MinhaAgendaMinhaVida.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MinhaAgendaMinhaVidaConnection");
            ConnectionStrings.MinhaAgendaMinhaVidaConnection =
                connectionString.Replace("{CurrentPath}",
                    Directory.GetParent(Directory.GetCurrentDirectory())?.FullName);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "MinhaAgendaMinhaVida.Api", Version = "v1"});
            });

            services.AddAutoMapper(conf => AutoMapperConfiguration.RegisterMappings(conf), typeof(Startup).Assembly);

            NativeInjector.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinhaAgendaMinhaVida.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
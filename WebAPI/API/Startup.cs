using System;
using System.IO;
using System.Reflection;
using System.Text;
using API.Controllers;
using API.Token;
using API.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.DTO;
using Services.Interfaces;
using Services.Services;

namespace API
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

            services.AddControllers();

            #region Jwt

            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Minha Agenda Minha Vida",
                    Version = "v1",
                    Description = "API desafio Minha Casa Minha Vida",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Vicencio de Deus Concei��o",
                        Email = "wellington.vicencio@uni9.edu.br",
                        Url = new Uri("https://www.linkedin.com/in/wellington-vicencio-396655181/")
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Use Bearer<TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });




            });



            #endregion

            #region  Cryptography

            /* services.AddRijndaelCryptography(Configuration["Cryptography"]);
 */
            #endregion



            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Agenda, AgendaDTO>().ReverseMap();
                cfg.CreateMap<CriarAgendaViewModel, AgendaDTO>().ReverseMap();
                cfg.CreateMap<AtualizarViewModel, AgendaDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion


            #region Inje��o de Dependencia

            services.AddSingleton(d => Configuration);

            services.AddDbContext<AgendaContext>(options =>

              options.UseSqlServer(Configuration["ConnectionStrings:AGENDA"]), ServiceLifetime.Transient);

            services.AddScoped<IAgendaServico, AgendaServico>();
            services.AddScoped<IAgendaRepositorio, AgendaRepositorio>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            #endregion

            #region Cors

            services.AddCors();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "minhaagendaminhavida/swagger/{documentName}/swagger.json";
                });

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/minhaagendaminhavida/swagger/v1/swagger.json", "WishListAPI v1");
                    c.RoutePrefix = "minhaagendaminhavida/swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

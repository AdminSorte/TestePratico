using Microsoft.Extensions.DependencyInjection;

namespace Todo.Api.Configuration
{
    public static class CorsConfig
    {
        public static void ConfigureCors(this IServiceCollection services) {
            services.AddCors(config => {
			config.AddPolicy("CorsPolicy", option => {
				option
					.AllowAnyMethod()
					.AllowAnyHeader()
					.SetIsOriginAllowed(_ => true)
					.AllowCredentials();
			});
		});
        }
    }
}
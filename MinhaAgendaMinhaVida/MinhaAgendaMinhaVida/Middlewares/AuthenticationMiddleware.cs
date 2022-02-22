using MinhaAgendaMinhaVida.Models;
using System.IdentityModel.Tokens.Jwt;

namespace MinhaAgendaMinhaVida.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.Value?.StartsWith("/Login") ?? false)
                return _next(httpContext);

            var token = httpContext.Session.GetString(Constantes.TOKEN);
            if (ValidarToken(token))
            {
                httpContext.Response.Redirect("/Login/");
                httpContext.Request.Path = "/Login/";
                httpContext.Request.Method = "GET";
            }

            return _next(httpContext);
            
        }

        private bool ValidarToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            return (jwtToken == null) || (jwtToken.ValidFrom > DateTime.UtcNow) || (jwtToken.ValidTo < DateTime.UtcNow);
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}

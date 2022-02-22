using Microsoft.IdentityModel.Tokens;
using MinhaAgendaMinhaVida.Data;
using MinhaAgendaMinhaVida.Models;
using MinhaAgendaMinhaVida.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinhaAgendaMinhaVida.Services
{
    public class ServicoDeUsuario : IServicoDeUsuario
    {
        public Usuario Login(string login, string senha)
        {
            try
            {
                using (var context = new Context())
                {
                    var senhaEncriptada = Encode(senha);
                    var usuario = context
                        .Usuarios
                        .Where(x => x.Login == login && x.Senha == senhaEncriptada)
                        .FirstOrDefault();
                        ;

                    if (usuario == null)
                        throw new Exception("Usuário ou senha inválidos");

                    SetToken(usuario);
                    return usuario;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario GetUsuario(int usuarioId)
        {
            try
            {
                using (var context = new Context())
                {
                    var usuario = context
                        .Usuarios
                        .Where(x => x.Id == usuarioId)
                        .FirstOrDefault();
                    ;

                    if (usuario == null)
                        throw new Exception("Usuário inexistente");

                    return usuario;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            var senha = BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
            return senha;
        }

        private void SetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constantes.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuario.Token = tokenHandler.WriteToken(token);
        }
    }
}

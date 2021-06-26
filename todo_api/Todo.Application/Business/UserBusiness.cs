using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Todo.Application.Business.Interface;
using Todo.Application.Constant;
using Todo.Application.Dto.User;
using Todo.Application.Repository;
using Todo.Application.Response;
using Todo.Application.Secutiry;
using Todo.Application.Service.Interface;
using Todo.Domain.Entities;

namespace Todo.Application.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly ICryptoService _cryptoService;

        public UserBusiness(
            IOptions<AppSettings> appSettings,
            IUserRepository userRepository,
            IIdentityService identityService,
            ICryptoService cryptoService
        )
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _identityService = identityService;
            _cryptoService = cryptoService;
        }

        public async Task<ResponseService> Login(LoginDto data)
        {
            try {
                var user = await _userRepository.FindByEmail(data.Email);
                
                if (user != null && _cryptoService.CompareHash(data.Password, user.Password)) {
                    var token = GenerateJwt(user);
                    return new ResponseService(token);
                }

                return new ResponseService(messageError: "Incorrect username or password");
            }
            catch {
                return new ResponseService(messageError: "Invalid user");
            }
        }

        public async Task<ResponseService> CreateAsync(CreateUserDto data)
        {
            try {
                var userExists = (await _userRepository.FindByEmail(data.Email)) != null;

                if (!userExists) {
                    var user = new User {
                        Name = data.Name,
                        LastName = data.LastName,
                        Email = data.Email,
                        Password = _cryptoService.HashPassword(data.Password)
                    };

                    var result = await _userRepository.CreateAsync(user);

                    return new ResponseService(result);
                }

                return new ResponseService(messageError: "User already exists");
            }
            catch(Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        public async Task<ResponseService> UpdateAsync(UpdateUserDto data)
        {
            try {
                var user = await _userRepository.FindById(_identityService.GetUserIdentity());

                if (user != null) {
                    user.Name = data.Name;
                    user.LastName = data.LastName;

                    var result = await _userRepository.UpdateAsync(user);

                    return new ResponseService(result);
                }

                return new ResponseService(messageError: "Invalid user");
            }
            catch(Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        public async Task<ResponseService> ChangePasswordAsync(ChangePasswordDto data)
        {
            try {
                var user = await _userRepository.FindById(_identityService.GetUserIdentity());

                if (user != null) {
                    user.Password = _cryptoService.HashPassword(data.Password);

                    var result = await _userRepository.ChangePasswordAsync(user);

                    return new ResponseService(result);
                }

                return new ResponseService(messageError: "Invalid user");
            }
            catch(Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        public async Task<ResponseService> RemoveAsync()
        {
            try {
                 var user = await _userRepository.FindById(_identityService.GetUserIdentity());

                if (user != null) {
                    var result = await _userRepository.RemoveAsync(_identityService.GetUserIdentity());

                    return new ResponseService(result);
                }

                return new ResponseService(messageError: "Invalid user");
            }
            catch(Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        private object GenerateJwt(User user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimConstant.USER_ID, user.Id.ToString()));
            claims.Add(new Claim(ClaimConstant.EMAIL, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expireDate = DateTime.UtcNow.AddHours(_appSettings.Expiration);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Expires = expireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return new {
                token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
                user = new {
                    user.Email,
                    user.Name
                },
                expireDate
            };
        }
    }
}
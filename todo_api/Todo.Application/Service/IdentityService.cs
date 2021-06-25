using Todo.Application.Service.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Todo.Application.Service
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public long GetUserIdentity() => long.Parse(_context.HttpContext.User.FindFirst("userId").Value);
        public string GetUserEmail() => _context.HttpContext.User.FindFirst("userEmail").Value;
    }
}
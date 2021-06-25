using Todo.Application.Service.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Todo.Application.Constant;

namespace Todo.Application.Service
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int GetUserIdentity() => int.Parse(_context.HttpContext.User.FindFirst(ClaimConstant.USER_ID).Value);
        public string GetUserEmail() => _context.HttpContext.User.FindFirst(ClaimConstant.EMAIL).Value;
    }
}
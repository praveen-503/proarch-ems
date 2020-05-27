using Microsoft.AspNetCore.Http;
using Proarch.Ems.Core.Application.Services;

namespace Proarch.Ems.Presentation.API.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        string IUserService.User { get => _httpContextAccessor.HttpContext?.User?.Identity?.Name; }
    }
}

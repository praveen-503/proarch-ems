using Microsoft.AspNetCore.Http;
using Proarch.Ems.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

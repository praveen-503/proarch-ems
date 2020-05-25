using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Proarch.Ems.Core.Application.Services;
using Proarch.Ems.Presentation.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Proarch.Ems.Presentation.API.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            var assembly = Assembly.Load("Proarch.Ems.Infrastructure.Data");
            var types = assembly.GetTypes().Where(x => x.IsClass && x.IsNotPublic && !x.IsAbstract && x.FullName.EndsWith("Repository"));
            foreach (var type in types)
            {
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }

            assembly = Assembly.Load("Proarch.Ems.Core.Application");
            types = assembly.GetTypes().Where(x => x.IsClass && x.IsNotPublic && !x.IsAbstract && x.FullName.EndsWith("Usecase"));
            foreach (var type in types)
            {
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}

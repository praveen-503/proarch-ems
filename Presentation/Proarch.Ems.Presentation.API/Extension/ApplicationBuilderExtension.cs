using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Proarch.Ems.Core.Domain.Exceptions;
using Proarch.Ems.Infrastructure.Data.Common;
using System.Net;


namespace Proarch.Ems.Presentation.API.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static void EnsureSeeds(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<EmsDbContext>();
            //context.Database.Migrate();

        }

        public static void HandleException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context => {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature == null || contextFeature.Error == null)
                    {
                        return;
                    }

                    if (contextFeature.Error is AppValidationException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsync(contextFeature.Error.Message);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync(contextFeature.Error.Message);
                    }
                });
            });
        }
    }
}


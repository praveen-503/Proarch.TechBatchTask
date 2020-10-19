
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Proarch.TechBatchTask.Core.Application.Exceptions;
using Proarch.TechBatchTask.Infrastructure.Data.Common;
using System.Net;

namespace Proarch.TechBatchTask.Presentaion.API.Extentions
{
    public static class ApplicationBuilderExtension
    {
        public static void EnsureSeeds(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TechBatchTaskDbContext>();
            context.Database.EnsureCreated();
            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                // Create the Db if it doesn't exist and applies any pending migration.
                context.Database.Migrate();
            }
            //context.Database.Migrate();
        }

        public static void HandleException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
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


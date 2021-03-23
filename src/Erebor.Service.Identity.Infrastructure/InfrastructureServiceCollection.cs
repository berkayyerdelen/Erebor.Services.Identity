using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Infrastructure.Context;
using Erebor.Service.Identity.Infrastructure.Hangfire;
using Erebor.Service.Identity.Infrastructure.Repositories;
using Erebor.Service.Identity.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Erebor.Service.Identity.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthManager, JwtAuthManager>();
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<RemoveExpiredTokenManager>();
         
        }  
    }
}
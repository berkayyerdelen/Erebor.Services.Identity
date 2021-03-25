using System.Reflection;
using Erebor.Service.Identity.Core.Domain.AuthService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Erebor.Service.Identity.Core
{
    public static class IdentityServiceCollection
    {
        public static void AddIdentityCommandsCollection(this IServiceCollection services)
        {
            services.AddMediatR(typeof(LoginRequestHandler).GetTypeInfo().Assembly);
        }

    }
}
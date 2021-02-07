using System.Reflection;
using Erebor.Service.Identity.Core.Domain.AuthService.Login;
using Erebor.Service.Identity.Core.Domain.AuthService.RefreshToken;
using Erebor.Service.Identity.Core.Domain.UserService.CreateUser;
using Erebor.Service.Identity.Core.Domain.UserService.UpdateUserRole;
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
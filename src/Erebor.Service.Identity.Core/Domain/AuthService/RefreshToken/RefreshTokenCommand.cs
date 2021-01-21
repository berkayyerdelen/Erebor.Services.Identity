using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.RefreshToken
{
    public class RefreshTokenCommand:IRequest<string>
    {
        public string RefreshToken { get; set; }
    }
}
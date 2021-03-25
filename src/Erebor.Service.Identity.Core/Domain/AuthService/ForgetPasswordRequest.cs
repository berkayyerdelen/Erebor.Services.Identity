using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Shared.Security;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService
{
    public class ForgetPasswordRequest : IRequest
    {
        public string Email { get; set; }

    }

    public sealed class ForgetPasswordRequestHandler : IRequestHandler<ForgetPasswordRequest>
    {
        private readonly IUserRepository _userRepository;
 

        public ForgetPasswordRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task<Unit> Handle(ForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            user.UpdatePassword(PasswordHelper.Decrypt(user.Password));
            return Unit.Value;

        }
    }
}
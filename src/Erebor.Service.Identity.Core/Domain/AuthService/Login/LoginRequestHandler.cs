using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Login
{
    public class LoginRequestHandler:IRequestHandler<LoginRequest,LoginResult>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoginResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.GetUserAsync(request.UserName);

            return null;
        }
    }
}
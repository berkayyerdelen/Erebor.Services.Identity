using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Shared.CommonDTO;
using Erebor.Service.Identity.Shared.Security;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.ForgetPassword
{
    public class ForgetPasswordRequest : IRequest
    {
        public string Email { get; set; }

    }

    public sealed class ForgetPasswordRequestHandler : IRequestHandler<ForgetPasswordRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IForgetPasswordPublisher _forgetPasswordPublisher;

        public ForgetPasswordRequestHandler(IUserRepository userRepository, IForgetPasswordPublisher forgetPasswordPublisher)
        {
            _userRepository = userRepository;
            _forgetPasswordPublisher = forgetPasswordPublisher;
        }

        public async Task<Unit> Handle(ForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            user.UpdatePassword(PasswordHelper.Decrypt(user.Password));
            await _forgetPasswordPublisher.ForgetPasswordSender(new UserInfoForgetPasswordDto{Password = user.Password,UserName = user.UserName});
            return Unit.Value;

        }
    }
}
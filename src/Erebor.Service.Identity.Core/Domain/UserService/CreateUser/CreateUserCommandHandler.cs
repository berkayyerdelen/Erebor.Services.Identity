using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Shared.Security;

namespace Erebor.Service.Identity.Core.Domain.UserService.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordHelper.Hash(request.Password);
            await _userRepository.CreateUserAsync(User.CreateUser(request.Emails,request.Roles,request.UserName, password, request.CreatedAt,request.IsActive));
            return Unit.Value;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService
{
     public class DeleteUserCommand: IRequest
    {
        public string UserId { get; set; }
    }
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        public readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserAsync(request.UserId);
            return Unit.Value;
        }
    }
}
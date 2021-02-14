using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            user.UpdateRole(request.CurrentRole, request.Role);
            await _userRepository.UpdateUserAsync(user);
            return Unit.Value;

        }
    }
}
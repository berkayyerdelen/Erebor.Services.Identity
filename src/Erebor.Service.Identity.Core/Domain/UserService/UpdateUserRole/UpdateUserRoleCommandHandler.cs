using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities;
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
            var user = await _userRepository.GetUserAsync(new Guid("645fa83f-1757-6245-b3fc-2c963f66afa6"));
            user.UpdateRole(request.CurrentRole, request.Role);
            var t = user;
            await _userRepository.UpdateUserAsync(user);
            return Unit.Value;

        }
    }
}
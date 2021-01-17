using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            //Todo: Imp Password Hasher 
            await _userRepository.CreateUserAsync(User.CreateUser(request.Id,request.Emails,request.Roles,request.UserName,request.Password,request.CreatedAt,request.IsActive));
            return Unit.Value;
        }
    }
}

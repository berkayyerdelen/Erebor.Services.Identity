using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Shared.Security;
using System.Collections.Generic;
using System;

namespace Erebor.Service.Identity.Core.Domain.UserService
{
      public class CreateUserCommand:IRequest
    {
        public List<Email> Emails { get; set; }
        public List<Role> Roles { get;  set; }
        public string UserName { get; set; }
        public string Password { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public bool IsActive { get;  set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordHelper.Encrypt(request.Password);
            await _userRepository.CreateUserAsync(User.CreateUser(request.Emails,request.Roles,request.UserName, password, request.CreatedAt,request.IsActive));
            return Unit.Value;
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService.GetUsers
{
    public sealed class GetUsersRequestHandler : IRequestHandler<GetUsersRequest,List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
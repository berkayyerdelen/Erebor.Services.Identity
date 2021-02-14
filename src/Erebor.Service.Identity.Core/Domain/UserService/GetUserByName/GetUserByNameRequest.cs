using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService.GetUserByName
{
    public class GetUserByNameRequest:IRequest<User>
    {
        public string Name { get; set; }

        public GetUserByNameRequest(string name)
        {
            Name = name;
        }

    }

    public class GetUserByNameRequestHandler : IRequestHandler<GetUserByNameRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByNameRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByNameRequest request, CancellationToken cancellationToken)
        {
           return await _userRepository.GetUserByNameAsync(request.Name);
        }
    }
}
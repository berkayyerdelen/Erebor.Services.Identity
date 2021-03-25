
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Domain.UserService;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Erebor.Service.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
            => _mediator = mediator;
        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(Unit),(StatusCodes.Status201Created))]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand request)
            => Ok(await _mediator.Send(request));

        [HttpPut("UpdateUserRole")]
        [ProducesResponseType(typeof(Unit), (StatusCodes.Status200OK))]
        public async Task<IActionResult> UpdateUserRoleAsync(UpdateUserRoleCommand request)
            => Ok(await _mediator.Send(request));

    }
}

using Erebor.Service.Identity.Core.Domain.UserService.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Domain.UserService.UpdateUserRole;
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
        {
            _mediator = mediator;

        }
        // POST api/<UserController>
        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(Unit),(StatusCodes.Status201Created))]
        public async Task<IActionResult> CreateUser(CreateUserCommand request)
            => Ok(await _mediator.Send(request));

        [HttpPost("UpdateUserRole")]
        [ProducesResponseType(typeof(Unit), (StatusCodes.Status200OK))]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand request)
            => Ok(await _mediator.Send(request));

    }
}

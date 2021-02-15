using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Domain.AuthService.ForgetPassword;
using Erebor.Service.Identity.Core.Domain.AuthService.Login;
using Erebor.Service.Identity.Core.Domain.AuthService.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Erebor.Service.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return  Ok(await _mediator.Send(request));
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> Forgetpassword([FromBody] ForgetPasswordRequest  request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}

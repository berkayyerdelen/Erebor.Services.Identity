using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.DTO;
using System.Security.Claims;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<JwtAuthResultDTO> Authenticate(string username, string password);
    }
}
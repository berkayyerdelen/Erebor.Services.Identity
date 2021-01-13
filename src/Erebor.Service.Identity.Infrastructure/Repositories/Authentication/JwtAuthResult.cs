using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Infrastructure.Repositories.Authentication
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}

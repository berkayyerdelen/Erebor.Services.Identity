using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Core.DTO
{
    public class LoginResultDTO
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        
    }
}
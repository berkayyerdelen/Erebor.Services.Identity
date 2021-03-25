using System;

namespace Erebor.Service.Identity.Core.DTO
{
    public class JwtAuthResultDTO
    {
        public string Token { get; set; }
        public DateTime TokenExpiredDate { get; set; }
        
    }
}
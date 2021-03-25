using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Shared.Helper
{
    public static class FormatExtensions
    {
        public static bool IsEmail(this string input)
        {
            try
            {
                var mail = new MailAddress(input);
                return mail.Address == input;
            }
            catch 
            {
                return false;
            }                  
        }
    }
}
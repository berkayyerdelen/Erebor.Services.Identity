using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Events
{
    public class UpdatePasswordEvent:INotification
    {
        public string Password { get; set; }
        public UpdatePasswordEvent(string password)
        {
            Password = password;
        }
    }
}

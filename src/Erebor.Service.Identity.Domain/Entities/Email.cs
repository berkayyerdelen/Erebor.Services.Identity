﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class Email
    {
        public string Value { get; set; }
        public Email(string value)
        {
            Value = value;
        }
    }
}
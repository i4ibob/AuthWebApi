﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Auxilary
{
    public class AuthSettings
    {
        public TimeSpan Expires { get; set;}
        public string SecretKey { get; set;}

    }
}

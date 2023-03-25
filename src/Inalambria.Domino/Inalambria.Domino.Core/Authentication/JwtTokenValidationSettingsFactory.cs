﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.Core.Authentication
{
    public class JwtTokenValidationSettings
    {
        public String ValidIssuer { get; set; }

        public String ValidAudience { get; set; }

        public String SecretKey { get; set; }

        public int Duration { get; set; } //Minutes
    }
}

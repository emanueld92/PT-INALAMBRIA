using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.Core.Authentication
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
            
        }

        public Role(string roleName) : base(roleName) { }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.EntityFramework
{
    public  class DominoDbContext :IdentityDbContext
    {


        public DominoDbContext(DbContextOptions<DominoDbContext> options):base(options) 
        { 
        }
    }
}

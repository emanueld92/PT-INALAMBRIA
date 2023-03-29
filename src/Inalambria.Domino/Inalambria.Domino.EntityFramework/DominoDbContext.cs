using Inalambria.Domino.Core.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.EntityFramework
{
    public  class DominoDbContext :IdentityDbContext<User,Role,int>
    {
        public virtual DbSet<UserType> UserTypes { get; set; }

        public DominoDbContext(DbContextOptions<DominoDbContext> options):base(options) 
        {
            try
            {
                var databaseCreate = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreate != null)
                {
                    if (!databaseCreate.CanConnect()) databaseCreate.Create();
                    if (databaseCreate.HasTables()) databaseCreate.CreateTables();
                } 
            }
            catch (Exception ex) {
                Console.WriteLine("error: ",ex.Message);

            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

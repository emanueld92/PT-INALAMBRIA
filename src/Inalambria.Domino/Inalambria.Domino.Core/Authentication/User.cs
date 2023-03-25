using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.Core.Authentication
{
    public class User: IdentityUser<int>
    {

  
        public int UserType { get; set; }
        public int AreaId { get; set; }
        public string ?Name { get; set; }
        public string ?LastName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }

 

    }
}

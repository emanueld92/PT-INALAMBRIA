﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.Core.Authentication
{
    public class UserType
    {

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ?UserTypeName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
       
    }
}

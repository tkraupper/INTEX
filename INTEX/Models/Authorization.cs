﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Authorization")]
    public class Authorization
    {
        [Key]
        public int AuthID { get; set; }

        public string AuthType { get; set; }
    }
}
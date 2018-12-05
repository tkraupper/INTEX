﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("AssayTest")]
    public class AssayTest
    {
        [Key]
        public int AssayID { get; set; }

        [ForeignKey("Test")]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }

        public bool Conditional { get; set; }
    }
}
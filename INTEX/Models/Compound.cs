using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Compound")]
    public class Compound
    {
        [Key]
        public int LTNumber { get; set; }

        public string CompoundName { get; set; }

        public string Description { get; set; }
    }
}
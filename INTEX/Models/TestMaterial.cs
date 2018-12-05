using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("TestMaterial")]
    public class TestMaterial
    {
        [Key, Column(Order = 0)]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }

        [Key, Column(Order = 1)]
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }

        public double QuantityUsed { get; set; }
    }
}
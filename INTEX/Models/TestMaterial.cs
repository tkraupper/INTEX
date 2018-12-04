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
        [Key]
        public int TestID { get; set; }

        [Key]
        public int MaterialID { get; set; }

        public double QuantityUsed { get; set; }
    }
}
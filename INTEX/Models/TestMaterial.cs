using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Test ID")]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Material ID")]
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }

        [DisplayName("Quantity Used")]
        public double QuantityUsed { get; set; }
    }
}
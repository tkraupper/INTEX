using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }

        public string TestDescription { get; set; }

        public double TestCost { get; set; }

        public double BasePrice { get; set; }
    }
}
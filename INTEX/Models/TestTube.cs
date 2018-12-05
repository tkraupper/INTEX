using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("TestTube")]
    public class TestTube
    {
        [Key]
        public int TestTubeID { get; set; }

        //FOREIGN KEYS LINKING TO SAMPLE TABLE
        public int? LTNumber { get; set; }
        public int? CompoundSequenceCode { get; set; }

        public virtual Sample Sample { get; set; }
        //Do I need to generate another Sample object?

        public int TestID { get; set; }
        public virtual Test Test { get; set; }

        public decimal ActualCost { get; set; }

        public string TestDateTime { get; set; }

        public string TestStatus { get; set; }

        public int? Predecessor { get; set; }

        public string QualitativeResult { get; set; }

        public string QuantitativeResult { get; set; }
    }
}
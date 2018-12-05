using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Test Tube ID")]
        public int TestTubeID { get; set; }

        //FOREIGN KEYS LINKING TO SAMPLE TABLE
        public int? LTNumber { get; set; }
        public int? CompoundSequenceCode { get; set; }

        public virtual Sample Sample { get; set; }
        //Do I need to generate another Sample object?

        [DisplayName("Test ID")]
        public int TestID { get; set; }

        [DisplayName("Actual Cost")]
        public decimal ActualCost { get; set; }

        [DisplayName("Test Date Time")]
        public string TestDateTime { get; set; }

        [DisplayName("Status")]
        public string TestStatus { get; set; }

        public int? Predecessor { get; set; }
    }
}
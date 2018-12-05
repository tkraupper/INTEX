using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key, Column(Order = 0)]
        [DisplayName("Compound Sequence Code")]
        public int CompoundSequenceCode { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("LT Number")]
        public int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        [DisplayName("Assay ID")]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        [DisplayName("Indicated Weight")]
        public double? /*float*/ IndicatedWeight { get; set; }

        [DisplayName("Actual Weight")]
        public double? /*float*/ ActualWeight { get; set; }

        [DisplayName("Quantity")]
        public double? /*float*/ QuantityInMilligrams { get; set; }

        [DisplayName("Date Arrived")]
        public string DateArrived { get; set; }

        [DisplayName("Received By")]
        public string RecievedBy { get; set; }

        [DisplayName("Date Due")]
        public string DateDue { get; set; }

        public string Appearance { get; set; }

        [DisplayName("Molecular Mass")]
        public double? /*float*/ MolecularMass { get; set; }

        [DisplayName("Maximum Tolerated Dose")]
        public double? /*float*/ MTD { get; set; }

        [DisplayName("Secondary Testing Approval")]
        public bool SecondaryTestingApproval { get; set; }

        [DisplayName("Analysis Report")]
        public string AnalysisReport { get; set; }
    }
}
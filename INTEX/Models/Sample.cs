﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key]
        public int CompoundSequenceCode { get; set; }

        [Key]
        [ForeignKey("Compound")]
        public int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [ForeignKey("WorkOrder")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        [ForeignKey("Assay")]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        public float IndicatedWeight { get; set; }

        public float ActualWeight { get; set; }

        public float QuantityInMilligrams { get; set; }

        public string DateArrived { get; set; }

        public string ReceivedBy { get; set; }

        public string DateDue { get; set; }

        public string Appearance { get; set; }

        public float MolecularMass { get; set; }

        public float MTD { get; set; }

        public bool SecondaryTestingApproval { get; set; }

        public string AnalysisReport { get; set; }
    }
}
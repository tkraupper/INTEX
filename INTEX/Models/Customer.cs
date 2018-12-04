﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public int Contact { get; set; }

        public string PaymentInfo { get; set; }

        public double RunningBalance { get; set; }
    }
}
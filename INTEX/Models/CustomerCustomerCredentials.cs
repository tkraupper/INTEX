using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class CustomerCustomerCredentials
    {
        public CustomerCredentials CustomerCredentials { get; set; }
        public Customer Customer { get; set; }
    }
}
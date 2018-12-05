using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INTEX.DAL
{
    public class IntexContext : DbContext
    {
        public IntexContext() : base("IntexContext")
        {

        }

        public DbSet<Assay> Assays { get; set; }
        public DbSet<AssayRequest> AssayRequests { get; set; }
        public DbSet<AssayTest> AssayTests { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCredentials> CustomerCredential { get; set; }
        public DbSet<EmployeeCredentials> EmployeeCredential { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<PayInfo> PayInfos { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PriceChange> PriceChanges { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteRequest> QuoteRequests { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestMaterial> TestMaterials { get; set; }
        public DbSet<TestTube> TestTubes { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
    }
}
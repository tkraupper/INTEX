﻿using INTEX.DAL;
using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    public class CustomerController : Controller
    {
        public IntexContext db = new IntexContext();

        public static int currentCustomer;

        // GET: Client
        public ActionResult Index()
        {
            CustomerCustomerCredentials cust = new CustomerCustomerCredentials();
            cust.CustomerCredentials = db.CustomerCredential.Find(currentCustomer);
            cust.Customer = db.Customers.Find(currentCustomer);
            if (cust.CustomerCredentials == null || cust.Customer == null) { return Content("Fail"); }
            return View(cust);
        }

        //LOGIN METHODS FOR THE CUSTOMER
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string uname, string psw)
        {
            List<CustomerCredentials> logins = db.CustomerCredential.ToList();
            foreach (CustomerCredentials creds in logins)
            {
                if (uname == creds.Username && psw == creds.Password)
                {
                    currentCustomer = creds.CustomerID;
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }
    }
}
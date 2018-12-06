﻿using INTEX.DAL;
using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    public class CustomerPortalController : Controller
    {
        public IntexContext db = new IntexContext();

        public static int currentCustomer = -1;

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


        public ActionResult RequestQuote()
        {
            return View();
        }

        public ActionResult NewWorkOrder()
        {
            return View();
        }

        public ActionResult NewWorkOrderForm()
        {
            return View();
        }

        public ActionResult CurrentWorkOrders()
        {
            return View();
        }

        public ActionResult WorkOrderStatus(int id)
        {
            if (currentCustomer == -1)
            {
                return RedirectToAction("Login");
            }
            Customer customer = db.Customers.Find(currentCustomer);
            if (customer == null)
            {
                return RedirectToAction("Login");
            }
            WorkOrder worder = db.WorkOrders.Find(id);
            if (worder.CustomerID != currentCustomer)
            {
                return RedirectToAction("CurrentWorkOrders");
            }
            return View(worder);

            
        }

        public ActionResult CustomerBilling()
        {
            return View();
        }

        public ActionResult CustomerAccount()
        {
            return View();
        }
    }
}
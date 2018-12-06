using INTEX.DAL;
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

        public static List<AssayRequest> cart = new List<AssayRequest>();

        public static int currentCustomer = -1;

        // GET: Client
        public ActionResult Index()
        {
            if (currentCustomer == -1)
            {
                return View("Login");
            }
            CustomerCustomerCredentials cust = new CustomerCustomerCredentials();
            cust.CustomerCredentials = db.CustomerCredential.Find(currentCustomer);
            cust.Customer = db.Customers.Find(currentCustomer);
            if (cust.CustomerCredentials == null || cust.Customer == null) { return View("Login"); }
            return View(cust);
        }
        
        //LOGIN METHODS FOR THE CUSTOMER
        [HttpGet]
        public ActionResult Login()
        {
            return View();
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
            return View();
        }

        //Start of Quote Request Section
        public ActionResult RequestQuote()
        {
            ViewBag.cart = cart;
            return View();
        }

        public ActionResult SelectAssay()
        {
            return View(db.Assays.ToList());
        }

        public ActionResult SelectCompound(int id)
        {
            ViewBag.assay = id;
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName");
            return View();//Some point in here needs a confirmation page/email.
        }

        [HttpPost]
        public ActionResult SelectCompound(AssayRequest assayRequest, int id)
        {
            if (ModelState.IsValid)
            {
                assayRequest.AssayID = id;
                assayRequest.Assay = db.Assays.Find(id);
                assayRequest.Compound = db.Compounds.Find(assayRequest.LTNumber);
                cart.Add(assayRequest);
                return RedirectToAction("RequestQuote");
            }
            return View();
        }
    
        [HttpPost]
        public ActionResult QuoteRequest(QuoteRequest quoteRequest)
        {
            quoteRequest.CustomerID = currentCustomer;
            if (quoteRequest.CustomerID != -1)
            {
                foreach (AssayRequest assayr in cart)
                {
                    assayr.QuoteRequestID = quoteRequest.QuoteRequestID;
                    db.AssayRequests.Add(assayr);
                }
                db.QuoteRequests.Add(quoteRequest);
                db.SaveChanges();
                ViewBag.id = quoteRequest.QuoteRequestID;
                ViewBag.cust = db.Customers.Find(currentCustomer);
                return View("Confirmation");//Add Confirmation View
            }
            return View("Index");
        }
        //End of Quote Request Section

        //Start of Work Order Creation Section
        //Shows quotes, button to make each one a work order
        public ActionResult Quotes()
        {
            return View(db.Quotes.ToList());
        }

        public ActionResult AddWorkOrder(int id)
        {
            ViewBag.Quote = db.Quotes.Find(id);
            return View();
        }

        public ActionResult AddWorkOrder(WorkOrder worder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(worder);
                return View("WorkOrderAdded");//Add view with confirmation.
            }
            return View();
        }
        //End of Work Order Creation Section

        public ActionResult WorkOrderStatus()
        {
            return View(db.WorkOrders.ToList());  
        }

        public ActionResult GetReports()
        {
            return View(db.WorkOrders.ToList());
        }

        public ActionResult SummaryReport()
        {
            return File("~/Content/SummaryExample.pdf", "application/pdf");
        }

        public ActionResult DataReport()
        {
            return File("~/Content/DataExample.pdf", "application/pdf");
        }

        //Start of Bill Payment Process
        public ActionResult ViewBills()
        {
            return View();
        }

        public ActionResult PayBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PayBill(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("ViewBills");
            }
            return View("PayBill", payment);
        }
        //End of Bill Payment Process


        public ActionResult EditAccount()
        {
            return View();
        }
    }
}
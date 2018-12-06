using INTEX.DAL;
using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    public class SeattlePortalController : Controller
    {
        public IntexContext db = new IntexContext();

        //current login info
        public static int currentEmployee = -1;

        //Test method for database relationships
        public ActionResult testParent()
        {
            //    string info = "List of QuoteRequests with AssayRequests:\n";
            //    var quoters = db.QuoteRequests.ToList();
            //    foreach (QuoteRequest quoter in quoters)
            //    {
            //        info += "QuoteRequest #" + quoter.QuoteRequestID + "\n";
            //        foreach (AssayRequest assayr in quoter.AssayRequests)
            //        {
            //            info += "Assay #" + assayr.AssayID + "\n";
            //        }
            //    }

            string info = "all samples with testtubes:\n\n";
            var worders = db.WorkOrders.ToList();
            foreach (WorkOrder w in worders)
            {
                info += "Work Order #" + w.WorkOrderID + "\n\n";
                foreach (Sample s in w.Sample)
                {
                    info += "Sample #" + s.LTNumber + "-" + s.CompoundSequenceCode + "\n";
                }
            }

            //    info += "\n\n\nList of Assays with QuoteRequests:\n";
            //    var assays = db.Assays.ToList();
            //    foreach (Assay assay in assays)
            //    {
            //        info += "Assay #" + assay.AssayID + ", " + assay.AssayName + ":\n";
            //        foreach (AssayRequest assayr in assay.AssayRequest)
            //        {
            //            info += "QuoteRequest #" + assayr.QuoteRequestID + "\n";
            //        }
            //    }

            return Content(info);
        }

        // HOME PAGE
        public ActionResult Index()
        {
            if (currentEmployee == -1)
            {
                return RedirectToAction("Login");
            }
            EmployeeCredentials employee = db.EmployeeCredential.Find(currentEmployee);
            return View(employee);
        }

        //LOGIN METHODS FOR THE SEATTLE EMPLOYEES
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string uname, string psw)
        {
            List<EmployeeCredentials> logins = db.EmployeeCredential.ToList();
            foreach (EmployeeCredentials creds in logins)
            {
                if (uname == creds.Username && psw == creds.Password)
                {
                    currentEmployee = creds.EmployeeID;
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }

        // DISPLAY PENDING QUOTE REQUESTS
        public ActionResult PendingQuoteRequests()
        {
            var all = db.QuoteRequests.ToList();
            var reqs = new List<QuoteRequest>();
            foreach (QuoteRequest r in all)
            {
                if (r.Quote == null)
                {
                    reqs.Add(r);
                }
            }
            return View(reqs);
        }

        // BASIC QUOTE RESPONSE PAGE
        [HttpGet]
        public ActionResult Quote(int id)
        {
            ViewBag.id = id;
            ViewBag.quoter = db.QuoteRequests.Find(id);
            var assayrs = db.AssayRequests.SqlQuery("select * from assayrequest where quoterequestid = " + id.ToString()).ToList();
            ViewBag.assayrs = assayrs;
            return View();
        }

        [HttpPost]
        public ActionResult Quote(Quote quote, int id)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("PendingQuoteRequests");
        }

        public ActionResult WONeedingReports()
        {
            //var worders = db.WorkOrders.ToList();
            //var cWorders = new List<WorkOrder>();
            //foreach (var worder in worders)
            //{
            //    bool reportsNeeded = true;
            //    foreach (var sample in worder.Sample)
            //    {
            //        foreach (var tt in sample.TestTube)
            //        {
            //            if (tt.TestStatus != "Passed" && tt.TestStatus != "Failed")
            //            {
            //                reportsNeeded = false;
            //            }                                                //Work needed: get list with completed tests AND no summary report
            //        }
            //    }
            //    if (worderComplete)
            //    {
            //        cWorders.Add(worder);
            //    }
            //}
            //return View(cWorders);
            return View(db.WorkOrders.ToList()/*db.WorkOrders.SqlQuery("SELECT * FROM WorkOrder WHERE SummaryReport is NULL").ToList()*/);
        }

        public ActionResult ReportWorkOrder()
        {
            return View(db.WorkOrders.ToList().First());
        }

        public ActionResult WONeedingPricing()
        {
            return View(db.WorkOrders.ToList());
        }

        public ActionResult PriceWorkOrder()
        {
            return View(db.WorkOrders.ToList().First());
        }

        public ActionResult WONeedingBilling()
        {
            return View(db.WorkOrders.ToList());
        }

        public ActionResult BillWorkOrder()
        {
            return View(db.Invoices.ToList().First());
        }

        public ActionResult ViewReports()
        {
            return View();
        }
    }
}
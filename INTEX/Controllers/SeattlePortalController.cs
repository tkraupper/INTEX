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

        public static int currentEmployee = -1;


        public ActionResult testParent()
        {
            string info = "List of QuoteRequests with ArrayRequests:\n";
            var quoters = db.QuoteRequests.ToList();
            foreach (QuoteRequest quoter in quoters)
            {
                info += "QuoteRequest #" + quoter.QuoteRequestID + "\n";
                foreach (AssayRequest assayr in quoter.AssayRequests)
                {
                    info += "Assay #" + assayr.AssayID + "\n";
                }
            }

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

        // DISPLAY QUOTE REQUESTS
        public ActionResult PendingQuoteRequests()
        {
            //List<int> ids = db.Quotes.Where(null).Select(q => q.QuoteRequestID) //SqlQuery("SELECT QuoteRequestID FROM Quote");
            //var all = db.QuoteRequests.ToList();
            //var reqs = new List<QuoteRequest>();
            //foreach (QuoteRequest r in all)
            //{
            //    foreach (int id in ids)
            //    {
            //        if 
            //    }
            //}
            //return View(reqs);
            return View();
        }

        // BASIC QUOTE RESPONSE PAGE
        [HttpGet]
        public ActionResult Quote(int id)
        {
            ViewBag.id = id;
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
    }
}
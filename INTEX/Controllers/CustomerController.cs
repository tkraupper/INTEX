using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
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
            if (uname == "Missouri" && psw == "ShowMe")
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return View("Login");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Controllers
{
    public class SingaporePortalController : Controller
    {
        // GET: SingaporeEmployee
        public ActionResult Index()
        {
            return View();
        }

        //LOGIN METHODS FOR THE SINGAPORE EMPLOYEES
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string uname, string psw)
        {
            if (uname == "Missouri" && psw == "ShowMe")
            {
                return RedirectToAction("Index", "SingaporePortal");
            }
            else
            {
                return View("Login");
            }

        }
    }
}
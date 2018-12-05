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



        // BASIC QUOTE RESPONSE PAGE
        [HttpGet]
        public ActionResult Quote(int requestid)
        {
            return View();
        }
    }
}
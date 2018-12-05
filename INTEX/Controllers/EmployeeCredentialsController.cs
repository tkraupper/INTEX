using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX
{
    public class EmployeeCredentialsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: EmployeeCredentials
        public ActionResult Index()
        {
            var employeeCredential = db.EmployeeCredential.Include(e => e.Authorization);
            return View(employeeCredential.ToList());
        }

        // GET: EmployeeCredentials/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCredentials employeeCredentials = db.EmployeeCredential.Find(id);
            if (employeeCredentials == null)
            {
                return HttpNotFound();
            }
            return View(employeeCredentials);
        }

        // GET: EmployeeCredentials/Create
        public ActionResult Create()
        {
            ViewBag.AuthID = new SelectList(db.Authorizations, "AuthID", "AuthType");
            return View();
        }

        // POST: EmployeeCredentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Username,Password,AuthID")] EmployeeCredentials employeeCredentials)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeCredential.Add(employeeCredentials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthID = new SelectList(db.Authorizations, "AuthID", "AuthType", employeeCredentials.AuthID);
            return View(employeeCredentials);
        }

        // GET: EmployeeCredentials/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCredentials employeeCredentials = db.EmployeeCredential.Find(id);
            if (employeeCredentials == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthID = new SelectList(db.Authorizations, "AuthID", "AuthType", employeeCredentials.AuthID);
            return View(employeeCredentials);
        }

        // POST: EmployeeCredentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Username,Password,AuthID")] EmployeeCredentials employeeCredentials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeCredentials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthID = new SelectList(db.Authorizations, "AuthID", "AuthType", employeeCredentials.AuthID);
            return View(employeeCredentials);
        }

        // GET: EmployeeCredentials/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCredentials employeeCredentials = db.EmployeeCredential.Find(id);
            if (employeeCredentials == null)
            {
                return HttpNotFound();
            }
            return View(employeeCredentials);
        }

        // POST: EmployeeCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeCredentials employeeCredentials = db.EmployeeCredential.Find(id);
            db.EmployeeCredential.Remove(employeeCredentials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

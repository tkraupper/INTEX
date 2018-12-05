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
    public class CustomerCredentialsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: CustomerCredentials
        public ActionResult Index()
        {
            return View(db.CustomerCredential.ToList());
        }

        // GET: CustomerCredentials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCredentials customerCredentials = db.CustomerCredential.Find(id);
            if (customerCredentials == null)
            {
                return HttpNotFound();
            }
            return View(customerCredentials);
        }

        // GET: CustomerCredentials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerCredentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Username,Password")] CustomerCredentials customerCredentials)
        {
            if (ModelState.IsValid)
            {
                db.CustomerCredential.Add(customerCredentials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerCredentials);
        }

        // GET: CustomerCredentials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCredentials customerCredentials = db.CustomerCredential.Find(id);
            if (customerCredentials == null)
            {
                return HttpNotFound();
            }
            return View(customerCredentials);
        }

        // POST: CustomerCredentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Username,Password")] CustomerCredentials customerCredentials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerCredentials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerCredentials);
        }

        // GET: CustomerCredentials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCredentials customerCredentials = db.CustomerCredential.Find(id);
            if (customerCredentials == null)
            {
                return HttpNotFound();
            }
            return View(customerCredentials);
        }

        // POST: CustomerCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerCredentials customerCredentials = db.CustomerCredential.Find(id);
            db.CustomerCredential.Remove(customerCredentials);
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

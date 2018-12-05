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
    public class AuthorizationsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: Authorizations
        public ActionResult Index()
        {
            return View(db.Authorizations.ToList());
        }

        // GET: Authorizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // GET: Authorizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthID,AuthType")] Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                db.Authorizations.Add(authorization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorization);
        }

        // GET: Authorizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // POST: Authorizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthID,AuthType")] Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorization);
        }

        // GET: Authorizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // POST: Authorizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authorization authorization = db.Authorizations.Find(id);
            db.Authorizations.Remove(authorization);
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

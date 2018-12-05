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
    public class QuoteRequestsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: QuoteRequests
        public ActionResult Index()
        {
            var quoteRequests = db.QuoteRequests.Include(q => q.Customer);
            return View(quoteRequests.ToList());
        }

        // GET: QuoteRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteRequest quoteRequest = db.QuoteRequests.Find(id);
            if (quoteRequest == null)
            {
                return HttpNotFound();
            }
            return View(quoteRequest);
        }

        // GET: QuoteRequests/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            return View();
        }

        // POST: QuoteRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteRequestID,CustomerID")] QuoteRequest quoteRequest)
        {
            if (ModelState.IsValid)
            {
                db.QuoteRequests.Add(quoteRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", quoteRequest.CustomerID);
            return View(quoteRequest);
        }

        // GET: QuoteRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteRequest quoteRequest = db.QuoteRequests.Find(id);
            if (quoteRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", quoteRequest.CustomerID);
            return View(quoteRequest);
        }

        // POST: QuoteRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteRequestID,CustomerID")] QuoteRequest quoteRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quoteRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", quoteRequest.CustomerID);
            return View(quoteRequest);
        }

        // GET: QuoteRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteRequest quoteRequest = db.QuoteRequests.Find(id);
            if (quoteRequest == null)
            {
                return HttpNotFound();
            }
            return View(quoteRequest);
        }

        // POST: QuoteRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuoteRequest quoteRequest = db.QuoteRequests.Find(id);
            db.QuoteRequests.Remove(quoteRequest);
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

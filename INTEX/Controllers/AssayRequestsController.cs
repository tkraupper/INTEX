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
    public class AssayRequestsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: AssayRequests
        public ActionResult Index()
        {
            var assayRequests = db.AssayRequests.Include(a => a.Assay).Include(a => a.Compound).Include(a => a.QuoteRequest);
            return View(assayRequests.ToList());
        }

        // GET: AssayRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayRequest assayRequest = db.AssayRequests.Find(id);
            if (assayRequest == null)
            {
                return HttpNotFound();
            }
            return View(assayRequest);
        }

        // GET: AssayRequests/Create
        public ActionResult Create()
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName");
            ViewBag.QuoteRequestID = new SelectList(db.QuoteRequests, "QuoteRequestID", "QuoteRequestID");
            return View();
        }

        // POST: AssayRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteRequestID,LTNumber,AssayID")] AssayRequest assayRequest)
        {
            if (ModelState.IsValid)
            {
                db.AssayRequests.Add(assayRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", assayRequest.AssayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName", assayRequest.LTNumber);
            ViewBag.QuoteRequestID = new SelectList(db.QuoteRequests, "QuoteRequestID", "QuoteRequestID", assayRequest.QuoteRequestID);
            return View(assayRequest);
        }

        // GET: AssayRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayRequest assayRequest = db.AssayRequests.Find(id);
            if (assayRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", assayRequest.AssayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName", assayRequest.LTNumber);
            ViewBag.QuoteRequestID = new SelectList(db.QuoteRequests, "QuoteRequestID", "QuoteRequestID", assayRequest.QuoteRequestID);
            return View(assayRequest);
        }

        // POST: AssayRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteRequestID,LTNumber,AssayID")] AssayRequest assayRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assayRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", assayRequest.AssayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName", assayRequest.LTNumber);
            ViewBag.QuoteRequestID = new SelectList(db.QuoteRequests, "QuoteRequestID", "QuoteRequestID", assayRequest.QuoteRequestID);
            return View(assayRequest);
        }

        // GET: AssayRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayRequest assayRequest = db.AssayRequests.Find(id);
            if (assayRequest == null)
            {
                return HttpNotFound();
            }
            return View(assayRequest);
        }

        // POST: AssayRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssayRequest assayRequest = db.AssayRequests.Find(id);
            db.AssayRequests.Remove(assayRequest);
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

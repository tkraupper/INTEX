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
    public class PriceChangesController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: PriceChanges
        public ActionResult Index()
        {
            var priceChanges = db.PriceChanges.Include(p => p.WorkOrder);
            return View(priceChanges.ToList());
        }

        // GET: PriceChanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceChange priceChange = db.PriceChanges.Find(id);
            if (priceChange == null)
            {
                return HttpNotFound();
            }
            return View(priceChange);
        }

        // GET: PriceChanges/Create
        public ActionResult Create()
        {
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate");
            return View();
        }

        // POST: PriceChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceChangeID,WorkOrderID,Amount,Reason,Date")] PriceChange priceChange)
        {
            if (ModelState.IsValid)
            {
                db.PriceChanges.Add(priceChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate", priceChange.WorkOrderID);
            return View(priceChange);
        }

        // GET: PriceChanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceChange priceChange = db.PriceChanges.Find(id);
            if (priceChange == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate", priceChange.WorkOrderID);
            return View(priceChange);
        }

        // POST: PriceChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceChangeID,WorkOrderID,Amount,Reason,Date")] PriceChange priceChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate", priceChange.WorkOrderID);
            return View(priceChange);
        }

        // GET: PriceChanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceChange priceChange = db.PriceChanges.Find(id);
            if (priceChange == null)
            {
                return HttpNotFound();
            }
            return View(priceChange);
        }

        // POST: PriceChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceChange priceChange = db.PriceChanges.Find(id);
            db.PriceChanges.Remove(priceChange);
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

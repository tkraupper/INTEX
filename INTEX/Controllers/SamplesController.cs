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
    public class SamplesController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: Samples
        public ActionResult Index()
        {
            var samples = db.Samples.Include(s => s.Assay).Include(s => s.Compound).Include(s => s.WorkOrder);
            return View(samples.ToList());
        }

        // GET: Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // GET: Samples/Create
        public ActionResult Create()
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName");
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate");
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompoundSequenceCode,LTNumber,WorkOrderID,AssayID,IndicatedWeight,ActualWeight,QuantityInMilligrams,DateArrived,ReceivedBy,DateDue,Appearance,MolecularMass,MTD,SecondaryTestingApproval,AnalysisReport")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Samples.Add(sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", sample.AssayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName", sample.LTNumber);
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate", sample.WorkOrderID);
            return View(sample);
        }

        // GET: Samples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", sample.AssayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName", sample.LTNumber);
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate", sample.WorkOrderID);
            return View(sample);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompoundSequenceCode,LTNumber,WorkOrderID,AssayID,IndicatedWeight,ActualWeight,QuantityInMilligrams,DateArrived,ReceivedBy,DateDue,Appearance,MolecularMass,MTD,SecondaryTestingApproval,AnalysisReport")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", sample.AssayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName", sample.LTNumber);
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate", sample.WorkOrderID);
            return View(sample);
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sample sample = db.Samples.Find(id);
            db.Samples.Remove(sample);
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

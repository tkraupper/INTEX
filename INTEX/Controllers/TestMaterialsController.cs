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
    public class TestMaterialsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: TestMaterials
        public ActionResult Index()
        {
            var testMaterials = db.TestMaterials.Include(t => t.Material).Include(t => t.Test);
            return View(testMaterials.ToList());
        }

        // GET: TestMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMaterial testMaterial = db.TestMaterials.Find(id);
            if (testMaterial == null)
            {
                return HttpNotFound();
            }
            return View(testMaterial);
        }

        // GET: TestMaterials/Create
        public ActionResult Create()
        {
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName");
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestDescription");
            return View();
        }

        // POST: TestMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestID,MaterialID,QuantityUsed")] TestMaterial testMaterial)
        {
            if (ModelState.IsValid)
            {
                db.TestMaterials.Add(testMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", testMaterial.MaterialID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestDescription", testMaterial.TestID);
            return View(testMaterial);
        }

        // GET: TestMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMaterial testMaterial = db.TestMaterials.Find(id);
            if (testMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", testMaterial.MaterialID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestDescription", testMaterial.TestID);
            return View(testMaterial);
        }

        // POST: TestMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestID,MaterialID,QuantityUsed")] TestMaterial testMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", testMaterial.MaterialID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestDescription", testMaterial.TestID);
            return View(testMaterial);
        }

        // GET: TestMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMaterial testMaterial = db.TestMaterials.Find(id);
            if (testMaterial == null)
            {
                return HttpNotFound();
            }
            return View(testMaterial);
        }

        // POST: TestMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestMaterial testMaterial = db.TestMaterials.Find(id);
            db.TestMaterials.Remove(testMaterial);
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

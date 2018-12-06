using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX.Controllers
{
    public class SingaporePortalController : Controller
    {
        //VARIABLES
        private IntexContext db = new IntexContext();
        public static List<TestTube> activeList = new List<TestTube>();
        public static List<Sample> associatedSampleList = new List<Sample>();
        public static int currentEmployee = -1;
        public static int currentCompoundSequenceCode = -1;
        public static int currentLTNumber = -1;
        public static int currentWorkOrderID = -1;




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

        //METHOD TO CONFIRM WORK ORDER AND SEND EMAIL TO CUSTOMER
        public ActionResult ConfirmWorkOrder()
        {
            //List<Sample> samplesTable = db.Samples.ToList();
            //foreach (Sample samples in samplesTable)
            //{
            //    //if (currentSample == -1)
            //    //{
            //    //    currentSample = samples.CompoundSequenceCode;
            //    //    return RedirectToAction("Index");
            //    //}
            //}
            Sample sample = db.Samples.Find(currentCompoundSequenceCode, currentLTNumber);
            return View(sample);
        }



        //ALL THE WORK ORDER METHODS

        // GET: WorkOrders
        public ActionResult WorkOrderIndex()
        {
            var workOrders = db.WorkOrders.Include(w => w.Customer);
            return View(workOrders.ToList());
        }
    

        // GET: WorkOrders/Details/5
        public ActionResult WorkOrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult WorkOrderEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactID = new SelectList(db.ContactInfos, "ContactID", "Address", workOrder.ContactID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", workOrder.CustomerID);
            ViewBag.PayInfoID = new SelectList(db.PayInfos, "PayInfoID", "Card", workOrder.PayInfoID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", workOrder.QuoteID);
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkOrderEdit([Bind(Include = "WorkOrderID,QuoteID,ConfirmationSentDate,CustomerID,ContactID,PayInfoID,Comments,SummaryReport")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactID = new SelectList(db.ContactInfos, "ContactID", "Address", workOrder.ContactID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", workOrder.CustomerID);
            ViewBag.PayInfoID = new SelectList(db.PayInfos, "PayInfoID", "Card", workOrder.PayInfoID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", workOrder.QuoteID);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult WorkOrderDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult WorkOrderDeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            db.WorkOrders.Remove(workOrder);
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




        // GET: Samples
        public ActionResult SamplesIndex(int? id)
        {
            var samples = db.Samples.Include(s => s.Assay).Include(s => s.Compound).Include(s => s.WorkOrder);

            foreach (var item in samples.ToList())
            {
                if (item.WorkOrderID == id)
                {
                    currentWorkOrderID = Convert.ToInt32(id);
                    associatedSampleList.Add(item);
                }
            }
            return View(associatedSampleList);
        }

        // GET: Samples/Details/5
        public ActionResult SamplesDetails(int? id, int? cpk)
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
        public ActionResult SamplesCreate(int id)
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "CompoundName");
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "ConfirmationSentDate");

            ViewBag.workit = db.WorkOrders.Find(id);
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SamplesCreate([Bind(Include = "CompoundSequenceCode,LTNumber,WorkOrderID,AssayID,IndicatedWeight,ActualWeight,QuantityInMilligrams,DateArrived,RecievedBy,DateDue,Appearance,MolecularMass,MTD,SecondaryTestingApproval,AnalysisReport")] Sample sample)
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
        public ActionResult SamplesEdit(int? id, int? cpk)
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
        public ActionResult SamplesEdit([Bind(Include = "CompoundSequenceCode,LTNumber,WorkOrderID,AssayID,IndicatedWeight,ActualWeight,QuantityInMilligrams,DateArrived,RecievedBy,DateDue,Appearance,MolecularMass,MTD,SecondaryTestingApproval,AnalysisReport")] Sample sample)
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
        public ActionResult SamplesDelete(int? id, int? cpk)
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
        public ActionResult SamplesDeleteConfirmed(int id, int cpk)
        {
            Sample sample = db.Samples.Find(id);
            db.Samples.Remove(sample);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        //THIS METHOD MAKES A LIST OF WORK ORDERS THAT HAVE A TestStatus OF "RECEIVED", PRETTY MUCH WAITING TO BE
        //SCHEDULED AND TAKES THE ONES WITH THIS STATUS AND MAKES A LIST TO BE PRINTED OR SO THEY CAN BE SCHEDULED
        public ActionResult ActiveWorkOrderIndex()
        {
            var workOrders = db.WorkOrders.Include(t => t.Sample);
            foreach (var item in workOrders.ToList())
            {
                if (item.Sample.CompoundSequenceCode == null)
                {
                    activeList.Add(item);
                }
            }

            return View(activeList);
        }


        //THIS METHOD TAKES YOU TO A VIEW THAT WILL LET YOU SCHEDULE THE INDIVIDUAL TESTS FOR A WORK ORDER
        [HttpGet]
        public ActionResult ScheduleTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTube testTube = db.TestTubes.Find(id);
            if (testTube == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompoundSequenceCode = new SelectList(db.Samples, "CompoundSequenceCode", "DateArrived", testTube.CompoundSequenceCode);
            return View(testTube);
        }

        // POST: TestTubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleTest([Bind(Include = "TestTubeID,LTNumber,CompoundSequenceCode,TestID,ActualCost,TestDateTime,TestStatus,Predecessor")] TestTube testTube)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testTube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompoundSequenceCode = new SelectList(db.Samples, "CompoundSequenceCode", "DateArrived", testTube.CompoundSequenceCode);
            return View(testTube);
        }
    }
}
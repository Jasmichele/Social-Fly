using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialFly;

namespace SocialFly.Controllers
{
    public class CompensationsController : Controller
    {
        private SocialBEntities db = new SocialBEntities();

        // GET: Compensations
        public ActionResult Index()
        {
            return View(db.Compensations.ToList());
        }

        // GET: Compensations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compensation compensation = db.Compensations.Find(id);
            if (compensation == null)
            {
                return HttpNotFound();
            }
            return View(compensation);
        }

        // GET: Compensations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compensations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompId,CompPay")] Compensation compensation)
        {
            if (ModelState.IsValid)
            {
                db.Compensations.Add(compensation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compensation);
        }

        // GET: Compensations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compensation compensation = db.Compensations.Find(id);
            if (compensation == null)
            {
                return HttpNotFound();
            }
            return View(compensation);
        }

        // POST: Compensations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompId,CompPay")] Compensation compensation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compensation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compensation);
        }

        // GET: Compensations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compensation compensation = db.Compensations.Find(id);
            if (compensation == null)
            {
                return HttpNotFound();
            }
            return View(compensation);
        }

        // POST: Compensations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compensation compensation = db.Compensations.Find(id);
            db.Compensations.Remove(compensation);
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

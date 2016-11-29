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
    public class SocialUsersController : Controller
    {
        private SocialBEntities db = new SocialBEntities();

        // GET: SocialUsers
        public ActionResult Index()
        {
            var socialUsers = db.SocialUsers.Include(s => s.Compensation).Include(s => s.Follower).Include(s => s.Region);
            return View(socialUsers.ToList());
        }

        // GET: SocialUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialUser socialUser = db.SocialUsers.Find(id);
            if (socialUser == null)
            {
                return HttpNotFound();
            }
            return View(socialUser);
        }

        // GET: SocialUsers/Create
        public ActionResult Create()
        {
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay");
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount");
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");
            return View();
        }

        // POST: SocialUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SociaLId,Name,SocailMName,FollowerCountId,RegionId,CompId,Email,Image_")] SocialUser socialUser)
        {
            if (ModelState.IsValid)
            {
                db.SocialUsers.Add(socialUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", socialUser.CompId);
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount", socialUser.FollowerCountId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", socialUser.RegionId);
            return View(socialUser);
        }

        // GET: SocialUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialUser socialUser = db.SocialUsers.Find(id);
            if (socialUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", socialUser.CompId);
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount", socialUser.FollowerCountId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", socialUser.RegionId);
            return View(socialUser);
        }

        // POST: SocialUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SociaLId,Name,SocailMName,FollowerCountId,RegionId,CompId,Email,Image_")] SocialUser socialUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", socialUser.CompId);
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount", socialUser.FollowerCountId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", socialUser.RegionId);
            return View(socialUser);
        }

        // GET: SocialUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialUser socialUser = db.SocialUsers.Find(id);
            if (socialUser == null)
            {
                return HttpNotFound();
            }
            return View(socialUser);
        }

        // POST: SocialUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialUser socialUser = db.SocialUsers.Find(id);
            db.SocialUsers.Remove(socialUser);
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

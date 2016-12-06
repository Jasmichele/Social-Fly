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
    public class BrandsController : Controller
    {
        private SocialBEntities db = new SocialBEntities();

        // GET: Brands
        [Authorize]
        public ActionResult Index()
        {
            var brands = db.Brands.Include(b => b.Compensation).Include(b => b.Post);
            return View(brands.ToList());
        }

        // GET: Brands/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay");
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostNum");
            return View();
        }
        [Authorize]
        public ActionResult CreateBrand(Brand brandN)
        {
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay");
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostNum");
            return View(brandN);
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("CreateBrand")]
        //public ActionResult CreateBrandPost([Bind(Include = "BrandId,CompanyName,Product,ProductDescription,PostId,CompId")] Brand brandN)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Brands.Add(brandN);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", brandN.CompId);
        //    ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostNum", brandN.PostId);
        //    return View(brandN);
        //}

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateBrand")]
        public ActionResult CreateBrandPost([Bind(Include = "BrandId,CompanyName,Product,ProductDescription,PostId,CompId,Email")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", brand.CompId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostNum", brand.PostId);
            return View(brand);
        }

        // GET: Brands/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", brand.CompId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostNum", brand.PostId);
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandId,CompanyName,Product,ProductDescription,PostId,CompId,Email")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", brand.CompId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostNum", brand.PostId);
            return View(brand);
        }

        // GET: Brands/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
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

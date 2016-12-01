using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialFly.Controllers
{
    public class SocialAuthController : Controller
    {
        SocialBEntities db = new SocialBEntities();
        // GET: SocialAuth
        public ActionResult Index()
        {
            return View();
        }

        // GET: SocialAuth/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SocialAuth/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialAuth/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialAuth/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocialAuth/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialAuth/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SocialAuth/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Button()
        {
            return View();
        }
    }

    [HttpPost]
    public ActionResult Button(string brand, string social)
    {

    }
}

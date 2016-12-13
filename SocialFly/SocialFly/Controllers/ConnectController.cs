using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialFly.Models;

namespace SocialFly.Controllers
{
    public class ConnectController : Controller
    {
        SocialBEntities db = new SocialBEntities();
        // GET: Connect
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetByFilter()
        {
            ConnectModel looking = new ConnectModel();

            SocialBEntities db = new SocialBEntities();
            looking.Followers = db.Followers.ToList();
            looking.Regions = db.Regions.ToList();
            looking.Compensation = db.Compensations.ToList();

             return View(looking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetByFilter(FormCollection form)
        {
            string reg = form["Region"].ToString();
            string fol = form["Follower"].ToString();
            string com = form["Compensation"].ToString();

            return RedirectToAction("GetUsers", new { rid = reg, fid = fol, cid = com });
        }

        public ActionResult GetUsers(int? rid, int? fid, int? cid)
        {
          
            var socialUsers = from su in db.SocialUsers
                              select su;
            var filteredUsers = socialUsers;

            int tempRid = Convert.ToInt32(rid);
            int tempFid = Convert.ToInt32(fid);
            int tempCid = Convert.ToInt32(cid);

            if (rid != null)
                filteredUsers = filteredUsers.Where(s => s.RegionId == tempRid);

            if (fid != null)
                filteredUsers = filteredUsers.Where(s => s.FollowerCountId == tempFid);

            if (cid != null)
                filteredUsers = filteredUsers.Where(s => s.CompId == tempCid);

            return View(filteredUsers);
        }

        public ActionResult ShowAll()
        {
            var socialUsers = from su in db.SocialUsers
                              select su;

            return View(socialUsers);
        }

        public ActionResult ShowBrand()
        {
            var brands = from b in db.Brands
                         select b;

            return View(brands);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection sr)
        {
            var sw = sr["search"];

            var socialUsers = from su in db.SocialUsers
                              where su.SocailMName == sw
                              select su;
           
                //socialUsers = socialUsers.Where(s => s.SocailMName == sr);

                return View(socialUsers);
         
        }
    }


}
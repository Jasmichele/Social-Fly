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

        public IEnumerable<SocialUser> GetByFilter(int? rid, int? fid, int? cid)
        {
            var socialUsers = from su in db.SocialUsers
                              select su;
            var filteredUsers = socialUsers;

            if (rid != null)
                filteredUsers = socialUsers.Where(s => s.RegionId == rid);

            if (fid != null)
                filteredUsers = socialUsers.Where(s => s.FollowerCountId == fid);

            if (cid != null)
                filteredUsers = socialUsers.Where(s => s.CompId == cid);

             return filteredUsers;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialFly.Models;
using SocialFly;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SocialFly.Controllers
{
    public class SocialUsersController : Controller
    {
        private SocialBEntities db = new SocialBEntities();

        // GET: SocialUsers
        [Authorize]
        public ActionResult Index()
        {
            var socialUsers = from su in db.SocialUsers
                              where su.Email == User.Identity.Name
                              select su;
    
            return View(socialUsers);
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

            ESoc su = new ESoc();
            su.MyUser = socialUser;
            su.Email = User.Identity.Name;

            return View(su);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(FormCollection email)
        {
       

                 var body = "<p>Email From: {0} </p><p>Message:</p><p>{1}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(email["MyUser.Email"]));
                message.From = new MailAddress("socialflyy@outlook.com");
                message.Subject = "Contact";
                message.Body = string.Format(body ,email["Email"], email["Message"]);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "socialflyy@outlook.com",
                        Password = "Sf05160581",
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            
            //return View(email);
        }

        public ActionResult Sent()
        {
            return View();
        }

        // GET: SocialUsers/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay");
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount");
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");
            return View();
        }

        // GET: SocialUsers/Create
        [Authorize]
        [HttpGet]
        public ActionResult CreateSocial(SocialUser su)
        {
            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay");
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount");
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");
            return View(su);
        }

        // POST: SocialUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateSocial")]
        public ActionResult CreateSocialPost([Bind(Include = "SociaLId,Name,SocailMName,FollowerCountId,RegionId,CompId,Email,Image_")]SocialUser su)
        {
            if (ModelState.IsValid)
            {
                db.SocialUsers.Add(su);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompId = new SelectList(db.Compensations, "CompId", "CompPay", su.CompId);
            ViewBag.FollowerCountId = new SelectList(db.Followers, "FollowerId", "FollowerCount", su.FollowerCountId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", su.RegionId);
            return View(su);
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

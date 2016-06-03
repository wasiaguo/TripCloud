using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private CloudTripEntities4 db = new CloudTripEntities4();

        // GET: Friends
        public ActionResult Index()
        {
            var user = db.User.Where(x => x.Account.Equals(User.Identity.Name)).First();

            var friend = db.Friend.Where(x=>(x.UserId== user.UserId) ||(x.FriendId==user.UserId));

            return View(friend.ToList());
        }

        public ActionResult Create(string Account)
        {
            string searchID = null;

            searchID = (from s in db.User
                        where s.Account == Account
                        select s.Account).FirstOrDefault();



            if (!String.IsNullOrEmpty(searchID))
            {
                var result = (from s in db.User
                              where s.Account == searchID
                              select s).ToList();
                return View(result);
            }

            else
            {
                return View(new List<User>());
            }

        }



        [HttpPost]
        public Boolean AddFriend(int? id)
        {
            if (id == null)
            {
                return false; //new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int userid = (from s in db.User
                          where s.Account == User.Identity.Name
                          select s.UserId).FirstOrDefault();

            User friend = db.User.Find(id);

            Friend addfriend = new Friend()
            {
                FriendId = friend.UserId,
                UserId = userid,
                checkfreind = false,

            };
            db.Friend.Add(addfriend);
            db.SaveChanges();

            return true;
        }

       
        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.Friend.Find(id);
            db.Friend.Remove(friend);
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

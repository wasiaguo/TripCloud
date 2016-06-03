using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class RecommendController : Controller
    {
        CloudTripEntities4 db = new CloudTripEntities4();

        // GET: Recommed
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FriendRecommend()
        {
            
            return View();
        }

        
        public ActionResult StartFrienRecommend(string action)
        {
            ViewBag.Start = true;
            return View("FriendRecommend");
        }

        public ActionResult StartPOIRecommend(string action)
        {
            ViewBag.Start = true;
            return View("POIRecommend");
        }

        public ActionResult POIRecommend()
        {
            return View();
        }

    }
}
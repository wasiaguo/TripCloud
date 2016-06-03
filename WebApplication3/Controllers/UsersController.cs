using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private CloudTripEntities4 db = new CloudTripEntities4();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        public ActionResult Test()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            UserRegisterVM model = new UserRegisterVM()
            {
                ShoppingPOIs = new List<ScorePOIModel>(),
                LandscapePOIs = new List<ScorePOIModel>(),
                ReligionPOIs = new List<ScorePOIModel>(),
                HumanitiesPOIs = new List<ScorePOIModel>(),
                HistoricalSitePOIs =new List<ScorePOIModel>(),
                user =new User()
            };

            

            //載入購物類景點
            string[] ShoppingName = { "台中中友百貨", "一中街商圈", "台中逢甲商圈", "豐原廟東夜市", "台中大遠百" };
            int i = 1;
            foreach (string name in ShoppingName)
            {
                ScorePOIModel POI = new ScorePOIModel()
                {
                    POIName = name,
                    ImgUrl = "../Images/ScorePOI/Shopping/Shopping" + i.ToString() + ".jpg",
                    type = "Shopping"
                };
                i++;
                model.ShoppingPOIs.Add(POI);
            }

            //載入風景類景點
            string[] LandscapeName = { "高美濕地", "誠品綠園道", "大坑風景區", "秋紅谷", "台中中山公園" };
            i = 1;
            foreach (string name in LandscapeName)
            {
                ScorePOIModel POI = new ScorePOIModel()
                {
                    POIName = name,
                    ImgUrl = "../Images/ScorePOI/Landscape/Landscape" + i.ToString() + ".jpg",
                    type = "Landscape"
                };
                i++;
                model.LandscapePOIs.Add(POI);
            }

            //載入宗教類景點
            string[] ReligionName = { "台中文昌廟", "豐原慈濟宮", "清水紫雲巖", "台中孔廟","台中天后宮" };
            i = 1;
            foreach (string name in ReligionName)
            {
                ScorePOIModel POI = new ScorePOIModel()
                {
                    POIName = name,
                    ImgUrl = "../Images/ScorePOI/Religion/Religion"+i.ToString()+".jpg",
                    type = "Religion"
                };
                i++;
                model.ReligionPOIs.Add(POI);
            }

            //載入人文類景點
            string[] HumanitiesName = { "國立自然博物館", "國立台灣美術館", "台中火車站", "台中創意園區","彩虹眷村" };
            i = 1;
            foreach (string name in HumanitiesName)
            {
                ScorePOIModel POI = new ScorePOIModel()
                {
                    POIName = name,
                    ImgUrl = "../Images/ScorePOI/Humanities/Humanities" + i.ToString() + ".jpg",
                    type = "Humanities"
                };
                i++;
                model.HumanitiesPOIs.Add(POI);
            }

            //載入古蹟類景點
            string[] HistoricalSiteName = { "摘星山莊", "霧峰林家", "台中州廳", "臺中刑務所演武場", "台中放送局" };
            i = 1;
            foreach (string name in HistoricalSiteName)
            {
                ScorePOIModel POI = new ScorePOIModel()
                {
                    POIName = name,
                    ImgUrl = "../Images/ScorePOI/HistoricalSite/HistoricalSite" + i.ToString() + ".jpg",
                    type = "HistoricalSite"
                };
                i++;
                model.HistoricalSitePOIs.Add(POI);
            }



            return View(model);
        }

        // POST: Users/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegisterVM model)
        {
            
            
            if (ModelState.IsValid)
            {
                db.User.Add(model.user);
                db.SaveChanges();
                
            }

            return RedirectToAction("Index","Home");

        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Account,Password,Friend,Age,Eduction,Consumption,ShoppingScore,LandscapeScore,ReligionScore,HumanitiesScore,HistoricalSiteScore")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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

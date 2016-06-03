using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication3;

namespace WebApplication3.Controllers
{
    public class DinariesController : Controller
    {
        private CloudTripEntities4 db = new CloudTripEntities4();
     
        // GET: Dinaries

        /*public ActionResult LoadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadImage(HttpPostedFileBase imgFile)
        {
            if (imgFile != null)
            {
                int length = imgFile.ContentLength;
                byte[] buffer = new byte[length];
                imgFile.InputStream.Read(buffer, 0, length);
                
                    Dinary di = new Dinary
                    {
                        picture = buffer,
                        picturetype = imgFile.ContentType

                    };

                    db.Dinary.Add(di);
                    db.SaveChanges();



                


            }
            else
                ModelState.AddModelError("", "需選擇一張圖片!");
            return View();
        }*/






        public FileContentResult GetImage(int id)
        {
            var item = db.Dinary.Where(e => e.DinaryId == id).SingleOrDefault();

            if(item.picturetype != null)
            {
                byte[] img = item.picture;
                return new FileContentResult(img, item.picturetype);

            }
            else
                {
                return null;
            }

        }


        public ActionResult Index()
        {
            var dinary = db.Dinary.Include(d => d.User);
            return View(dinary.ToList());
        }

        // GET: Dinaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dinary dinary = db.Dinary.Find(id);
            if (dinary == null)
            {
                return HttpNotFound();
            }
            return View(dinary);
        }

        // GET: Dinaries/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User, "UserId", "Name");
            return View();
        }

        // POST: Dinaries/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "DinaryId,mood,weather,write,UserId,picture,picturetype,FbName")] Dinary dinary, HttpPostedFileBase imgFile)
        {
  
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    /* var extension = Path.GetExtension(imgFile.FileName);
                     var allowedExtensions = new[] { ".png", ".gif", ".jpg", ".jpeg" };
                     List<Dinary> results = new List<Dinary>();

                     if(imgFile.ContentLength > 1024*1024)
                     {
                         results.Add(new Dinary()
                         {
                             IsValid = false,
                             length = imgFile.ContentLength,
                             Message = "圖片尺寸不能超過1024KB",
                             picturetype = imgFile.ContentType
                         });
                     }

                     else if(!allowedExtensions.Contains(extension))//如果文件的后缀名不包含在规定的后缀数组中
                         {
                         results.Add(new Dinary()
                         {

                             IsValid = false,
                             length = imgFile.ContentLength,
                             Message = "圖片格式必须是png、gif、jpg或jpeg",
                             picturetype = imgFile.ContentType
                         });
                     }

                     else { */

             



                    int length = imgFile.ContentLength;
                    byte[] buffer = new byte[length];  
                    imgFile.InputStream.Read(buffer, 0, length);


                    dinary.picture = ImageHelper.ReImage(buffer, 300, 300);
                    dinary.picturetype = imgFile.ContentType;

                   // }

                   
                }

                
                db.Dinary.Add(dinary);
                db.SaveChanges();               
                    return RedirectToAction("Index");
                
           }

            ViewBag.UserId = new SelectList(db.User, "UserId", "Name", dinary.UserId);
            return View(dinary);
        }





        // GET: Dinaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dinary dinary = db.Dinary.Find(id);
            if (dinary == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User, "UserId", "Name", dinary.UserId);
            return View(dinary);
        }

        // POST: Dinaries/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DinaryId,mood,weather,write,UserId,picturetype,FbName,picture")] Dinary dinary, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    int length = imgFile.ContentLength;
                    byte[] buffer = new byte[length];
                    imgFile.InputStream.Read(buffer, 0, length);


                    dinary.picture = ImageHelper.ReImage(buffer, 300, 300);
                    dinary.picturetype = imgFile.ContentType;
                }
                db.Entry(dinary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "UserId", "Name", dinary.UserId);
            return View(dinary);
        }

        // GET: Dinaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dinary dinary = db.Dinary.Find(id);
            if (dinary == null)
            {
                return HttpNotFound();
            }
            return View(dinary);
        }

        // POST: Dinaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dinary dinary = db.Dinary.Find(id);
            db.Dinary.Remove(dinary);
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

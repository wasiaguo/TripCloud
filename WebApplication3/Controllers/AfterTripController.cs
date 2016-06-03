using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class AfterTripController : Controller
    {

        CloudTripEntities4 db = new CloudTripEntities4();

        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

   


    }
}
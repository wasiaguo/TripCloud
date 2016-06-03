using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        CloudTripEntities4 db = new CloudTripEntities4();



          public ActionResult Index()
        {
            HttpBrowserCapabilitiesBase userBrowser = Request.Browser;
            String browserName = userBrowser.Browser.ToString();
            String browserVersion = userBrowser.Version.ToString();
            ViewBag.name = browserName;





            ViewBag.WebName = "銀髮族旅遊雲";

            if (browserName.Equals("IE"))
            {
                ViewBag.warning = "您目前的瀏覽器為" + browserName + browserVersion
                                    + "建議更換為Chrome或FireFox或者升級為IE版本11以上，否則可能導致部分功能無法執行";

            }



            return View();
        }

        public ActionResult Map()
        {
            return View();
        }


        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(User user_account)
        {
            ViewBag.WebName = "銀髮族旅遊雲";
            if (ModelState.IsValid)
            {
                MD5 md5 = MD5.Create();
                byte[] source = Encoding.Default.GetBytes(user_account.Account + user_account.Password);
                byte[] crypto = md5.ComputeHash(source);//進行MD5加密
                string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

                user_account.Password = result;

            }

            return View(user_account);
        }
        

        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
           /* ViewBag.WebName = "銀髮族旅遊雲";
            if (User.Identity.IsAuthenticated)
            {
                //導向預設Url(Web.config裡的defaultUrl定義)或使用者原先Request的Url
                return Redirect(Url.Action("Index"));
            }*/


            //ReturnUrl字串是使用者在未登入情況下要求的的Url
            LoginViewModel vm = new LoginViewModel() { ReturnUrl = ReturnUrl };
            return View(vm);
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            //沒通過Model驗證(必填欄位沒填，DB無此帳密)
            if (!ModelState.IsValid)
            {
                //將驗證失敗訊息傳回首頁
                return View(user);
            }

            //進行表單登入 

            // this.LoginProcess(user);


            //導向預設Url(Web.config裡的defaultUrl定義)或使用者原先Request的Url


            FormsAuthentication.RedirectFromLoginPage(user.Account, false);

            return Redirect(FormsAuthentication.GetRedirectUrl(user.Account,false));
                
            

        }


        private void LoginProcess(LoginViewModel userLoginData)
        {
            var now = DateTime.Now;
            //取得角色
            

            //設定表單票證
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: userLoginData.Account.ToString(),
                issueDate: now,
                expiration: now.AddMinutes(30),
                isPersistent: userLoginData.Remember,
                userData: null,
                cookiePath: FormsAuthentication.FormsCookiePath);

            //建立表單票證
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //存成Cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        } 


        [AllowAnonymous]
        public ActionResult Logout()
        {
            //清除Session中的資料
            Session.Abandon();
            //登出表單驗證
            FormsAuthentication.SignOut();
            //導至登入頁
            return RedirectToAction("Index", "Home");
        }


     /*   public ActionResult Index()
        {
            //取得目前登入者的帳號
            string Account = User.Identity.Name;
            //可以依帳號到DB抓登入者的資料...





            return View();
        }*/

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


      

    }
}
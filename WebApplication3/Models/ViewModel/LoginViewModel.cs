using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace WebApplication3.Models.ViewModel
{
    public class LoginViewModel : IValidatableObject
    {

        //返回位置
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ReturnUrl { get; set; }


        //帳號
        [Display(Name = "帳號:")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required]
        public string Account { get; set; }

        // 密碼
        [Display(Name = "密碼:")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required]
        public string Password { get; set; }

        // 密碼
        [Display(Name = "記住我")]
        public Boolean Remember { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {


            CloudTripEntities4 db = new CloudTripEntities4();
           var list = db.User.ToList();

          /*  MD5 md5 = MD5.Create();
            byte[] source = Encoding.Default.GetBytes(Account + Password);//將欲加密字串轉成Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            Password = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串*/

            User FindUser = list.Find(x => x.Account.Equals(Account));
            if (FindUser == null)
                yield return new ValidationResult("無此帳號", new string[] { "Account" });
            else
            {
                if (!(FindUser.Password.Equals(Password)))
                    yield return new ValidationResult("密碼錯誤", new string[] { "Password" });
            }


        }
    }

}
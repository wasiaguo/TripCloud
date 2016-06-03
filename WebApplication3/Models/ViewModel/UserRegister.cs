using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using WebApplication3.Models;
using WebApplication3.Models.ViewModel;
using System.Text;
using System.Security.Cryptography;


namespace WebApplication3.Models.ViewModel
{
    public class UserRegisterClass : IValidatableObject
    {

        CloudTripEntities4 db = new CloudTripEntities4();

        // User_Account
        [Required]
        public string id { get; set; }
        [DisplayName("帳號")]
        [Required(ErrorMessage = " *請輸入帳號")]
        [EmailAddress(ErrorMessage = " *請填入正確格式，例：d0177954@gmail.com")]
        public string email { get; set; }
        [DisplayName("密碼")]
        [Required(ErrorMessage = " *請輸入密碼")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密碼長度為6到12個字")]
        public string passwd { get; set; }
        [DisplayName("確認密碼")]
        [Required(ErrorMessage = " *請輸入確認密碼")]
        public string ConfirmPasswd { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            

            var list = db.User.ToList();
            User FindUser = list.Find(x => x.Account.Equals(email));



            //判斷帳號是否有人使用 
            if (FindUser != null)
                yield return new ValidationResult(" *此帳號已有人使用", new[] { "Email" });
      
            if (passwd != ConfirmPasswd)
                yield return new ValidationResult(" *密碼和確認密碼不相符", new[] { "ConfirmPasswd" });


        }

     

 

   
      



       
        

    }

}
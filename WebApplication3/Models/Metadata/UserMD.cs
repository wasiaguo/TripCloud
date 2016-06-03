using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    [MetadataType(typeof(UserMD))]

    public partial class User
    {

        public class UserMD
        {
            [Display(Name="會員編號")]
            public int UserId { get; set; }

            [Display(Name = "會員名稱")]
            public string Name { get; set; }

            [Display(Name = "帳號")]
            public string Account { get; set; }

            [Display(Name = "密碼")]
            public string Password { get; set; }

            [Display(Name = "好友")]
            public string Friend { get; set; }

            [Display(Name = "年齡")]
            public Nullable<int> Age { get; set; }

            [Display(Name = "教育程度")]
            public Nullable<double> Eduction { get; set; }

            [Display(Name = "消費習慣")]
            public Nullable<double> Consumption { get; set; }

            [Display(Name = "購物類喜好")]
            public Nullable<double> ShoppingScore { get; set; }
            [Display(Name = "風景類喜好")]
            public Nullable<double> LandscapeScore { get; set; }
            [Display(Name = "宗教類喜好")]
            public Nullable<double> ReligionScore { get; set; }
            [Display(Name = "人文類喜好")]
            public Nullable<double> HumanitiesScore { get; set; }
            [Display(Name = "古蹟類喜好")]
            public Nullable<double> HistoricalSiteScore { get; set; }

        }

       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    [MetadataType(typeof(FriendMD))]

    public partial class Friend
    {

        public class FriendMD
        {
            [Display(Name ="好友ID")]
            public Nullable<int> FriendId { get; set; }

            [Display(Name = "我的ID")]
            public Nullable<int> UserId { get; set; }

            [Display(Name = "是否接受")]
            public Nullable<bool> checkfreind { get; set; }

            public int Friendship { get; set; }

            [Display(Name = "好友資料")]
            public virtual User User { get; set; }

            [Display(Name = "我的資料")]
            public virtual User User1 { get; set; }

        }


    }
}
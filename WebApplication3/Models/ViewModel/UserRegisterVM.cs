using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class UserRegisterVM
    {
        public User user { get; set; }

        public List<ScorePOIModel> ShoppingPOIs { get; set; }
        public List<ScorePOIModel> LandscapePOIs { get; set; }
        public List<ScorePOIModel> ReligionPOIs { get; set; }
        public List<ScorePOIModel> HumanitiesPOIs { get; set; }
        public List<ScorePOIModel> HistoricalSitePOIs { get; set; }

    }
}
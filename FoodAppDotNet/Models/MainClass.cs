using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAppDotNet.Models
{
    public class MainClass
    {
    }

    public class FOOD_COUNTRY_LOCAL
    {
        public int IDX { get; set; }
        public string COUNTRY_KOR_NAME { get; set; }
        public DateTime REGDATE { get; set; }
        public string REGID { get; set; }
        public DateTime UPDDATE { get; set; }
        public string UPDID { get; set; }
        public bool ISUSE { get; set; }
    }

    public class FOOD_STORE_LOCAL
    {
        public int IDX { get; set; }
        public int COUNTRY_IDX { get; set; }
        public string STORE_KOR_NAME { get; set; }
        public string STORE_DELIVERY_TIP { get; set; }
        public string STORE_DELIVERY_MIN_TIME { get; set; }
        public string STORE_DELIVERY_MAX_TIME { get; set; }
        public int STORE_RATING { get; set; }
        public DateTime REGDATE { get; set; }
        public string REGID { get; set; }
        public DateTime UPDDATE { get; set; }
        public string UPDID { get; set; }
        public bool ISUSE { get; set; }

        public List<FOOD_DETAIL_LOCAL> FoodDetailList { get; set; }
    }

    public class FOOD_DETAIL_LOCAL
    {
        public int IDX { get; set; }
        public int STORE_IDX { get; set; }
        public string FOOD_KOR_NAME { get; set; }
        public int FOOD_PRICE { get; set; }
        public DateTime REGDATE { get; set; }
        public string REGID { get; set; }
        public DateTime UPDDATE { get; set; }
        public string UPDID { get; set; }
        public bool ISUSE { get; set; }
    }
}
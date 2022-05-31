using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAppDotNet.Models
{
    public class DataFromDB
    {
        public List<FOOD_COUNTRY_LOCAL> GetCountryAll()
        {
            List<FOOD_COUNTRY_LOCAL> list = new List<FOOD_COUNTRY_LOCAL>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETCOUNTRYAll");
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                list.Add(new FOOD_COUNTRY_LOCAL
                {
                    IDX = (int)data["IDX"],
                    COUNTRY_KOR_NAME = data["COUNTRY_KOR_NAME"].ToString(),
                    REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    REGID = data["REGID"].ToString(),
                    UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    UPDID = data["UPDID"].ToString(),
                    ISUSE = data["ISUSE"] == "Y" ? true : false
                });
            }
            return list;
        }

        public List<FOOD_STORE_LOCAL> GetStoreList(int countryId)
        {
            List<FOOD_STORE_LOCAL> list = new List<FOOD_STORE_LOCAL>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETSTORE {0}, {1}", countryId, 0);
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                list.Add(new FOOD_STORE_LOCAL
                {
                    IDX = (int)data["IDX"],
                    STORE_KOR_NAME = data["STORE_KOR_NAME"].ToString(),
                    STORE_DELIVERY_TIP = data["STORE_DELIVERY_TIP"].ToString(),
                    STORE_DELIVERY_MIN_TIME = data["STORE_DELIVERY_MIN_TIME"].ToString(),
                    STORE_DELIVERY_MAX_TIME = data["STORE_DELIVERY_MAX_TIME"].ToString(),
                    STORE_RATING = (int)data["STORE_RATING"],
                    REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    REGID = data["REGID"].ToString(),
                    UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    UPDID = data["UPDID"].ToString(),
                    ISUSE = data["ISUSE"] == "Y" ? true : false
                });
            }
            return list;
        }

        public FOOD_STORE_LOCAL GetStore(int countryId, int storeId)
        {
            FOOD_STORE_LOCAL store = new FOOD_STORE_LOCAL();

            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETSTORE {0}, {1}", countryId, storeId);
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                store.IDX = (int)data["IDX"];
                store.STORE_KOR_NAME = data["STORE_KOR_NAME"].ToString();
                store.STORE_DELIVERY_TIP = data["STORE_DELIVERY_TIP"].ToString();
                store.STORE_DELIVERY_MIN_TIME = data["STORE_DELIVERY_MIN_TIME"].ToString();
                store.STORE_DELIVERY_MAX_TIME = data["STORE_DELIVERY_MAX_TIME"].ToString();
                store.STORE_RATING = (int)data["STORE_RATING"];
                store.REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now;
                store.REGID = data["REGID"].ToString();
                store.UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now;
                store.UPDID = data["UPDID"].ToString();
                store.ISUSE = data["ISUSE"] == "Y" ? true : false;
                store.FoodDetailList = GetFoodDetail(storeId);
            }
            return store;
        }

        public List<FOOD_DETAIL_LOCAL> GetFoodDetail(int storeId)
        {
            List<FOOD_DETAIL_LOCAL> list = new List<FOOD_DETAIL_LOCAL>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETFOODDETAIL {0}", storeId);
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                list.Add(new FOOD_DETAIL_LOCAL
                {
                    IDX = (int)data["IDX"],
                    STORE_IDX = (int)data["STORE_IDX"],
                    FOOD_KOR_NAME = data["FOOD_KOR_NAME"].ToString(),
                    FOOD_PRICE = (int)data["FOOD_PRICE"],
                    REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    REGID = data["REGID"].ToString(),
                    UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    UPDID = data["UPDID"].ToString(),
                    ISUSE = data["ISUSE"] == "Y" ? true : false
                });
            }

            return list;
        }

        public FOOD_STORE_LOCAL GetStoreJoin(int storeId)
        {
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETSTOREANDDETAIL {0}", storeId);
            var data = dbconn.ConnectDB(queryString);

            FOOD_STORE_LOCAL store = new FOOD_STORE_LOCAL();
            List<FOOD_DETAIL_LOCAL> list = new List<FOOD_DETAIL_LOCAL>();

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                store.IDX = (int)data["IDX"];
                store.STORE_KOR_NAME = data["STORE_KOR_NAME"].ToString();
                store.STORE_DELIVERY_TIP = data["STORE_DELIVERY_TIP"].ToString();
                store.STORE_DELIVERY_MIN_TIME = data["STORE_DELIVERY_MIN_TIME"].ToString();
                store.STORE_DELIVERY_MAX_TIME = data["STORE_DELIVERY_MAX_TIME"].ToString();
                store.STORE_RATING = (int)data["STORE_RATING"];
                store.REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now;
                store.REGID = data["REGID"].ToString();
                store.UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now;
                store.UPDID = data["UPDID"].ToString();
                store.ISUSE = data["ISUSE"] == "Y" ? true : false;
                store.FoodDetailList = GetFoodDetail(storeId);

                list.Add(new FOOD_DETAIL_LOCAL
                {
                    IDX = (int)data["IDX"],
                    STORE_IDX = (int)data["STORE_IDX"],
                    FOOD_KOR_NAME = data["FOOD_KOR_NAME"].ToString(),
                    FOOD_PRICE = (int)data["FOOD_PRICE"],
                    REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    REGID = data["REGID"].ToString(),
                    UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    UPDID = data["UPDID"].ToString(),
                    ISUSE = data["ISUSE"] == "Y" ? true : false
                });
            }
            return store;
        }
    }
}
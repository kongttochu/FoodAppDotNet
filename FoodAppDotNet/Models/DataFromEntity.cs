using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAppDotNet.Models
{
    public class DataFromEntity
    {
        public List<FOOD_COUNTRY_LOCAL> GetCountryAll()
        {
            FOODSTOREAPPTESTEntities fs = new FOODSTOREAPPTESTEntities();
            DateTime dt = DateTime.Now;
            var coutries = fs.USP_GETCOUNTRYAll()
                .Select(
                 c => new FOOD_COUNTRY_LOCAL
                 {
                     IDX = c.IDX,
                     COUNTRY_KOR_NAME = c.COUNTRY_KOR_NAME,
                     REGDATE = c.REGDATE ?? dt,
                     REGID = c.REGID,
                     UPDDATE = c.UPDDATE ?? dt,
                     UPDID = c.UPDID,
                     ISUSE = c.ISUSE == "Y" ? true : false
                 }
                ).ToList();
            return coutries;
        }

        public List<FOOD_STORE_LOCAL> GetStoreList(int countryId)
        {
            FOODSTOREAPPTESTEntities fs = new FOODSTOREAPPTESTEntities();
            DateTime dt = DateTime.Now;
            var stores = fs.USP_GETSTORE(countryId, 0)
                .Select(s => new FOOD_STORE_LOCAL
                {
                    IDX = s.IDX,
                    STORE_KOR_NAME = s.STORE_KOR_NAME,
                    STORE_DELIVERY_TIP = s.STORE_DELIVERY_TIP,
                    STORE_DELIVERY_MIN_TIME = s.STORE_DELIVERY_MAX_TIME,
                    STORE_DELIVERY_MAX_TIME = s.STORE_DELIVERY_MIN_TIME,
                    STORE_RATING = s.STORE_RATING ?? -1,
                    REGDATE = s.REGDATE ?? dt,
                    REGID = s.REGID,
                    UPDDATE = s.UPDDATE ?? dt,
                    UPDID = s.UPDID,
                    ISUSE = s.ISUSE == "Y" ? true : false
                }).ToList();
            return stores;
        }

        public FOOD_STORE_LOCAL GetStore(int countryId, int storeId)
        {
            FOODSTOREAPPTESTEntities fs = new FOODSTOREAPPTESTEntities();
            DateTime dt = DateTime.Now;
            var store = fs.USP_GETSTORE(countryId, 0)
                .Where(s => s.IDX == storeId)
                .Select(s => new FOOD_STORE_LOCAL
                {
                    IDX = s.IDX,
                    STORE_KOR_NAME = s.STORE_KOR_NAME,
                    STORE_DELIVERY_TIP = s.STORE_DELIVERY_TIP,
                    STORE_DELIVERY_MIN_TIME = s.STORE_DELIVERY_MAX_TIME,
                    STORE_DELIVERY_MAX_TIME = s.STORE_DELIVERY_MIN_TIME,
                    STORE_RATING = s.STORE_RATING ?? -1,
                    REGDATE = s.REGDATE ?? dt,
                    REGID = s.REGID,
                    UPDDATE = s.UPDDATE ?? dt,
                    UPDID = s.UPDID,
                    ISUSE = s.ISUSE == "Y" ? true : false,
                    FoodDetailList = GetFoodDetail(storeId)
                }).ToList();
            return store[0];
        }

        public List<FOOD_DETAIL_LOCAL> GetFoodDetail(int storeId)
        {
            FOODSTOREAPPTESTEntities fs = new FOODSTOREAPPTESTEntities();
            DateTime dt = DateTime.Now;
            var details = fs.USP_GETFOODDETAIL(storeId)
                .Select(d => new FOOD_DETAIL_LOCAL
                {
                    IDX = d.IDX,
                    STORE_IDX = d.STORE_IDX,
                    FOOD_KOR_NAME = d.FOOD_KOR_NAME,
                    FOOD_PRICE = d.FOOD_PRICE ?? -1,
                    REGDATE = d.REGDATE ?? dt,
                    REGID = d.REGID,
                    UPDDATE = d.UPDDATE ?? dt,
                    UPDID = d.UPDID,
                    ISUSE = d.ISUSE == "Y" ? true : false
                }).ToList();
            return details;
        }

        //join 에러 열 이름 겹쳐서 발생하는 것으로 보임
        public FOOD_STORE_LOCAL GetStoreJoin(int storeId)
        {
            FOODSTOREAPPTESTEntities fs = new FOODSTOREAPPTESTEntities();
            DateTime dt = DateTime.Now;
            var store = fs.USP_GETSTOREANDDETAIL(storeId)
                .Select(s => new FOOD_STORE_LOCAL
                {
                    IDX = s.IDX,
                    STORE_KOR_NAME = s.STORE_KOR_NAME,
                    STORE_DELIVERY_TIP = s.STORE_DELIVERY_TIP,
                    STORE_DELIVERY_MIN_TIME = s.STORE_DELIVERY_MAX_TIME,
                    STORE_DELIVERY_MAX_TIME = s.STORE_DELIVERY_MIN_TIME,
                    STORE_RATING = s.STORE_RATING ?? -1,
                    REGDATE = s.REGDATE ?? dt,
                    REGID = s.REGID,
                    UPDDATE = s.UPDDATE ?? dt,
                    UPDID = s.UPDID,
                    ISUSE = s.ISUSE == "Y" ? true : false,
                    FoodDetailList = GetFoodDetail(storeId)
                }
                ).ToList();
            return store[0];
        }
    }
}
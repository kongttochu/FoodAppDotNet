﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 템플릿에서 생성되었습니다.
//
//     이 파일을 수동으로 변경하면 응용 프로그램에서 예기치 않은 동작이 발생할 수 있습니다.
//     이 파일을 수동으로 변경하면 코드가 다시 생성될 때 변경 내용을 덮어씁니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodAppDotNet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FOODSTOREAPPTESTEntities : DbContext
    {
        public FOODSTOREAPPTESTEntities()
            : base("name=FOODSTOREAPPTESTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COUNTRY> COUNTRY { get; set; }
        public virtual DbSet<FOOD_DETAIL> FOOD_DETAIL { get; set; }
        public virtual DbSet<STORE> STORE { get; set; }
    
        public virtual ObjectResult<USP_GETCOUNTRYAll_Result> USP_GETCOUNTRYAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GETCOUNTRYAll_Result>("USP_GETCOUNTRYAll");
        }
    
        public virtual ObjectResult<USP_GETFOODDETAIL_Result> USP_GETFOODDETAIL(Nullable<int> sTORE_IDX)
        {
            var sTORE_IDXParameter = sTORE_IDX.HasValue ?
                new ObjectParameter("STORE_IDX", sTORE_IDX) :
                new ObjectParameter("STORE_IDX", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GETFOODDETAIL_Result>("USP_GETFOODDETAIL", sTORE_IDXParameter);
        }
    
        public virtual ObjectResult<USP_GETFOODDETAIL_WHERE_Result> USP_GETFOODDETAIL_WHERE(string sTORE_NAME)
        {
            var sTORE_NAMEParameter = sTORE_NAME != null ?
                new ObjectParameter("STORE_NAME", sTORE_NAME) :
                new ObjectParameter("STORE_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GETFOODDETAIL_WHERE_Result>("USP_GETFOODDETAIL_WHERE", sTORE_NAMEParameter);
        }
    
        public virtual ObjectResult<USP_GETSTORE_Result> USP_GETSTORE(Nullable<int> cOUNTRY_IDX, Nullable<int> sTORE_IDX)
        {
            var cOUNTRY_IDXParameter = cOUNTRY_IDX.HasValue ?
                new ObjectParameter("COUNTRY_IDX", cOUNTRY_IDX) :
                new ObjectParameter("COUNTRY_IDX", typeof(int));
    
            var sTORE_IDXParameter = sTORE_IDX.HasValue ?
                new ObjectParameter("STORE_IDX", sTORE_IDX) :
                new ObjectParameter("STORE_IDX", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GETSTORE_Result>("USP_GETSTORE", cOUNTRY_IDXParameter, sTORE_IDXParameter);
        }
    
        public virtual ObjectResult<USP_GETSTOREANDDETAIL_Result> USP_GETSTOREANDDETAIL(Nullable<int> sTORE_IDX)
        {
            var sTORE_IDXParameter = sTORE_IDX.HasValue ?
                new ObjectParameter("STORE_IDX", sTORE_IDX) :
                new ObjectParameter("STORE_IDX", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GETSTOREANDDETAIL_Result>("USP_GETSTOREANDDETAIL", sTORE_IDXParameter);
        }
    }
}
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class COUNTRY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COUNTRY()
        {
            this.STORE = new HashSet<STORE>();
        }
    
        public int IDX { get; set; }
        public string COUNTRY_KOR_NAME { get; set; }
        public Nullable<System.DateTime> REGDATE { get; set; }
        public string REGID { get; set; }
        public Nullable<System.DateTime> UPDDATE { get; set; }
        public string UPDID { get; set; }
        public string ISUSE { get; set; }
        public string ETC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STORE> STORE { get; set; }
    }
}

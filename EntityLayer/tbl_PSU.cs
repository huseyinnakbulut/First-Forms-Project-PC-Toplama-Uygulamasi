//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_PSU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_PSU()
        {
            this.tbl_Order = new HashSet<tbl_Order>();
        }
    
        public int Id { get; set; }
        public string Marka { get; set; }
        public Nullable<int> Güc { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public string Full_Ad { get; set; }
        public string Verimlilik_sertifikası { get; set; }
        public Nullable<int> Stok { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Order> tbl_Order { get; set; }
    }
}

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
    
    public partial class tbl_CPU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CPU()
        {
            this.tbl_Order = new HashSet<tbl_Order>();
        }
    
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Seri { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<int> Stok { get; set; }
        public Nullable<int> Güç { get; set; }
        public Nullable<int> Soket_Id { get; set; }
        public string Full_Ad { get; set; }
        public string Hız { get; set; }
        public Nullable<byte> Ön_Bellek { get; set; }
    
        public virtual tbl_Socket tbl_Socket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Order> tbl_Order { get; set; }
    }
}

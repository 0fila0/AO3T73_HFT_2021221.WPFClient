//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Products.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aruhaz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aruhaz()
        {
            this.ID_Kapcsolo = new HashSet<ID_Kapcsolo>();
        }
    
        public string Aruhaz_neve { get; set; }
        public string Honlap { get; set; }
        public string E_mail { get; set; }
        public Nullable<decimal> Telefon { get; set; }
        public string Kozpont { get; set; }
        public decimal Adoszam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ID_Kapcsolo> ID_Kapcsolo { get; set; }
    }
}

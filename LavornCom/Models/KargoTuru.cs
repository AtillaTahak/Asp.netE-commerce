//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LavornCom.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KargoTuru
    {
        public int KargoTuruId { get; set; }
        public System.DateTime KayıtTarihi { get; set; }
        public string EkleyenKullaniciAdi { get; set; }
        public string KargoAdi { get; set; }
        public decimal KargoFiyat { get; set; }
    }
}
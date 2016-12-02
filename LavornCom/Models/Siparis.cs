using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LavornCom.Models
{
    public class Siparis
    {
        public string id { get; set; }
        public string MusteriID { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public List<Urunler> UrunListesi { get; set; }
    }
}
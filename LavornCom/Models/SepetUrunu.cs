using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LavornCom.Models
{
    
    public class SepetUrunu
    {
        public int UrunId { get; set; }
        public string UrunAdı { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }


    }
}
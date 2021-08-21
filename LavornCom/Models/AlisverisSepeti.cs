using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LavornCom.Models
{
  
    public class AlisverisSepeti
    {
        List<SepetUrunu> urunler;
        public AlisverisSepeti(HttpContextBase context) 
        {
            //HttpContextBase context = new HttpContextBase();
            if (context.Session["Sepet"]==null)
            {
                urunler = new List<SepetUrunu>();
                context.Session["Sepet"] = urunler;
            }
            else
             urunler = (List<SepetUrunu>)context.Session["Sepet"];
    }
        public int Adet
        {
            get
            {
               return urunler.Sum(u => u.Adet);
                    
                    
                    
                    }



        }

        public void SepeteEkle(SepetUrunu sepeturun )
        {

            if (urunler.Any(u => u.UrunId == sepeturun.UrunId &&u.Renk==sepeturun.Renk&&u.Size==sepeturun.Size))
            {
                var eski = urunler.First(u => u.UrunId == sepeturun.UrunId);
                eski.Adet += sepeturun.Adet;
            }
            else
            {
                urunler.Add(sepeturun);
            }
        }
        public void SepettenKaldir(int Id,string renk,string size)
        {
        SepetUrunu sepet_urunu= urunler.FirstOrDefault(x => x.UrunId == Id);
            if (sepet_urunu!=null)
            {
                if (sepet_urunu.Adet>1&&sepet_urunu.Renk!=renk&&sepet_urunu.Size!=size)
                {
                    sepet_urunu.Adet--;

                        
                }
                else
                {
                    urunler.Remove(sepet_urunu);
                }
            }
        }
        public SepetUrunu[] SepettekiUrunler { get { return urunler.ToArray(); }  }
        public List<SepetUrunu> SepetiTemizle()
        {
            var bosalt = new List<SepetUrunu>();
            HttpContext.Current.Session["Sepet"] = bosalt;
            return bosalt;

        }
    }
}
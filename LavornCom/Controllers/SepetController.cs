using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LavornCom.Models;
namespace LavornCom.Controllers
{
    public class SepetController : Controller
    {
        DB_109003_lavornEntities db = new DB_109003_lavornEntities();
        AlisverisSepeti alisverisSepeti;

        public AlisverisSepeti AlisverisSepeti
        {
            get
            {
                if (alisverisSepeti==null)
                {
                    alisverisSepeti = new AlisverisSepeti(this.HttpContext); 
                }
                return alisverisSepeti;


            }
            set
            {
                alisverisSepeti = value;
            }
        }

        public SepetController()
        {

           
          
        }
        // GET: Sepet

        public ActionResult Index()
        {
         
            
            return View(AlisverisSepeti.SepettekiUrunler);
        }
      
        public ActionResult SepeteEkle(int id,int adet,string renk,string size)
        {
          Urunler gelen=  db.Urunler.FirstOrDefault(x => x.Id == id);
            if (gelen!=null)
            {
                
                SepetUrunu urn = new SepetUrunu();
                urn.UrunId = gelen.Id;
                urn.UrunAdı = gelen.UrunAd;
                urn.Adet = adet;
                urn.Fiyat = gelen.UrunFiyat;
                urn.Renk = renk;
                urn.Size = size;

                AlisverisSepeti.SepeteEkle(urn);
            }

           return RedirectToAction("Index");
            
        }
        public ActionResult SepettenKaldir(int id,string renk,string size)
        {
            Urunler gelen = db.Urunler.FirstOrDefault(x => x.Id == id);
            if (gelen!=null)
            {
               

                AlisverisSepeti.SepettenKaldir(gelen.Id,renk,size);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SepetiTemizle()
        {


            AlisverisSepeti.SepetiTemizle();
            return RedirectToAction("Index");
        }
    }
}
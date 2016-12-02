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
        lavornDbEntities db = new lavornDbEntities();
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
       
        public ActionResult SepeteEkle(int id)
        {
          Urunler gelen=  db.Urunler.FirstOrDefault(x => x.UrunId == id);
            if (gelen!=null)
            {
                
                SepetUrunu urn = new SepetUrunu();
                urn.UrunId = gelen.UrunId;
                urn.UrunAdı = gelen.UrunAd;
                urn.Adet = 1;
                urn.Fiyat = gelen.Fiyat;
                

                AlisverisSepeti.SepeteEkle(urn);
            }

           return RedirectToAction("Index");
            
        }
        public ActionResult SepettenKaldir(int id)
        {
            Urunler gelen = db.Urunler.FirstOrDefault(x => x.UrunId == id);
            if (gelen!=null)
            {
               

                AlisverisSepeti.SepettenKaldir(gelen.UrunId);
            }
            return RedirectToAction("Index");
        }
    }
}
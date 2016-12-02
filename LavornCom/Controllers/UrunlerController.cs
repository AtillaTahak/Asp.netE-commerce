using LavornCom.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EmreGiyim.Controllers
{
    public class UrunlerController : Controller
    {
        lavornDbEntities db = new lavornDbEntities();

        // GET: UrunDetay
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Detay(int id)
        {
            var uruns = db.Urunler.FirstOrDefault(x => x.UrunId == id);
            return View(uruns);

        }
        public ActionResult Kategoriler(int id)
        {
            var Kategori = db.Urunler.Where(x => x.KategoriId == id);
            return View(Kategori);

        }
        public ActionResult UrunGetir()
        {
            var runs = db.Urunler.Where(x => x.IsActive == true).ToList();
            return View(runs);
            
        }
        public ActionResult Markalar(int id)
        {
            var markalar = db.Urunler.Where(x => x.MarkaId == id);
            return View(markalar);
        }

        public ActionResult Yorumlar(string yorum, string mailadres, string yorumcuad, int urunıd)
        {
            Yorumlar yrm = new Yorumlar();
            yrm.Yorum = yorum;
            yrm.MailAdres = mailadres;
            yrm.YorumcuAd = yorumcuad;
            yrm.UrunId = urunıd;
            //yrm.Urunler.Where(x => x.UrunId ==ıs) == urunıd;
            db.Yorumlar.Add(yrm);
            db.SaveChanges();
            return View();

        }
        public ActionResult YorumlarListe(int id)
        { var sonuc = db.Yorumlar.Where(x => x.Yorum == null);
            if (sonuc==null )
            {
                string hata = "Henüz hiç yorum yapılmamış";
                ViewBag.hata = hata;
                return View(hata);
            }
            else { 
            var yorumlarliste = db.Yorumlar.Where(x => x.UrunId ==id ).ToList();
            return View(yorumlarliste);
            }
        }
        //[Authorize]
        //[HttpPost]
        //public ActionResult Detay(int id, string UrunAdi, decimal Fiyat, int Adet,string mail)
        //{
        //    Sepet ms = new Sepet();
        //    ms.UrunId = id;
        //    ms.UrunAd = UrunAdi;
        //    ms.UrunFiyat = Fiyat;
        //    ms.Adet = Adet;
        //    ms.MusteriMail = mail;
        //    db.Sepet.Add(ms);

        //    db.SaveChanges();
        //    return Redirect("/");
        //}
        //public ActionResult yeni()
        //{
        //    return View();
        //}
        //public ActionResult AddToCart(int ProductId, int adet,decimal Fiyat)
        //{
        //    Sepet ma = new Sepet();
        //    {
        //        ma.MusteriMail = User.Identity.Name;
        //        ma.UrunId = ProductId;
        //        ma.Adet = adet;
        //        ma.UrunFiyat=Fiyat;
        //    };
        //    db.SaveChanges();
        //    return Content("ok"); 
        //}



    }
}
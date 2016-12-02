using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LavornCom.Models;
namespace LavornCom.Controllers
{
    public class HomeController : Controller
    {
       lavornDbEntities db =new lavornDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Slider()
        //{
        //    var sliders = db.Mansets.Where(x => x.id > 0);
        //    return View(sliders);
        //}
        public ActionResult Kategoriler()
        {
            var kategori = db.Kategoriler.Where(x => x.KategoriAd != null).ToList();
            return View(kategori);
          
        }
        public ActionResult Slider() { return View(); }
        public ActionResult Markalar()
        {
            var markalar = db.Markalar.Where(x => x.MarkaAd != null).ToList();
            return View(markalar);
        }
        //public ActionResult UrunGetir()
        //{
        //    var runs = db.Urunler.Where(x => x.IsActive == true).ToList();
        //    return View(runs);
        //}
        //

        //
    public ActionResult Arama(string deger)
        {
           var gelen =db.Urunler.Where(x => x.UrunAd == deger);
            return View(gelen);
        }
    }
}
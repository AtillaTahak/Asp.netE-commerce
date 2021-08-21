using LavornCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LavornCom.Controllers
{
    public class UyeController : Controller
    {
        DB_109003_lavornEntities db = new DB_109003_lavornEntities();

        // GET: Uye
        public ActionResult Cikis()
        {
            Session.Add("rol", "");
            return RedirectToAction("index", "Home");
        }
        [HttpPost]
        public ActionResult Guncel(Uyeler uy)
        {
            try
            {
                db.Entry(uy).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("index", "Home");
            }
            catch
            {
                return RedirectToAction("index", "Home");
            }

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bilgi()
        {
            try
            {
                string a = Session["rol"].ToString();

                var deger = db.Uyeler.Where(x => x.Id == Convert.ToInt32(a)).FirstOrDefault();
                return View(deger);
            }
            catch
            {

                return View();
            }


        }
        public ActionResult Giris(string email, string pass)
        {
            var deger = db.Uyeler.Where(x => x.Mail == email && x.Sifre == pass).FirstOrDefault();
            if (deger != null)
            {
                Session.Add("rol", deger.Id.ToString());
                return RedirectToAction("index", "Home");

            }
            else
            {
                return RedirectToAction("index", "UyeOl");

            }


        }
        public ActionResult Kayit(string name, string email, string pass)
        {
            Uyeler uy = new Uyeler();
            uy.UyeAd = name;
            uy.Mail = email;
            uy.Sifre = pass;
            db.Uyeler.Add(uy);
            db.SaveChanges();
            return RedirectToAction("index", "Home");
        }

    }
}
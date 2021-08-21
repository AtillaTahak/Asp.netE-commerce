using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LavornCom.Models;

namespace LavornCom.Controllers
{
    public class AdminController : Controller
    {
        private DB_109003_lavornEntities db = new DB_109003_lavornEntities();

        // GET: Admin
        public ActionResult Index()
        {
            var urunler = db.Urunler.Include(u => u.Kategoriler).Include(u => u.Markalar);
            return View(urunler.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriAd");
            ViewBag.MarkaId = new SelectList(db.Markalar, "MarkaId", "MarkaAd");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunId,UrunKodu,UrunAd,Link,UrunAciklama,KategoriId,Fiyat,ResimYolu,Miktar,Size,IsActive,ResimId,SiteUrunId,İndirimOran,AlisFiyat,PaketAdi,RefPaketId,BirimPaket,KdvOran,Oy,ToplamRating,MarkaId")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Urunler.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriAd", urunler.KategoriId);
            ViewBag.MarkaId = new SelectList(db.Markalar, "MarkaId", "MarkaAd", urunler.MarkaId);
            return View(urunler);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriAd", urunler.KategoriId);
            ViewBag.MarkaId = new SelectList(db.Markalar, "MarkaId", "MarkaAd", urunler.MarkaId);
            return View(urunler);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunId,UrunKodu,UrunAd,Link,UrunAciklama,KategoriId,Fiyat,ResimYolu,Miktar,Size,IsActive,ResimId,SiteUrunId,İndirimOran,AlisFiyat,PaketAdi,RefPaketId,BirimPaket,KdvOran,Oy,ToplamRating,MarkaId")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriAd", urunler.KategoriId);
            ViewBag.MarkaId = new SelectList(db.Markalar, "MarkaId", "MarkaAd", urunler.MarkaId);
            return View(urunler);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

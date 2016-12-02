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
    public class MesajKutususController : Controller
    {
        private lavornDbEntities db = new lavornDbEntities();

        // GET: MesajKutusus
        public ActionResult Index()
        {
            return View(db.MesajKutusu.ToList());
        }

        // GET: MesajKutusus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MesajKutusu mesajKutusu = db.MesajKutusu.Find(id);
            if (mesajKutusu == null)
            {
                return HttpNotFound();
            }
            return View(mesajKutusu);
        }

        // GET: MesajKutusus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MesajKutusus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MesajId,Isim,MailAdres,Telefon,Mesaj")] MesajKutusu mesajKutusu)
        {
            if (ModelState.IsValid)
            {
                db.MesajKutusu.Add(mesajKutusu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesajKutusu);
        }

        // GET: MesajKutusus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MesajKutusu mesajKutusu = db.MesajKutusu.Find(id);
            if (mesajKutusu == null)
            {
                return HttpNotFound();
            }
            return View(mesajKutusu);
        }

        // POST: MesajKutusus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MesajId,Isim,MailAdres,Telefon,Mesaj")] MesajKutusu mesajKutusu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesajKutusu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesajKutusu);
        }

        // GET: MesajKutusus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MesajKutusu mesajKutusu = db.MesajKutusu.Find(id);
            if (mesajKutusu == null)
            {
                return HttpNotFound();
            }
            return View(mesajKutusu);
        }

        // POST: MesajKutusus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MesajKutusu mesajKutusu = db.MesajKutusu.Find(id);
            db.MesajKutusu.Remove(mesajKutusu);
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

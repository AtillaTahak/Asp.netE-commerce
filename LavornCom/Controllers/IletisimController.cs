using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LavornCom.Models;
namespace LavornCom.Controllers
{
    public class IletisimController : Controller
    {
        lavornDbEntities db = new lavornDbEntities();
        
        // GET: Iletisim
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult Iletisim(string isim,string mail,string telefon,string mesaj)
        {
            MesajKutusu mk = new MesajKutusu();
            mk.Isim = isim;
            mk.MailAdres = mail;
            mk.Telefon = telefon;
            mk.Mesaj = mesaj;
            db.MesajKutusu.Add(mk);
            db.SaveChanges();
            return View("Index");
            
        }
    }
}
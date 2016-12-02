using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LavornCom.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        public ActionResult Index()
        {
            return View();
        }

        // GET: Yonetim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Yonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Yonetim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Yonetim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Yonetim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Yonetim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

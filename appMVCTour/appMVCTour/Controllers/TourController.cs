using appMVCTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appMVCTour.Controllers
{
    public class TourController : Controller
    {
        private TourContext db = new TourContext();
        // GET: Tour
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje= TempData["mensaje"].ToString();
            }

            //db.tour.OrderByDescending(x => x.nombre).ToList()

            return View(db.tour.OrderBy(x=>x.nombre).ToList());
        }

        // GET: Tour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //Respuesta personalizada
                TempData["mensaje"] = "Especifique un tour";
                return RedirectToAction("Index");
            }
            tour tour = db.tour.Find(id);
            if (tour == null)
            {
                TempData["mensaje"] = "No existe el tour";
                return RedirectToAction("Index");
            }
            return View("Detalle",tour);
        }

        // GET: Tour/Create
        public ActionResult Crear()
        {

            return View();
        }

        // POST: Tour/Create
        [HttpPost]
        public ActionResult Crear(FormCollection collection)
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

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tour/Edit/5
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

        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tour/Delete/5
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

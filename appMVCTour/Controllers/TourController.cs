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

        //Lista parcial
        public ActionResult buscarTour(string busqueda)
        {
            
           
            if (busqueda!=null)
            {
                var lista = db.tour.Where(x => x.nombre.Contains(busqueda)
            || x.descripcion.Contains(busqueda)
            || x.restricciones.Contains(busqueda)
            || x.precioAdultos.ToString().Contains(busqueda)
            || x.precioNinos.ToString().Contains(busqueda)).ToList();
                return PartialView("_list", lista);
            }
           
            return View();
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
        public ActionResult Crear(Models.tour objTour)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            try
            {
                // TODO: Add insert logic here
                db.tour.Add(objTour);
                db.SaveChanges();
                TempData["mensaje"] = "Tour guardado satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "Tour NO registrado";
                return View();
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int? id)
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
            return View(tour);
        }

        // POST: Tour/Edit/5
        [HttpPost]
        public ActionResult Edit( Models.tour objTour)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            try
            {
                // TODO: Add update logic here
                db.Entry(objTour).State = 
                    System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Tour actualizado satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "El tour no se logro actualizar";
                return View();
            }
        }


    }
}

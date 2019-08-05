using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using appMVCTour.Models;

namespace appMVCTour.Controllers
{
    public class ReservaTourController : Controller
    {
        private TourContext db = new TourContext();

        // GET: ReservaTour
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var reserva_tour = db.reserva_tour.Include(r => r.cliente).Include(r => r.tour);
            //Ordenado por la fecha de mayor a menor
            return View(reserva_tour.
                OrderByDescending(x=>x.fechaReserva).ToList());
        }


        public PartialViewResult ordenarReserva(string criterio)
        {
            var query = from r in db.reserva_tour
                        select r;

            switch (criterio)
            {
                case "asc":
                    query = query.OrderBy(x => x.fechaReserva);
                    break;
                case "desc":
                    query = query.OrderByDescending(x => x.fechaReserva);
                    break;
                default:
                    query = query.OrderBy(x => x.fechaReserva);
                    break;
            }

            return PartialView("_ordenarReserva",query);
        }


        // GET: ReservaTour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique una reserva";
                return RedirectToAction("Index");
            }
            reserva_tour reserva_tour = db.reserva_tour.Find(id);
            if (reserva_tour == null)
            {
                TempData["mensaje"] = "No existe el reserva";
                return RedirectToAction("Index");
            }
            return View(reserva_tour);
        }

        // GET: ReservaTour/Create
        public ActionResult Create()
        {
            ViewBag.listadoCliente = new SelectList(db.cliente, "idCliente", "NombreCompleto");
            ViewBag.listadoTours = new SelectList(db.tour, "idTour", "nombre");
            return View();
        }

        // POST: ReservaTour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idReserva,idTour,idCliente,cantidadNinos,cantidadAdultos,costoTotal,fechaReserva")] reserva_tour reserva_tour)
        {
            if (ModelState.IsValid)
            {
                db.reserva_tour.Add(reserva_tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "identificacion", reserva_tour.idCliente);
            ViewBag.idTour = new SelectList(db.tour, "idTour", "nombre", reserva_tour.idTour);
            return View(reserva_tour);
        }

        // GET: ReservaTour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva_tour reserva_tour = db.reserva_tour.Find(id);
            if (reserva_tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "identificacion", reserva_tour.idCliente);
            ViewBag.idTour = new SelectList(db.tour, "idTour", "nombre", reserva_tour.idTour);
            return View(reserva_tour);
        }

        // POST: ReservaTour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idReserva,idTour,idCliente,cantidadNinos,cantidadAdultos,costoTotal,fechaReserva")] reserva_tour reserva_tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva_tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "identificacion", reserva_tour.idCliente);
            ViewBag.idTour = new SelectList(db.tour, "idTour", "nombre", reserva_tour.idTour);
            return View(reserva_tour);
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

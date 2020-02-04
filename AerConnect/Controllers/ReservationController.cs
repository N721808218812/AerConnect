using AerConnect.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace AerConnect.Controllers
{
    public class ReservationController : Controller
    {
        private AvioKompanijaEntities1 entities1;

        public ReservationController()
        {
            entities1 = new AvioKompanijaEntities1();
        }
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rezervacija()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rezervacija(Rezervacija rezervacija, int id)
        {
            if (ModelState.IsValid)
            {
                Rezervacija booking = new Rezervacija()
                {
                    BrojPasosa = rezervacija.BrojPasosa,
                    BrojCipa = rezervacija.BrojCipa,
                    SifraLeta = id, Vreme = DateTime.Now.ToString("h:mm:ss tt")

                };
                if (entities1.Putniks.Any(L => L.BrojPasosa.Equals(rezervacija.BrojPasosa)))
                {

                    entities1.Rezervacijas.Add(booking);
                    entities1.SaveChanges();
                    return View("UploadSuccesfull");
                }
                else
                {
                    return View("PostojecaSifra");
                }
            }
            else
            {
                return View("Rezervacija", rezervacija);
            }

        }
    }

}
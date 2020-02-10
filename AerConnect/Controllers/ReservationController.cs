using AerConnect.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity.Validation;
using AerConnect.Helpers;

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
        [Authorize]
        public ActionResult Rezervacija()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rezervacija(Rezervacija rezervacija, int id)
        {
            if (ModelState.IsValid)
            {
                //var id = entities1.Rezervacijas.FirstOrDefault(l => l.SifraLeta == l.Let.SifraLeta);
                Rezervacija booking = new Rezervacija()
                {
                    BrojPasosa = rezervacija.BrojPasosa,
                    BrojCipa = rezervacija.BrojCipa,
                    SifraLeta = id,
                    Vreme = DateTime.Now.ToString("h:mm:ss tt")
                };
                if (entities1.Putniks.Any(L => L.BrojPasosa.Equals(rezervacija.BrojPasosa)))
                {
                    entities1.Rezervacijas.Add(booking);
                    entities1.SaveChanges();
                    return View("UploadSuccesfullReservation");
                }
                else
                {
                    return View("PostojecaSifraReservacija");
                }
            }
            else
            {
                return View("SveRezervacije", rezervacija);
            }

        }

        public ActionResult SveRezervacije()
        {
            if (this.User.IsInRole("Radnik"))
            {
                return View("SveRezervacije", UzmiSveRezervacije());
            }
            else
            {
                return View("SveRezervacijeKorisnik",UzmiSveRezervacije());
            }
        }
        public IEnumerable<Rezervacija> UzmiSveRezervacije()
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            foreach (Rezervacija baza in entities1.Rezervacijas)
            {
                Rezervacija r = new Rezervacija();
                r.SifraLeta = baza.SifraLeta;
                r.SifraRezervacije = baza.SifraRezervacije;
                r.BrojCipa = baza.BrojCipa;
                r.Vreme = baza.Vreme;
                r.BrojPasosa = baza.BrojPasosa;
                rezervacije.Add(r);
            }
            return rezervacije;
        }
        
        [Authorize(Roles = "Radnik")]
        public ActionResult DeleteReservation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija booking = entities1.Rezervacijas.SingleOrDefault(m => m.SifraRezervacije == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("DeleteReservation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervacija booking = entities1.Rezervacijas.SingleOrDefault(m => m.SifraRezervacije == id);
            Ljubimac lj = entities1.Ljubimacs.Where(br => br.BrojCipa == booking.BrojCipa).FirstOrDefault();
            if (lj != null)
            {
                entities1.Ljubimacs.Remove(lj);
                entities1.SaveChanges();
            }
            entities1.Rezervacijas.Remove(booking);
            entities1.SaveChanges();
            return RedirectToAction("SveRezervacije");
        }

        public ActionResult RezervacijaLjubimac()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RezervacijaLjubimac(LjubimacRez ljubimac)
        {
            if (ModelState.IsValid)
            {
                Ljubimac rez = new Ljubimac()
                {
                    Tezina = ljubimac.Tezina,
                    BrojCipa = ljubimac.BrojCipa,
                    BrojPasosa = ljubimac.BrojPasosa,
                    Rasa = ljubimac.Rasa,
                    Ime = ljubimac.Ime,
                };
                if (entities1.Rezervacijas.Any(L => L.BrojPasosa.Equals(ljubimac.BrojPasosa)))
                {
                    if (entities1.Rezervacijas.Any(L => L.BrojCipa==(ljubimac.BrojCipa)))
                    {
                        return View("Again");
                    }
                    if (entities1.Ljubimacs.Any(L => L.BrojCipa == (ljubimac.BrojCipa)))
                    {
                        return View("Again");
                    }

                    Rezervacija promena = entities1.Rezervacijas.Where(p => p.SifraRezervacije == ljubimac.SifraRezervacije).FirstOrDefault();
                    if (promena == null)
                    {
                        return View("WrongReservationPet");
                    }
                    else
                    {
                        promena.BrojCipa = ljubimac.BrojCipa;
                        entities1.SaveChanges();
                        entities1.Ljubimacs.Add(rez);
                        entities1.SaveChanges();

                        return View("SuccessfullReservationPet");
                    }
                }
                else
                {
                    return View("PostojecaSifraReservacija");
                }
            }
            else
            {
                return View("RezervacijaLjubimac");
            }

        }
    }
}
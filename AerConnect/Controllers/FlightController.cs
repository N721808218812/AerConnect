using AerConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AerConnect.Controllers
{
    public class FlightController : Controller
    {
        AvioKompanijaEntities1 entites;
        // GET: Flight
        public FlightController()
        {
            entites =new  AvioKompanijaEntities1();
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Radnik")]
        
        public ActionResult KreirajLet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KreirajLet(Let let )
        {
          
            if (ModelState.IsValid)
            {
                Let novi = new Let()
                {
                    SifraLeta = let.SifraLeta,
                    DestinacijaDo=let.DestinacijaDo,
                    DestinacijaOd=let.DestinacijaOd,
                    DatumPolaska=let.DatumPolaska,
                    DatumPovratka=let.DatumPovratka
                    
                };
                if (entites.Lets.Any(l => l.SifraLeta.Equals(let.SifraLeta)))
                {
                    return View("PostojecaSifra");
                }
                else
                {

                    entites.Lets.Add(novi);
                    entites.SaveChanges();
                    return View("UploadSuccesfull");
                }
            }
            else
            {
                return View("KreirajLet",let);
            }
        }

        public ActionResult SviLetovi()
        {
            return View(UzmiSveLetove());
        }
        public IEnumerable <Let> UzmiSveLetove()
        {
            List<Let> lista = new List<Let>();
           foreach(Let baza in entites.Lets)
            {
                Let l = new Let();
                l.SifraLeta = baza.SifraLeta;
                l.DatumPolaska = baza.DatumPolaska;
                l.DatumPovratka = baza.DatumPovratka;
                l.DestinacijaDo = baza.DestinacijaDo;
                l.DestinacijaOd = baza.DestinacijaOd;
                lista.Add(l);
            }
            return lista;
        }
    }
}
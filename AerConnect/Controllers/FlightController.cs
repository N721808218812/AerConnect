using AerConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                
                entites.Lets.Add(novi);
                entites.SaveChanges();
                return View("UploadSuccesfull");

            }
            else
            {
                return View("KreirajLet",let);
            }
        }
    }
}
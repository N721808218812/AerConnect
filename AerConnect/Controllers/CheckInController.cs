using AerConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AerConnect.Controllers
{
    public class CheckInController : Controller
    {
        AvioKompanijaEntities1 entities;
        // GET: CheckIn
        public CheckInController()
        {
            entities = new AvioKompanijaEntities1();
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult CheckIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(CheckIn checkin)
        {
            if(ModelState.IsValid)
            {
                CheckIn novi = new CheckIn()
                {
                    BrojPasosa =checkin.BrojPasosa,
                    SifraRezervacije = checkin.SifraRezervacije                    
                };
                if((entities.Putniks.Any(l=>l.BrojPasosa.Equals(checkin.BrojPasosa))) && (entities.Rezervacijas.Any(l => l.SifraRezervacije.Equals(checkin.SifraRezervacije))))
                {
                    entities.CheckIns.Add(novi);
                    entities.SaveChanges();
                    return View("UploadSuccesfull");

                }
                else
                {
                    return View("NePostojiPutnik");
                }
                

            }
            else
            {
                return View("CheckIn",checkin);
            }                  

        }

    }//class
}//namespace
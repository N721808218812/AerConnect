using AerConnect.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }

        [Authorize]
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
                    SifraRezervacije = checkin.SifraRezervacije,
                    Vreme= DateTime.Now.ToString("h:mm:ss tt")
                };
                if((entities.Rezervacijas.Any(l=>l.BrojPasosa.Equals(checkin.BrojPasosa))) && (entities.Rezervacijas.Any(l => l.SifraRezervacije.Equals(checkin.SifraRezervacije))))
                {
                    if((entities.CheckIns.Any(l => l.SifraRezervacije.Equals(checkin.SifraRezervacije))) && (entities.Rezervacijas.Any(l => l.BrojPasosa.Equals(checkin.BrojPasosa))))
                    {
                        return View("VecObavljenCheckIn");
                    }
                    entities.CheckIns.Add(novi);
                    entities.SaveChanges();
                    return View("Uspesno");

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

        }//checkin

        [Authorize]
        public ActionResult EvidentirajZalbu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EvidentirajZalbu(Zalba zalba)
        {
            if (ModelState.IsValid)
            {
                Zalba nova = new Zalba()
                {
                    BrojPasosa = zalba.BrojPasosa,
                    Komentar = zalba.Komentar
                };
                if ((entities.CheckIns.Any(l => l.BrojPasosa.Equals(zalba.BrojPasosa))) )
                {
                    entities.Zalbas.Add(nova);
                    entities.SaveChanges();
                    return View("EvidentiranaZalba");

                }
                else
                {
                    return View("NePostojiPutnik");
                }


            }
            else
            {
                return View("EvidentirajZalbu", zalba);
            }
        }//evidentirajZalbu
        [Authorize]
        public ActionResult SviCheckIn()
        {
            return View(UzmiSveCheckIn());
        }//svicheckin

        [Authorize]
        public IEnumerable<CheckIn> UzmiSveCheckIn()
        {
            List<CheckIn> lista = new List<CheckIn>();
            foreach (CheckIn baza in entities.CheckIns)
            {
                CheckIn l = new CheckIn();
                l.BrojCheckIn = baza.BrojCheckIn;
                l.BrojPasosa = baza.BrojPasosa;
                l.SifraRezervacije = baza.SifraRezervacije;
                l.Vreme = baza.Vreme;
                lista.Add(l);
            }
            return lista;
        }//UzmiSveCheckIn

        [Authorize]
        public ActionResult IzmeniCheckIn(int id)
        {

            return View(entities.CheckIns.Where(x=>x.BrojCheckIn==id).FirstOrDefault());
        }//izmenicheckin

        [HttpPost]
        public ActionResult IzmeniCheckIn(CheckIn checkin) //ne radi
        {
            if (ModelState.IsValid)
            {
               
                var edit = entities.CheckIns.Where(le => le.BrojCheckIn == checkin.BrojCheckIn).FirstOrDefault();
                edit.Vreme = DateTime.Now.ToString("h:mm:ss tt");                

                entities.SaveChanges();
                return RedirectToAction("SviCheckIn");
            }
            else
            {
                return View("IzmeniCheckIn", checkin);
            }
        }//izmeniCheckIn


        [Authorize]
        public ActionResult Otkazi(int id)
        {
            return View(entities.CheckIns.Where(x => x.BrojCheckIn == id).FirstOrDefault());
        }//otkazi


        [HttpPost]
        public ActionResult Otkazi(int id,FormCollection collection) 
        {
            try
            {
                CheckIn checkin = entities.CheckIns.Where(x => x.BrojCheckIn == id).FirstOrDefault();
                entities.CheckIns.Remove(checkin);
                entities.SaveChanges();
                return RedirectToAction("SviCheckIn");
            }catch 
            {
                return RedirectToAction("SviCheckIn");
            }


        }//otkazi

    }//class
}//namespace
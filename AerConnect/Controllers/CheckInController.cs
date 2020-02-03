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
        public ActionResult Index()
        {
            entities = new AvioKompanijaEntities1();
            return View("Checkin");
        }

        public ActionResult CheckIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(int brojPasosa, int sifraRezervacije)
        {
            if(ModelState.IsValid)
            {
                CheckIn novi = new CheckIn()
                {
                    BrojPasosa = brojPasosa,
                    SifraRezervacije = sifraRezervacije,
                    Vreme = DateTime.Now.ToString()
                };
                entities.CheckIns.Add(novi);
                entities.SaveChanges();

            }
            else
            {
                return View();
            }

            return View();

        }

    }//class
}//namespace
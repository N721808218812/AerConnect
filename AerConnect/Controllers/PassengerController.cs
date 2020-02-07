using AerConnect.Models;
using AerConnect.Models.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AerConnect.Controllers
{
    public class PassengerController : Controller
    {
        private AvioKompanijaEntities1 entities1;
     

        public PassengerController()
        {
            entities1 = new AvioKompanijaEntities1();
        }
        // GET: Passenger
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Radnik")]
        public ActionResult Search()
        {
            return View(new SearchPassengerViewModel
            {
                search = new Helpers.SearchPassanger(),
                Putniks = new List<Putnik>()

            });
        }

        [HttpPost]
        public ActionResult SearchList (SearchPassengerViewModel viewModel)
        {
            var search = viewModel.search;

            string BrojPasosa = search.BrojPasosa;
            string Ime = search.Ime;
            string Prezime = search.Prezime;
            string BrojTelefona = search.BrojTelefona;
            string Email = search.Email;

            if (BrojPasosa == null && Ime == null &&
                Prezime == null && BrojTelefona == null && Email == null)
                return View("PostojecaPretraga");

            int Bp = Convert.ToInt32(BrojPasosa);
            int Bt = Convert.ToInt32(BrojTelefona);

            var searchedPassanger = entities1.Putniks.Where(j => (BrojPasosa!=null ?j.BrojPasosa == Bp: j.BrojPasosa == j.BrojPasosa) &&
                                                (Ime != null ? j.Ime.StartsWith(Ime) : j.Ime == j.Ime) &&
                                                (Prezime != null ? j.Prezime.StartsWith(Prezime) : j.Prezime == j.Prezime) &&
                                                (BrojTelefona != null ? j.BrojTelefona== Bt : j.BrojTelefona == j.BrojTelefona)).ToList();

            if (ModelState.IsValid)
            {
                SearchPassengerViewModel vM = new SearchPassengerViewModel
                {
                    Putniks = searchedPassanger
                };

                
                ModelState.Clear();

                return View("_SearchPutnik", vM);
            }
            else
            {
                return Content("Doslo je do greske");
            }
     
} 
    }
}
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
            
            //string BrojPasosa =Convert.ToString( search.BrojPasosa);
            int  BrojPasosa = search.BrojPasosa;
            if (BrojPasosa.ToString() == null || BrojPasosa.ToString()=="0")
            {
                BrojPasosa = 0;
            }
            string Ime = Convert.ToString(search.Ime);
            string Prezime = Convert.ToString(search.Prezime);
            //string BrojTelefona =Convert.ToString( search.BrojTelefona);
            int BrojTelefona = search.BrojTelefona;
            //return Content(Convert.ToString(BrojTelefona1));
            string Email = Convert.ToString(search.Email);

            if (BrojPasosa == default(int) && Ime == null &&
                Prezime == null && BrojTelefona == default(int) && Email == null)
                return View("PostojeciPutnik");

            var searchedPassanger = entities1.Putniks.Where(j => (BrojPasosa!=default(int) ?j.BrojPasosa == BrojPasosa: j.BrojPasosa == j.BrojPasosa) &&
                                                (Ime != null ? j.Ime.StartsWith(Ime) : j.Ime == j.Ime) &&
                                                (Prezime != null ? j.Prezime.StartsWith(Prezime) : j.Prezime == j.Prezime) &&
                                                (BrojTelefona != default(int) ? j.BrojTelefona== BrojTelefona : j.BrojTelefona == j.BrojTelefona)).ToList();

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
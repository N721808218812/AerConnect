using AerConnect.Models;
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

        public ActionResult Search(Putnik putnik)
        {
            char 
        }
    }
}
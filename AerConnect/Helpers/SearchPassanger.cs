using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AerConnect.Helpers
{
    public class SearchPassanger
    {
        [Display(Name = "Broj Pasosa")]
     
        public int BrojPasosa { get; set; }

       
        [Display(Name = "Ime")]
        public string Ime { get; set; }

   
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

       
        [Display(Name = "Broj Telefona")]
       
        public int BrojTelefona { get; set; }

        
        [Display(Name = "Email")]
        public string Email { get; set; }

 
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AerConnect.Helpers
{
    public class LjubimacRez
    {
        [Required]
        [Display(Name = "Broj čipa")]
        [RegularExpression("([0-9]{1,})", ErrorMessage = "Broj čipa mora biti u numerickom formatu *******")]
        public int BrojCipa { get; set; }

        [Required]
        [Display(Name = "Broj pasoša")]
        [RegularExpression("([0-9]{6,10})", ErrorMessage = "Broj pasoša mora biti u numerickom formatu *******")]
        public int BrojPasosa { get; set; }

        [Required]
        [Display(Name = "Ime ljubimca")]
        [StringLength(30, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Rasa")]
        [StringLength(30, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 2)]
        public string Rasa { get; set; }

        [Required]
        [Display(Name = "Težina")]
        [RegularExpression("([0-9]{1,})", ErrorMessage = "Težina ljubimca mora biti u numerickom formatu *******")]
        public int Tezina { get; set; }

        [Required]
        public int SifraRezervacije { get; set; }
    }
}
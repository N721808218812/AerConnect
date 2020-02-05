﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AerConnect.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SifraRezervacije { get; set; }


        public string Vreme { get; set; }


        [Display(Name = "Broj pasoša")]
        [RegularExpression("([0-9]{6,10})", ErrorMessage = "Broj pasoša mora biti u numerickom formatu *******")]
        public int BrojPasosa { get; set; }

        [Required]

        [DataType(DataType.Password)]
        [Display(Name = "Sifra Leta")]
        public int SifraLeta { get; set; }

        [Display(Name = "Broj čipa")]
        [RegularExpression("([0-9]{1,})", ErrorMessage = "Broj čipa mora biti u numerickom formatu *******")]
        public Nullable<int> BrojCipa { get; set; }


        public virtual Let Let { get; set; }
        public virtual Putnik Putnik { get; set; }
    }
}
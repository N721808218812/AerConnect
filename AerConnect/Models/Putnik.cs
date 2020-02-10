//------------------------------------------------------------------------------
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

    public partial class Putnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Putnik()
        {
            this.CheckIns = new HashSet<CheckIn>();
            this.Ljubimacs = new HashSet<Ljubimac>();
            this.Rezervacijas = new HashSet<Rezervacija>();
            this.Zalbas = new HashSet<Zalba>();
        }

        [[Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Broj Pasosa")]
        [RegularExpression("([0-9]{6})", ErrorMessage = "Maksimalna duzina pasosa je 6 karaktera")]
        public int BrojPasosa { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Ime")]
        [StringLength(30, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Prezime")]
        [StringLength(30, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 2)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Broj Telefona")]
        [RegularExpression("([06][0-9]{7,8})", ErrorMessage = "Morate uneti format 06*******(*)")]
        public int BrojTelefona { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(100, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Sifra")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ljubimac> Ljubimacs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zalba> Zalbas { get; set; }
    }
}

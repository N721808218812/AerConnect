//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AerConnect
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezervacija
    {
        public int SifraRezervacije { get; set; }
        public int SifraKarte { get; set; }
        public string Vreme { get; set; }
    
        public virtual Karta Karta { get; set; }
    }
}

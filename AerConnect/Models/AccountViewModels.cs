using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AerConnect.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Zapamti ovaj pregledac?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [DataType(DataType.Password)]
        [Display(Name = "Sifra")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Polje je obavezno!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [StringLength(100, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Sifra")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Polje je obavezno!")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite sifru")]
        [Compare("Password", ErrorMessage = "Sifra i potvrdjena sifra se ne poklapaju")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name ="Broj Pasosa")]
        [RegularExpression("([0-9]{6})",ErrorMessage ="Minimalna duzina pasosa je 6 karaktera")]
        public int BrojPasosa { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name = "Broj Telefona")]
        [RegularExpression("([06][0-9]{7,8})", ErrorMessage = "Morate uneti format 06*******(*)")]
        public int BrojTelefona { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name = "Ime")]
        [StringLength(30, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name = "Prezime")]
        [StringLength(30, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka ", MinimumLength = 2)]
        public string Prezime { get; set; }



    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Minimalna duzina mora da bude najmanje {2} karaktera dugacka", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Sifra")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda sifre")]
        [Compare("Password", ErrorMessage = "Sifra i potvrdjena sifra se ne poklapaju")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

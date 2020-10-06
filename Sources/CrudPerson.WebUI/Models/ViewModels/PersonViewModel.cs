using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CrudPerson.WebUI.Models.ViewModels
{
    [DebuggerDisplay("{Identifier} - {Firstname} - {Lastname}", Name = "{Lastname}")]
    public class PersonViewModel
    {
        public Guid Identifier { get; set; }

        [Display(Name = "Mailing address", Prompt = "Mailing address")]
        [Required(ErrorMessage = "The mailing adress is required")]
        public AddressViewModel Address { get; set; }

        [Display(Name = "Email address", Prompt = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Lastname", Prompt = "Lastname")]
        [Required(ErrorMessage = "The lastname is required")]
        public string Lastname { get; set; }

        [Display(Name = "Firstname", Prompt = "Firstname")]
        [Required(ErrorMessage = "The firstname is required")]
        public string Firstname { get; set; }

        [Display(Name = "Date of birth", Prompt = "Date of birth")]
        [Required(ErrorMessage = "The date of birth is required")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
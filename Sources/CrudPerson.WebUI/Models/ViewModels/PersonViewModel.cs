using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CrudPerson.WebUI.Models.ViewModels
{
    [DebuggerDisplay("{Identifier} - {Firstname} - {Lastname}", Name = "{Lastname}")]
    public class PersonViewModel
    {
        public Guid Identifier { get; set; }

        [Display(Name = "MailingAddress", Prompt = "MailingAddress")]
        [Required(ErrorMessage = "RequiredMailingAddress")]
        public AddressViewModel Address { get; set; }

        [Display(Name = "EmailAddress", Prompt = "EmailAddress")]
        [Required(ErrorMessage = "RequiredEmailAddress")]
        [EmailAddress(ErrorMessage = "InvalidEmailAddress")]
        public string Email { get; set; }

        [Display(Name = "Lastname", Prompt = "Lastname")]
        [Required(ErrorMessage = "RequiredLastname")]
        public string Lastname { get; set; }

        [Display(Name = "Firstname", Prompt = "Firstname")]
        [Required(ErrorMessage = "RequiredFirstname")]
        public string Firstname { get; set; }

        [Display(Name = "Birthdate", Prompt = "Birthdate")]
        [Required(ErrorMessage = "RequiredBirthdate")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
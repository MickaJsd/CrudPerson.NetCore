using System;
using System.ComponentModel.DataAnnotations;

namespace CrudPerson.WebUI.Models.ViewModels
{
    public class AddressViewModel
    {

        public Guid Identifier { get; set; }

        [Display(Name = "ZIP", Prompt = "ZIP code")]
        [Required(ErrorMessage = "The ZIP code is required")]
        public string ZipCode { get; set; }

        [Display(Name = "Street", Prompt = "Street and number")]
        [Required(ErrorMessage = "The street is required")]
        public string Street { get; set; }

        [Display(Name = "Additional", Prompt = "(optionnal) additional")]
        public string AdditionalAddress { get; set; }

        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [Display(Name = "Country", Prompt = "Country")]
        public string Country { get; set; }
    }
}
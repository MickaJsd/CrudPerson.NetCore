using System;
using System.ComponentModel.DataAnnotations;

namespace CrudPerson.WebUI.Models.ViewModels
{
    public class AddressViewModel
    {
        public Guid Identifier { get; set; }

        [Display(Name = "ZipCode", Prompt = "ZipCode")]
        [Required(ErrorMessage = "RequiredZipCode")]
        public string ZipCode { get; set; }

        [Display(Name = "Street", Prompt = "StreetDetail")]
        [Required(ErrorMessage = "RequiredStreet")]
        public string Street { get; set; }

        [Display(Name = "Additional", Prompt = "AdditionalDetail")]
        public string AdditionalAddress { get; set; }

        [Display(Name = "City", Prompt = "City")]
        [Required(ErrorMessage = "RequiredCity")]
        public string City { get; set; }

        [Display(Name = "Country", Prompt = "Country")]
        [Required(ErrorMessage = "RequiredCountry")]
        public string Country { get; set; }
    }
}
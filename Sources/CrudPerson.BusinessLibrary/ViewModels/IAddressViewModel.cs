using System.ComponentModel.DataAnnotations;

namespace CrudPerson.BusinessLibrary.ViewModels
{
    public interface IAddressViewModel
    {

        [Display(Name = "ZIP", Prompt = "ZIP code")]
        [Required(ErrorMessage = "The ZIP code is required")]
        string ZipCode { get; set; }

        [Display(Name = "Street", Prompt = "Street and number")]
        [Required(ErrorMessage = "The street is required")]
        string Street { get; set; }

        [Display(Name = "Additional", Prompt = "(optionnal) additional")]
        string AdditionalAddress { get; set; }

        [Display(Name = "City", Prompt = "City")]
        string City { get; set; }

        [Display(Name = "Country", Prompt = "Country")]
        string Country { get; set; }
    }
}
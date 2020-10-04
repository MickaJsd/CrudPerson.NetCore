using CrudPerson.BusinessLibrary.ViewModels;
using System;

namespace CrudPerson.WebUI.Models
{
    public class PersonEditModel : IPersonViewModel
    {
        public Guid Identifier { get; set; }
        public AddressEditModel Address { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthdate { get; set; }
        IAddressViewModel IPersonViewModel.Address { get => this.Address; set => this.Address = (AddressEditModel)value; }
    }
}

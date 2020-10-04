using CrudPerson.BusinessLibrary.BusinessModel;
using System;

namespace CrudPerson.WebUI.Models
{
    public class PersonEditModel : Person
    {
        public Guid Identifier { get; set; }
        public AddressEditModel Address { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthdate { get; set; }
        Address Person.Address { get => this.Address; set => this.Address = (AddressEditModel)value; }
    }
}

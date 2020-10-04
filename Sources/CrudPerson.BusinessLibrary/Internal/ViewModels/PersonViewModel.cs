using CrudPerson.BusinessLibrary.ViewModels;
using System;

namespace CrudPerson.BusinessLibrary.Internal.ViewModels
{
    internal class PersonViewModel : IPersonViewModel
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public IAddressViewModel Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Guid Identifier { get; set; }
    }
}

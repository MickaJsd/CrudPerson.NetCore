using CrudPerson.BusinessLibrary.ViewModels;

namespace CrudPerson.BusinessLibrary.Internal.ViewModels
{
    internal class AddressViewModel : IAddressViewModel
    {
        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string AdditionalAddress { get; set; }
    }
}

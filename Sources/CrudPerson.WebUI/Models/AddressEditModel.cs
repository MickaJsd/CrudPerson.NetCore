using CrudPerson.BusinessLibrary.BusinessModel;

namespace CrudPerson.WebUI.Models
{
    public class AddressEditModel : Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string AdditionalAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

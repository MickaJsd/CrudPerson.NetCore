using System;

namespace CrudPerson.BusinessLibrary.BusinessModel
{
    public class Address
    {
        public Guid Identifier { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string AdditionalAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
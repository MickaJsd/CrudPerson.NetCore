using System;
using System.Diagnostics;

namespace CrudPerson.BusinessLibrary.BusinessModel
{
    [DebuggerDisplay("{Identifier} - {Firstname} - {Lastname}", Name = "{Lastname}")]
    public class Person
    {
        public Guid Identifier { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
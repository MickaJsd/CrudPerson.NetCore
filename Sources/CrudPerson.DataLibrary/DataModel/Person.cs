using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CrudPerson.DataLibrary.DataModel
{
    [DebuggerDisplay("{Identifier} - {Firstname} - {Lastname}", Name = "{Lastname}")]
    public class Person
    {
        [Key]
        public Guid Identifier { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime Birthdate { get; set; }
    }
}

using System.Globalization;

namespace CrudPerson.DataLibrary.DataModel
{
    internal static class PersonExtensions
    {
        public static Person EnsureUtcDates(this Person person)
        {
            if(person == null)
            {
                return null;
            }
            person.Birthdate = person.Birthdate.ToUniversalTime();
            return person;
        }
    }
}

namespace CrudPerson.DataLibrary.DataModel
{
    internal static class PersonExtensions
    {
        /// <summary>
        /// Ensure that the <see cref="System.DateTime"/> parts of the specified <see cref="Person"/> object are translated to UTC.
        /// </summary>
        /// <param name="person">The <see cref="Person"/> to update the dates on.</param>
        /// <returns>The same <see cref="Person"/> so that multiple calls can be chained</returns>
        public static Person EnsureUtcDates(this Person person)
        {
            if (person == null)
            {
                return null;
            }
            person.Birthdate = person.Birthdate.ToUniversalTime();
            return person;
        }
    }
}

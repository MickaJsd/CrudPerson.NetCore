namespace CrudPerson.WebUI.Models.ViewModels
{
    internal static class PersonViewModelExtensions
    {
        public static PersonViewModel ToLocalDates(this PersonViewModel person)
        {
            if (person == null)
            {
                return null;
            }
            person.Birthdate = person.Birthdate.ToLocalTime();
            return person;
        }
    }
}

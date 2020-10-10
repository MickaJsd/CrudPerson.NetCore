using AutoMapper;
using CrudPerson.BusinessLibrary.BusinessModel;

namespace CrudPerson.WebUI.Models.ViewModels
{
    internal static class PersonViewModelExtensions
    {
        public static PersonViewModel ToviewModel(this Person person, IMapper mapper)
        {
            return mapper.Map<PersonViewModel>(person);
        }

        public static Person ToBusiness(this PersonViewModel person, IMapper mapper)
        {
            return mapper.Map<Person>(person);
        }
    }
}

using AutoMapper;
using CrudPerson.BusinessLibrary.BusinessModel;
using CrudPerson.WebUI.Models.ViewModels;

namespace CrudPerson.WebUI.Internal.Configuration
{
    internal class ViewModelAsBusinessMapping : Profile
    {
        public ViewModelAsBusinessMapping()
        {
            _ = this.CreateMap<Person, PersonViewModel>();
            _ = this.CreateMap<PersonViewModel, Person>();
            _ = this.CreateMap<Person, PersonViewModel>();
            _ = this.CreateMap<PersonViewModel, Person>();
        }
    }
}

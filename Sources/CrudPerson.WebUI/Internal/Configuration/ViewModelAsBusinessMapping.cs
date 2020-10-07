using AutoMapper;
using CrudPerson.BusinessLibrary.BusinessModel;
using CrudPerson.WebUI.Models.ViewModels;
using System;

namespace CrudPerson.WebUI.Internal.Configuration
{
    internal class ViewModelAsBusinessMapping : Profile
    {
        public ViewModelAsBusinessMapping()
        {
            _ = this.CreateMap<Person, PersonViewModel>().ForMember(p => p.Birthdate, opt => opt.MapFrom((p, _) => ToLocalTime(p)));
            _ = this.CreateMap<PersonViewModel, Person>();
            _ = this.CreateMap<Address, AddressViewModel>();
            _ = this.CreateMap<AddressViewModel, Address>();
        }

        private static DateTime ToLocalTime(Person businessPerson)
        {
            return businessPerson.Birthdate.ToLocalTime();
        }
    }
}

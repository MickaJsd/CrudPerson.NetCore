using AutoMapper;
using BusinessPerson = CrudPerson.BusinessLibrary.BusinessModel.Person;
using BusinessAddress = CrudPerson.BusinessLibrary.BusinessModel.Address;
using DataPerson = CrudPerson.DataLibrary.DataModel.Person;
using DataAddress = CrudPerson.DataLibrary.DataModel.Address;

namespace CrudPerson.BusinessLibrary.Internal.Configuration
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = this.CreateMap<BusinessPerson, DataPerson>().ForMember(src => src.Identifier, trgt => trgt.Ignore());
            _ = this.CreateMap<DataPerson, BusinessPerson>();
            _ = this.CreateMap<BusinessAddress, DataAddress>();
            _ = this.CreateMap<DataAddress, BusinessAddress>();
        }
    }
}

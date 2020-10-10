using AutoMapper;
using BusinessAddress = CrudPerson.BusinessLibrary.BusinessModel.Address;
using BusinessPerson = CrudPerson.BusinessLibrary.BusinessModel.Person;
using DataAddress = CrudPerson.DataLibrary.DataModel.Address;
using DataPerson = CrudPerson.DataLibrary.DataModel.Person;

namespace CrudPerson.BusinessLibrary.Internal.Configuration
{
    internal class BusinessAsDataMapping : Profile
    {
        public BusinessAsDataMapping()
        {
            _ = this.CreateMap<BusinessPerson, DataPerson>().ForMember(src => src.Identifier, trgt => trgt.Ignore());
            _ = this.CreateMap<DataPerson, BusinessPerson>();
            _ = this.CreateMap<BusinessAddress, DataAddress>().ForMember(src => src.Identifier, trgt => trgt.Ignore());
            _ = this.CreateMap<DataAddress, BusinessAddress>();
        }
    }
}

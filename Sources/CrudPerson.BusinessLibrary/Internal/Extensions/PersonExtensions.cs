using AutoMapper;
using System;
using BusinessPerson = CrudPerson.BusinessLibrary.BusinessModel.Person;
using DataPerson = CrudPerson.DataLibrary.DataModel.Person;

namespace CrudPerson.DataLibrary.DataModel
{
    internal static class PersonExtensions
    {
        public static BusinessPerson ToBusiness(this DataPerson person, IMapper mapper)
        {
            return mapper.Map<BusinessPerson>(person);
        }
        public static DataPerson ToData(this BusinessPerson person, IMapper mapper)
        {
            return mapper.Map<DataPerson>(person);
        }
    }
}

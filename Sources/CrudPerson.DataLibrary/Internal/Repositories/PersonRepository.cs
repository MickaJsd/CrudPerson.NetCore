using CrudPerson.DataLibrary.DataModel;
using CrudPerson.DataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudPerson.DataLibrary.Internal.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public Task<Person> CreateAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> DeteleAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> ReadAsync(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}

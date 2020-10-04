using CrudPerson.BusinessLibrary.BusinessModel;
using CrudPerson.BusinessLibrary.Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudPerson.BusinessLibrary.Internal.Managers
{
    internal class PersonManager : IPersonManager
    {
        #region ICrudPerson implementation
        /// <inheritdoc/>
        public Task<Person> CreateAsync(Person personViewModel)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc/>
        public Task<Person> DeteleAsync(Guid identifier)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Person>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Person> ReadAsync(Guid idPerson)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Person> UpdateAsync(Person personViewModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

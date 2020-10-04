using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.BusinessLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudPerson.BusinessLibrary.Internal.Managers
{
    internal class PersonManager : IPersonManager
    {
        #region ICrudPerson implementation
        /// <inheritdoc/>
        public Task<IPersonViewModel> CreateAsync(IPersonViewModel personViewModel)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc/>
        public Task<IPersonViewModel> DeteleAsync(Guid identifier)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<IPersonViewModel>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IPersonViewModel> ReadAsync(Guid idPerson)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IPersonViewModel> UpdateAsync(IPersonViewModel personViewModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

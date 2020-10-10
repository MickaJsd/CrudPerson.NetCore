using AutoMapper;
using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.CommonLibrary.Exceptions;
using CrudPerson.CommonLibrary.Resources;
using CrudPerson.DataLibrary.DataModel;
using CrudPerson.DataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessPerson = CrudPerson.BusinessLibrary.BusinessModel.Person;
using DataPerson = CrudPerson.DataLibrary.DataModel.Person;

namespace CrudPerson.BusinessLibrary.Internal.Managers
{
    internal class PersonManager : IPersonManager
    {
        #region Constructor
        public PersonManager(IPersonRepository personRepository, IMapper mapper)
        {
            this._personRepository = personRepository;
            this._mapper = mapper;
        }
        #endregion

        #region Private properties
        private IPersonRepository _personRepository { get; }
        private IMapper _mapper { get; }
        #endregion

        #region Private Methods

        private async Task<DataPerson> FindWithGuardsAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                return null;
            }

            DataPerson foundPerson = await this._personRepository.ReadAsync(identifier).ConfigureAwait(false);

            return foundPerson;
        }
        #endregion

        #region ICrudPerson implementation
        /// <inheritdoc/>
        public async Task<BusinessPerson> CreateAsync(BusinessPerson person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            DataPerson newPerson = person.ToData(this._mapper);
            newPerson.Identifier = Guid.NewGuid();
            DataPerson editedDataPerson = await this._personRepository.CreateAsync(newPerson)
                                            .ConfigureAwait(false);

            if (editedDataPerson == null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_EditActionName, ExceptionResources.FailedActionException_EditPersonExceptionMessage);
            }

            return editedDataPerson.ToBusiness(this._mapper);
        }

        /// <inheritdoc/>
        public async Task<BusinessPerson> DeteleAsync(Guid identifier)
        {
            DataPerson foundPerson = await this.FindWithGuardsAsync(identifier).ConfigureAwait(false);

            if (foundPerson == null)
            {
                return null;
            }

            DataPerson deletedPerson = await this._personRepository.DeteleAsync(foundPerson).ConfigureAwait(false);

            if (deletedPerson == null)
            {
                return null;
            }
            return deletedPerson.ToBusiness(this._mapper);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<BusinessPerson>> ListAllPersonBasicAsync()
        {
            IEnumerable<DataPerson> allPersons = await this._personRepository.ListAllPersonBasicAsync().ConfigureAwait(false);

            return allPersons.Select(p => p.ToBusiness(this._mapper));
        }

        /// <inheritdoc/>
        public async Task<BusinessPerson> ReadAsync(Guid identifier)
        {
            DataPerson foundPerson = await this.FindWithGuardsAsync(identifier).ConfigureAwait(false);

            if (foundPerson == null)
            {
                return null;
            }

            return foundPerson.ToBusiness(this._mapper);
        }

        /// <inheritdoc/>
        public async Task<BusinessPerson> UpdateAsync(BusinessPerson person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }
            DataPerson foundPerson = await this.FindWithGuardsAsync(person.Identifier).ConfigureAwait(false);
            if (foundPerson == null)
            {
                return null;
            }
            DataPerson editedDataPerson = this._mapper.Map(person, foundPerson);

            DataPerson updatedDataPerson = await this._personRepository.UpdateAsync(editedDataPerson).ConfigureAwait(false);

            if (updatedDataPerson == null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_EditActionName, ExceptionResources.FailedActionException_EditPersonExceptionMessage);
            }

            return updatedDataPerson.ToBusiness(this._mapper);
        }
        #endregion
    }
}

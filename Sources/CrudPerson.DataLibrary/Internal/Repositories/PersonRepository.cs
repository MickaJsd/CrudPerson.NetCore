using CrudPerson.CommonLibrary.Exceptions;
using CrudPerson.CommonLibrary.Resources;
using CrudPerson.DataLibrary.Data;
using CrudPerson.DataLibrary.DataModel;
using CrudPerson.DataLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.DataLibrary.Internal.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        #region Constructor
        public PersonRepository(IDatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        #endregion

        #region Private Properties
        private IDatabaseContext _databaseContext { get; }
        #endregion

        #region Private properties
        private IQueryable<Person> _personWithAddressQuery => this._databaseContext.Set<Person>().Include(p => p.Address);
        private IQueryable<Person> _basicPersonQuery => this._databaseContext.Set<Person>();
        #endregion

        #region IPersonRepository implementation
        /// <inheritdoc/>
        public async Task<Person> CreateAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            Person alreadyExistingPerson = await this._personWithAddressQuery.SingleOrDefaultAsync(p => p.Identifier == person.Identifier).ConfigureAwait(false);

            if (alreadyExistingPerson != null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_CreateActionName, ExceptionResources.FailedActionException_AlreadyExistingPerson, person.Identifier.ToString());
            }

            EntityEntry<Person> personTracker = this._databaseContext.Person.Add(person.EnsureUtcDates());

            int numberOfCreatedRows = await this._databaseContext.SaveChangesAsync().ConfigureAwait(false);

            if (numberOfCreatedRows != 1 || personTracker.State != EntityState.Unchanged)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_CreateActionName, ExceptionResources.FailedActionException_SavingError);
            }
            return person;
        }

        /// <inheritdoc/>
        public async Task<Person> DeteleAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            Person alreadyExistingPerson = await this._personWithAddressQuery.SingleOrDefaultAsync(p => p.Identifier == person.Identifier).ConfigureAwait(false);

            if (alreadyExistingPerson == null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_DeleteActionName, ExceptionResources.FailedActionException_UnexistingPerson, person.Identifier.ToString());
            }

            EntityEntry<Person> personTracker = this._databaseContext.Person.Remove(person);

            int numberOfCreatedRows = await this._databaseContext.SaveChangesAsync().ConfigureAwait(false);
            if (numberOfCreatedRows != 1 || personTracker.State != EntityState.Detached)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_DeleteActionName, ExceptionResources.FailedActionException_SavingError);
            }
            return person;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Person>> ListAllPersonBasicAsync()
        {
            return await this._basicPersonQuery.ToListAsync()
                       .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<Person> ReadAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                throw new ArgumentNullOrEmptyException(nameof(identifier), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonIdentifier);
            }
            Person person = await this._personWithAddressQuery.SingleOrDefaultAsync(p => p.Identifier == identifier).ConfigureAwait(false);
            return person;
        }

        /// <inheritdoc/>
        public async Task<Person> UpdateAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            Person alreadyExistingPerson = await this._personWithAddressQuery.SingleOrDefaultAsync(p => p.Identifier == person.Identifier).ConfigureAwait(false);

            if (alreadyExistingPerson == null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_EditActionName, ExceptionResources.FailedActionException_UnexistingPerson, person.Identifier.ToString());
            }

            EntityEntry<Person> personTracker = this._databaseContext.Person.Update(person.EnsureUtcDates());

            int numberOfCreatedRows = await this._databaseContext.SaveChangesAsync().ConfigureAwait(false);
            if (numberOfCreatedRows != 1 || personTracker.State != EntityState.Unchanged)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_DeleteActionName, ExceptionResources.FailedActionException_SavingError);
            }
            return person;
        }
        #endregion
    }
}

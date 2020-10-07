using CrudPerson.CommonLibrary.Exceptions;
using CrudPerson.CommonLibrary.Resources;
using CrudPerson.DataLibrary.Data;
using CrudPerson.DataLibrary.DataModel;
using CrudPerson.DataLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private IQueryable<Person> _personWithAddress => this._databaseContext.Set<Person>().Include(p => p.Address);
        private IQueryable<Person> _personMinimal => this._databaseContext.Set<Person>();
        #endregion

        #region IPersonRepository implementation
        public async Task<Person> CreateAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            Person alreadyExistingPerson = await this._personWithAddress.SingleOrDefaultAsync(p => p.Identifier == person.Identifier)
                                            .ConfigureAwait(false);

            if (alreadyExistingPerson != null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_CreateActionName, ExceptionResources.FailedActionException_AlreadyExistingPerson, person.Identifier.ToString());
            }

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Person> personTracker = this._databaseContext.Person.Add(person.EnsureUtcDates());

            int numberOfCreatedRows = await this._databaseContext.SaveChangesAsync()
                                        .ConfigureAwait(false);
            if (numberOfCreatedRows != 1 || personTracker.State != EntityState.Unchanged)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_CreateActionName, ExceptionResources.FailedActionException_SavingError);
            }
            return person;
        }

        public async Task<Person> DeteleAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            Person alreadyExistingPerson = await this._personWithAddress.SingleOrDefaultAsync(p => p.Identifier == person.Identifier)
                                            .ConfigureAwait(false);

            if (alreadyExistingPerson == null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_DeleteActionName, ExceptionResources.FailedActionException_UnexistingPerson, person.Identifier.ToString());
            }

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Person> personTracker = this._databaseContext.Person.Remove(person);

            int numberOfCreatedRows = await this._databaseContext.SaveChangesAsync()
                                        .ConfigureAwait(false);
            if (numberOfCreatedRows != 1 || personTracker.State != EntityState.Detached)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_DeleteActionName, ExceptionResources.FailedActionException_SavingError);
            }
            return person;
        }

        public async Task<IEnumerable<Person>> ListAllMinimalAsync()
        {
            return await this._personMinimal.ToListAsync()
                       .ConfigureAwait(false);
        }

        public async Task<Person> ReadAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                throw new ArgumentNullOrEmptyException(nameof(identifier), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonIdentifier);
            }
            return await this._personWithAddress.SingleOrDefaultAsync(p => p.Identifier == identifier)
                        .ConfigureAwait(false);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(person), ExceptionResources.ArgumentNullOrEmptyException_RequiredPersonData);
            }

            Person alreadyExistingPerson = await this._personWithAddress.SingleOrDefaultAsync(p => p.Identifier == person.Identifier)
                                            .ConfigureAwait(false);

            if (alreadyExistingPerson == null)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_EditActionName, ExceptionResources.FailedActionException_UnexistingPerson, person.Identifier.ToString());
            }

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Person> personTracker = this._databaseContext.Person.Update(person.EnsureUtcDates());

            int numberOfCreatedRows = await this._databaseContext.SaveChangesAsync()
                                        .ConfigureAwait(false);
            if (numberOfCreatedRows != 1 || personTracker.State != EntityState.Unchanged)
            {
                throw new FailedActionException(ExceptionResources.FailedActionException_DeleteActionName, ExceptionResources.FailedActionException_SavingError);
            }
            return person;
        }
        #endregion
    }
}

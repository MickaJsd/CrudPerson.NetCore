using AutoMapper;
using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.WebUI.Models;
using CrudPerson.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessPerson = CrudPerson.BusinessLibrary.BusinessModel.Person;

namespace CrudPerson.WebUI.Internal.Models
{
    /// <summary>
    /// Central access point to the <see cref="IPersonManager"/> :
    ///  - calls the manager;
    ///  - transform the received business object to viewModels
    /// </summary>
    internal class PersonModel : IPersonModel
    {
        /************ NB ************
         * Dans cette classe j'ai hésité à conserver les guards clauses.
         * En principe je sais qu'elle est appelée par un controller de manière interne à ce projet
         * mais si le projet est amené à évoluer, cette classe pourrait servir à d'autres controllers 
         * qui riqueraient de  ne pas faire ces vérifications. Ainsi les guard clauses sont duppliquées.
         ****************************/

        #region Private properties
        private IPersonManager _personManager { get; }
        private IMapper _mapper { get; }
        #endregion

        #region Constructor
        public PersonModel(IPersonManager personManager, IMapper mapper)
        {
            this._personManager = personManager;
            this._mapper = mapper;
        }
        #endregion

        #region Private Methods
        private async Task<PersonViewModel> EditPersonWithGuardsAsync(PersonViewModel personModel, Func<BusinessPerson, Task<BusinessPerson>> editionFunctionAsync)
        {
            if (personModel == null)
            {
                return null;
            }
            BusinessPerson personToEdit = personModel.ToBusiness(this._mapper);

            BusinessPerson editedBusinessPerson = await editionFunctionAsync(personToEdit).ConfigureAwait(false);

            PersonViewModel editedPersonModel = editedBusinessPerson.ToviewModel(this._mapper);
            return editedPersonModel;

        }
        #endregion

        #region IPersonModel implementation
        /// <inheritdoc/>
        public async Task<IEnumerable<PersonViewModel>> ListAllPersonBasicAsync()
        {
            IEnumerable<BusinessPerson> allBusinessPerson = await this._personManager.ListAllPersonBasicAsync().ConfigureAwait(false);
            IEnumerable<PersonViewModel> persons = allBusinessPerson?.Select(p => p.ToviewModel(this._mapper));
            return persons;
        }

        /// <inheritdoc/>
        public async Task<PersonViewModel> ReadAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                return null;
            }
            BusinessPerson foundPerson = await this._personManager.ReadAsync(identifier).ConfigureAwait(false);

            return foundPerson.ToviewModel(this._mapper);
        }

        /// <inheritdoc/>
        public Task<PersonViewModel> UpdateAsync(PersonViewModel personModel)
        {
            return this.EditPersonWithGuardsAsync(personModel, this._personManager.UpdateAsync);
        }

        /// <inheritdoc/>
        public Task<PersonViewModel> CreateAsync(PersonViewModel personModel)
        {
            return this.EditPersonWithGuardsAsync(personModel, this._personManager.CreateAsync);
        }

        /// <inheritdoc/>
        public async Task<PersonViewModel> DeteleAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                return null;
            }

            BusinessPerson deletedBusinessPerson = await this._personManager.DeteleAsync(identifier).ConfigureAwait(false);

            PersonViewModel deletedPersonModel = deletedBusinessPerson.ToviewModel(this._mapper);
            return deletedPersonModel;
        }
        #endregion
    }
}

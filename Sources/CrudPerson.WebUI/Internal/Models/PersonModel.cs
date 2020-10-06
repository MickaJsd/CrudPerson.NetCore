using AutoMapper;
using BusinessPerson = CrudPerson.BusinessLibrary.BusinessModel.Person;
using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.WebUI.Models;
using CrudPerson.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.WebUI.Internal.Models
{
    internal class PersonModel : IPersonModel
    {
        /************
         * Dans cette classe je n'étais pas sûr pour les guards clauses : 
         * en principe je sais qu'elle est appelée par un controller en interne à ce projet
         * mais dans l'idée, si le projet avait été amené à évoluer, cette classe pourrait 
         * servir à d'autres controllers qui pourraient ne pas faire ces vérifications.
         *************/

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
            BusinessPerson personToEdit = this._mapper.Map<BusinessPerson>(personModel);

            BusinessPerson editedPerson = await editionFunctionAsync(personToEdit)
                                           .ConfigureAwait(false);

            return this._mapper.Map<PersonViewModel>(editedPerson);

        }
        #endregion

        #region IPersonModel implementation
        public async Task<IEnumerable<PersonViewModel>> ListAllMinimalAsync()
        {
            IEnumerable<BusinessPerson> allBusinessPerson = await this._personManager.ListAllMinimalAsync()
                                                                .ConfigureAwait(false);
            return allBusinessPerson?.Select(p => this._mapper.Map<PersonViewModel>(p));
        }

        public async Task<PersonViewModel> ReadAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                return null;
            }
            BusinessPerson foundPerson = await this._personManager.ReadAsync(identifier)
                                            .ConfigureAwait(false);

            return this._mapper.Map<PersonViewModel>(foundPerson);
        }

        public Task<PersonViewModel> UpdateAsync(PersonViewModel personModel)
        {
            return this.EditPersonWithGuardsAsync(personModel, this._personManager.UpdateAsync);
        }

        public Task<PersonViewModel> CreateAsync(PersonViewModel personModel)
        {
            return this.EditPersonWithGuardsAsync(personModel, this._personManager.CreateAsync);
        }

        public async Task<PersonViewModel> DeteleAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                return null;
            }

            BusinessPerson deletedPerson = await this._personManager.DeteleAsync(identifier)
                                               .ConfigureAwait(false);

            return this._mapper.Map<PersonViewModel>(deletedPerson);
        } 
        #endregion
    }
}

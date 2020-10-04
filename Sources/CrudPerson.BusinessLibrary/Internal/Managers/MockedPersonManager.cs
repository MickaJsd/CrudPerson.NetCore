using CrudPerson.BusinessLibrary.Internal.ViewModels;
using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.BusinessLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.BusinessLibrary.Internal.Managers
{
    internal class MockedPersonManager : IPersonManager
    {
        #region Constructor
        public MockedPersonManager()
        {
            this._mockedUpDataPerson = this._initialMockedUpDataPerson.ToDictionary(p => p.Identifier, p => p);
        }
        #endregion

        #region Privates properties

        private readonly IPersonViewModel[] _initialMockedUpDataPerson = new IPersonViewModel[] {
                new PersonViewModel
                {
                    Firstname = "Bruce",
                    Lastname = "Dickinson",
                    Address = new AddressViewModel
                    {
                        Street = "Priorswell Rd",
                        AdditionalAddress ="second floor",
                        City ="Workshop",
                        ZipCode =  "S80 2BW",
                        Country = "Royaume-Uni"

                    },
                    Email ="bdickinson@ironmaiden.com",
                    Birthdate = new DateTime(1958, 8, 7),
                    Identifier = new Guid("87befc3e-dca1-4efd-b7d5-b91939beec4c")
                },
                new PersonViewModel
                {
                    Firstname = "James",
                    Lastname = "Hetfield",
                    Address = new AddressViewModel
                    {
                        Street = "9612 Ardine St",
                        City ="Downey",
                        ZipCode =  "CA 90241",
                        Country = "États-Unis"

                    },
                    Email ="james.hetfield@metallica.us",
                    Birthdate = new DateTime(1963, 8, 3),
                    Identifier = new Guid("414b34a4-d5d3-4128-98ed-23c64ae900c5")
                },
                new PersonViewModel
                {
                    Firstname = "Johannes",
                    Lastname = "Eckerström",
                    Address = new AddressViewModel
                    {
                        Street = "Kyrkogatan 28",
                        City ="Göteborg",
                        ZipCode =  "411 15",
                        Country = "Suède"

                    },
                    Email ="johanneseckerstrom@avatarband.se",
                    Birthdate = new DateTime(1986, 7, 2),
                    Identifier = new Guid("22c2d1a1-ac0d-4fe2-a2fc-f4c16381bee4")
                },
                new PersonViewModel {
                    Firstname = "Tarja",
                    Lastname = "Turunen",
                    Address = new AddressViewModel {
                        Street = "Mäsäsläntie 2",
                        City = "Kitee",
                        ZipCode = "82430",
                        Country = "Finlande"

                    },
                    Email = "tar.turunen@nightwish.fi",
                    Birthdate = new DateTime(1977, 8, 17),
                    Identifier = new Guid("98147104-b970-46b4-86c0-af5c8853c119")
                }
            };

        private Dictionary<Guid, IPersonViewModel> _mockedUpDataPerson { get; set; }
        #endregion

        #region Private methods
        private async Task<IPersonViewModel> FindWithGuardsAsync(IPersonViewModel personViewModel)
        {
            if (personViewModel == null)
            {
                return null;
            }
            return await this.FindWithGuardsAsync(personViewModel.Identifier).ConfigureAwait(false);
        }

        private Task<IPersonViewModel> FindWithGuardsAsync(Guid identifier)
        {
            if (this._mockedUpDataPerson.ContainsKey(identifier))
            {
                return Task.FromResult(this._mockedUpDataPerson[identifier]);
            }
            return Task.FromResult((IPersonViewModel)null);
        }
        #endregion

        #region ICrudPerson implementation
        /// <inheritdoc/>
        public Task<IPersonViewModel> CreateAsync(IPersonViewModel personViewModel)
        {
            personViewModel.Identifier = Guid.NewGuid();
            this._mockedUpDataPerson.Add(personViewModel.Identifier, personViewModel);
            return Task.FromResult(personViewModel);
        }

        /// <inheritdoc/>
        public async Task<IPersonViewModel> DeteleAsync(Guid identifier)
        {
            IPersonViewModel person = await this.FindWithGuardsAsync(identifier)
                                        .ConfigureAwait(false);
            if (person != null)
            {
                _ = this._mockedUpDataPerson.Remove(person.Identifier);
            }
            return person;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<IPersonViewModel>> ListAllAsync()
        {
            return Task.FromResult((IEnumerable<IPersonViewModel>)this._mockedUpDataPerson.Values);
        }

        /// <inheritdoc/>
        public Task<IPersonViewModel> ReadAsync(Guid idPerson)
        {
            return this.FindWithGuardsAsync(idPerson);
        }

        /// <inheritdoc/>
        public async Task<IPersonViewModel> UpdateAsync(IPersonViewModel personViewModel)
        {
            IPersonViewModel person = await this.FindWithGuardsAsync(personViewModel)
                                        .ConfigureAwait(false);
            if (person != null)
            {
                this._mockedUpDataPerson[person.Identifier] = personViewModel;
                return personViewModel;
            }
            return person;
        }
        #endregion
    }
}

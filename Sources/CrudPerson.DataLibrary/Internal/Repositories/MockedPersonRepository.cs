using CrudPerson.DataLibrary.DataModel;
using CrudPerson.DataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.DataLibrary.Internal.Repositories
{
    internal class MockedPersonRepository : IPersonRepository
    {
        #region Constructor
        public MockedPersonRepository()
        {
            this._mockedUpDataPerson = this._initialMockedUpDataPerson.ToDictionary(p => p.Identifier, p => p);
        }
        #endregion

        #region Privates properties

        private readonly Person[] _initialMockedUpDataPerson = new Person[] {
                new Person
                {
                    Firstname = "Bruce",
                    Lastname = "Dickinson",
                    Address = new Address
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
                new Person
                {
                    Firstname = "James",
                    Lastname = "Hetfield",
                    Address = new Address
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
                new Person
                {
                    Firstname = "Johannes",
                    Lastname = "Eckerström",
                    Address = new Address
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
                new Person {
                    Firstname = "Tarja",
                    Lastname = "Turunen",
                    Address = new Address {
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

        private Dictionary<Guid, Person> _mockedUpDataPerson { get; set; }
        #endregion

        #region Private methods
        private async Task<Person> FindWithGuardsAsync(Person Person)
        {
            if (Person == null)
            {
                return null;
            }
            return await this.FindWithGuardsAsync(Person.Identifier).ConfigureAwait(false);
        }

        private Task<Person> FindWithGuardsAsync(Guid identifier)
        {
            if (this._mockedUpDataPerson.ContainsKey(identifier))
            {
                return Task.FromResult(this._mockedUpDataPerson[identifier]);
            }
            return Task.FromResult((Person)null);
        }
        #endregion

        #region IPersonRepository implementation
        /// <inheritdoc/>
        public Task<Person> CreateAsync(Person Person)
        {
            Person.Identifier = Guid.NewGuid();
            this._mockedUpDataPerson.Add(Person.Identifier, Person);
            return Task.FromResult(Person);
        }

        /// <inheritdoc/>
        public async Task<Person> DeteleAsync(Person Person)
        {
            Person person = await this.FindWithGuardsAsync(Person)
                                        .ConfigureAwait(false);
            if (person != null)
            {
                _ = this._mockedUpDataPerson.Remove(person.Identifier);
            }
            return person;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Person>> ListAllPersonBasicAsync()
        {
            return Task.FromResult((IEnumerable<Person>)this._mockedUpDataPerson.Values);
        }

        /// <inheritdoc/>
        public Task<Person> ReadAsync(Guid idPerson)
        {
            return this.FindWithGuardsAsync(idPerson);
        }

        /// <inheritdoc/>
        public async Task<Person> UpdateAsync(Person Person)
        {
            Person person = await this.FindWithGuardsAsync(Person)
                                        .ConfigureAwait(false);
            if (person != null)
            {
                this._mockedUpDataPerson[person.Identifier] = Person;
                return Person;
            }
            return person;
        }
        #endregion
    }
}

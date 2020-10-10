using CrudPerson.DataLibrary.DataModel;
using CrudPerson.DataLibrary.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Tests.DataLibrary
{

    [TestClass]
    public class PersonManagerTests : TestsBase
    {
        [TestMethod]
        public async Task CreateReadUpdateDeleteTest()
        {
            // arrange 
            IPersonRepository service = this.ServiceProvider.GetService<IPersonRepository>();


            // - create
            // arrange 
            Guid newIdentifier = new Guid("548a5f4d-9c25-4d80-9a6d-cdb3a03f0228");
            Person newPerson = new Person {
                Firstname = "Ronald",
                Lastname = "Scott",
                Email = "bon.scott@acdc.au",
                Birthdate = new DateTime(1946, 7, 9),
                Identifier = newIdentifier,
                Address = new Address {
                    Identifier = newIdentifier,
                    Street = "30 Glebe Ct",
                    City = "Kirriemuir",
                    ZipCode = "DD8 4DP",
                    Country = "Ecosse"
                }
            };

            // act
            Person createdPerson = await service.CreateAsync(newPerson).ConfigureAwait(false);

            // assert
            Assert.IsNotNull(createdPerson);
            Assert.AreEqual(createdPerson.Identifier, newIdentifier);

            // - read
            // act
            Person readPerson = await service.ReadAsync(newIdentifier).ConfigureAwait(false);

            // assert
            Assert.IsNotNull(readPerson);

            // - update
            // arrange
            const string NEW_FIRST_NAME = "Bon";
            const string NEW_ADDITIONAL_ADDRESS = "Second floor";
            readPerson.Firstname = NEW_FIRST_NAME;
            readPerson.Address.AdditionalAddress = NEW_ADDITIONAL_ADDRESS;

            // act
            Person updatedPerson = await service.UpdateAsync(readPerson).ConfigureAwait(false);

            // assert
            Assert.IsNotNull(updatedPerson);
            Assert.AreEqual(updatedPerson.Firstname, NEW_FIRST_NAME);
            Assert.AreEqual(updatedPerson.Address.AdditionalAddress, NEW_ADDITIONAL_ADDRESS);
            Assert.AreEqual(updatedPerson.Identifier, newIdentifier);

            // - delete
            // act
            Person deletedPerson = await service.DeteleAsync(readPerson).ConfigureAwait(false);

            // assert
            Assert.IsNotNull(deletedPerson);

            // - List all
            // act
            IEnumerable<Person> persons = await service.ListAllPersonBasicAsync().ConfigureAwait(false);

            // assert
            Assert.IsNotNull(persons);
            Assert.IsNull(persons.FirstOrDefault(p => p.Identifier == newIdentifier));
        }

    }
}

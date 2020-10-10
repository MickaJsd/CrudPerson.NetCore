using CrudPerson.BusinessLibrary.BusinessModel;
using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.Tests.Internal.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Tests.BusinessLibrary
{
    [TestClass]
    public class PersonManagerTests : TestsBase
    {      
        [TestMethod]
        public async Task CreateReadUpdateDeleteTest()
        {
            // arrange 
            IPersonManager service = this.ServiceProvider.GetService<IPersonManager>();


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
            Person createdPerson = await service.CreateAsync(newPerson);

            // assert
            Assert.IsNotNull(createdPerson);
            Assert.AreNotEqual(createdPerson.Identifier, newIdentifier);

            // - read
            // arrange 
            Guid createdIdentifier = createdPerson.Identifier;

            // act
            Person readPerson = await service.ReadAsync(createdIdentifier);

            // assert
            Assert.IsNotNull(readPerson);

            // - update
            // arrange
            const string NEW_FIRST_NAME = "Bon";
            readPerson.Firstname = NEW_FIRST_NAME;

            // act
            Person updatedPerson = await service.UpdateAsync(readPerson);

            // assert
            Assert.IsNotNull(updatedPerson);
            Assert.AreEqual(updatedPerson.Firstname, NEW_FIRST_NAME);
            Assert.AreEqual(updatedPerson.Identifier, createdIdentifier);

            // - delete
            // act
            Person deletedPerson = await service.DeteleAsync(readPerson.Identifier);

            // assert
            Assert.IsNotNull(deletedPerson);

            // - List all
            // act
            IEnumerable<Person> persons = await service.ListAllPersonBasicAsync();

            // assert
            Assert.IsNotNull(persons);
            Assert.IsNull(persons.FirstOrDefault(p => p.Identifier == createdIdentifier));
        }

    }
}

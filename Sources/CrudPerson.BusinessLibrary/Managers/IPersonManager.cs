﻿using CrudPerson.BusinessLibrary.BusinessModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudPerson.BusinessLibrary.Managers
{
    public interface IPersonManager
    {
        /// <summary>
        /// Lists all the existing persons with only the basic informations
        /// </summary>
        /// <returns>The <see cref="IEnumerable<Person>"/> that represents all the existing persons with basic informations</returns>
        Task<IEnumerable<Person>> ListAllPersonBasicAsync();

        /// <summary>
        /// Gets the <see cref="Person"/> by its identifier
        /// </summary>
        /// <param name="pesonIdentifier">The <see cref="Guid"/> identifier of the person to get</param>
        /// <returns>If the person has been found, the found <see cref="Person"/>; else <see cref="null"/></returns>
        Task<Person> ReadAsync(Guid identifier);

        /// <summary>
        /// Updates the specified <see cref="Person"/> if it exists
        /// </summary>
        /// <param name="person">The <see cref="Person"/> to update</param>
        /// <returns>If the <see cref="Person"/> exists, the updated <see cref="Person"/>; else <see cref="null"/></returns>
        Task<Person> UpdateAsync(Person person);

        /// <summary>
        /// Creates the specified <see cref="Person"/>
        /// </summary>
        /// <param name="person">The <see cref="Person"/> to create</param>
        /// <returns>The created <see cref="Person"/></returns>
        Task<Person> CreateAsync(Person person);

        /// <summary>
        /// Deletes the <see cref="Person"/> identified by its <see cref="Guid"/> identifier
        /// </summary>
        /// <param name="identifier">The <see cref="Guid"/> identifier of the person to delete</param>
        /// <returns>If the <see cref="Person"/> exists, the deleted <see cref="Person"/>; else <see cref="null"/></returns>
        Task<Person> DeteleAsync(Guid identifier);

    }
}

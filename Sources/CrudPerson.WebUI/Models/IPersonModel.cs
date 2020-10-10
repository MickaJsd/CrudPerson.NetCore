using CrudPerson.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudPerson.WebUI.Models
{
    public interface IPersonModel
    {
        /// <summary>
        /// Lists all the existing persons
        /// </summary>
        /// <returns>The <see cref="IEnumerable<PersonViewModel>"/> that represents all the existing persons with fewest informations</returns>
        Task<IEnumerable<PersonViewModel>> ListAllPersonBasicAsync();

        /// <summary>
        /// Gets the <see cref="PersonViewModel"/> by its identifier
        /// </summary>
        /// <param name="pesonIdentifier">The <see cref="Guid"/> identifier of the person to get</param>
        /// <returns>If the person has been found, the found <see cref="PersonViewModel"/>; else <see cref="null"/></returns>
        Task<PersonViewModel> ReadAsync(Guid identifier);

        /// <summary>
        /// Updates the specified <see cref="PersonViewModel"/> if it exists
        /// </summary>
        /// <param name="personModel">The <see cref="PersonViewModel"/> to update</param>
        /// <returns>If the <see cref="PersonViewModel"/> exists, the updated <see cref="PersonViewModel"/>; else <see cref="null"/></returns>
        Task<PersonViewModel> UpdateAsync(PersonViewModel personModel);

        /// <summary>
        /// Creates the specified <see cref="PersonViewModel"/>
        /// </summary>
        /// <param name="personModel">The <see cref="PersonViewModel"/> to create</param>
        /// <returns>The created <see cref="PersonViewModel"/></returns>
        Task<PersonViewModel> CreateAsync(PersonViewModel personModel);

        /// <summary>
        /// Deletes the <see cref="PersonViewModel"/> identified by its <see cref="Guid"/> identifier
        /// </summary>
        /// <param name="identifier">The <see cref="Guid"/> identifier of the person to delete</param>
        /// <returns>If the <see cref="PersonViewModel"/> exists, the deleted <see cref="PersonViewModel"/>; else <see cref="null"/></returns>
        Task<PersonViewModel> DeteleAsync(Guid identifier);
    }
}

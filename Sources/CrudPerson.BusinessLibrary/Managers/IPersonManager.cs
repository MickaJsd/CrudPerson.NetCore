using CrudPerson.BusinessLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudPerson.BusinessLibrary.Managers
{
    public interface IPersonManager
    {
        /// <summary>
        /// Lists all the existing persons
        /// </summary>
        /// <returns>The <see cref="IEnumerable<IPersonViewModel>"/> that represents all the existing persons</returns>
        Task<IEnumerable<IPersonViewModel>> ListAllAsync();

        /// <summary>
        /// Gets the <see cref="IPersonViewModel"/> by its identifier
        /// </summary>
        /// <param name="pesonIdentifier">The <see cref="Guid"/> identifier of the person to get</param>
        /// <returns>If the person has been found, the found <see cref="IPersonViewModel"/>; else <see cref="null"/></returns>
        Task<IPersonViewModel> ReadAsync(Guid pesonIdentifier);

        /// <summary>
        /// Updates the specified <see cref="IPersonViewModel"/> if it exists
        /// </summary>
        /// <param name="personViewModel">The <see cref="IPersonViewModel"/> to update</param>
        /// <returns>If the <see cref="IPersonViewModel"/> exists, the updated <see cref="IPersonViewModel"/>; else <see cref="null"/></returns>
        Task<IPersonViewModel> UpdateAsync(IPersonViewModel personViewModel);

        /// <summary>
        /// Creates the specified <see cref="IPersonViewModel"/>
        /// </summary>
        /// <param name="personViewModel">The <see cref="IPersonViewModel"/> to create</param>
        /// <returns>The created <see cref="IPersonViewModel"/></returns>
        Task<IPersonViewModel> CreateAsync(IPersonViewModel personViewModel);

        /// <summary>
        /// Deletes the specified <see cref="IPersonViewModel"/> if it exists
        /// </summary>
        /// <param name="personViewModel">The <see cref="Guid"/> identifier of the person to delete</param>
        /// <returns>If the <see cref="IPersonViewModel"/> exists, the deleted <see cref="IPersonViewModel"/>; else <see cref="null"/></returns>
        Task<IPersonViewModel> DeteleAsync(Guid identifier);

    }
}

using CrudPerson.DataLibrary.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrudPerson.DataLibrary.Data
{
    interface IDatabaseContext
    {
        #region Properties
        DbSet<Person> Person { get; set; }
        #endregion

        #region Methods
        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        #endregion
    }
}

using CrudPerson.DataLibrary.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Threading.Tasks;

namespace CrudPerson.DataLibrary.Data
{
    public interface IDatabaseContext : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache, IDbContextPoolable, IResettableService
    {
        #region Properties
        DatabaseFacade Database { get; }

        #region DbSets
        DbSet<Person> Person { get; set; }
        DbSet<Address> Address { get; set; }
        #endregion
        #endregion

        #region Methods
        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        #endregion
    }
}

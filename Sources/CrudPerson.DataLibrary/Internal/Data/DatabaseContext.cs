using CrudPerson.DataLibrary.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CrudPerson.DataLibrary.Internal.Data
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Address>(adressBuilder =>
              {
                  _ = adressBuilder.ToTable(nameof(DataModel.Person));
              });
            _ = modelBuilder.Entity<Person>(personBuilder =>
              {
                  _ = personBuilder.HasOne(person => person.Address)
                                  .WithOne()
                                  .HasForeignKey<Address>(address => address.Identifier);
              });

        }
    }
}

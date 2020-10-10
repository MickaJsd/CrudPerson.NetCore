using CrudPerson.DataLibrary.Data;
using CrudPerson.DataLibrary.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CrudPerson.DataLibrary.Internal.Data
{
    internal class DatabaseContext : DbContext, IDatabaseContext
    {
        #region Constructor
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        } 
        #endregion

        #region DbSets
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        #endregion

        #region IDatabaseContext implementation

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        #endregion

        #region Model creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder
                .Entity<Address>(adressBuilder =>
                {
                    _ = adressBuilder
                        .ToTable(nameof(DataModel.Person));
                })
                .Entity<Person>(personBuilder =>
                {
                    _ = personBuilder
                        .ToTable(nameof(DataModel.Person))
                        .HasOne(person => person.Address).WithOne()
                        .HasForeignKey<Address>(address => address.Identifier);
                });
            this.AddMinimalDataPerson(modelBuilder);
        }

        private void AddMinimalDataPerson(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Person>().HasData(
                new Person {
                    Firstname = "Bruce",
                    Lastname = "Dickinson",
                    Email = "bdickinson@ironmaiden.com",
                    Birthdate = new DateTime(1958, 8, 7),
                    Identifier = new Guid("87befc3e-dca1-4efd-b7d5-b91939beec4c")
                },
                new Person {
                    Firstname = "James",
                    Lastname = "Hetfield",
                    Email = "james.hetfield@metallica.us",
                    Birthdate = new DateTime(1963, 8, 3),
                    Identifier = new Guid("414b34a4-d5d3-4128-98ed-23c64ae900c5")
                },
                new Person {
                    Firstname = "Johannes",
                    Lastname = "Eckerström",
                    Email = "johanneseckerstrom@avatarband.se",
                    Birthdate = new DateTime(1986, 7, 2),
                    Identifier = new Guid("22c2d1a1-ac0d-4fe2-a2fc-f4c16381bee4")
                },
                new Person {
                    Firstname = "Tarja",
                    Lastname = "Turunen",
                    Email = "tar.turunen@nightwish.fi",
                    Birthdate = new DateTime(1977, 8, 17),
                    Identifier = new Guid("98147104-b970-46b4-86c0-af5c8853c119")
                });

            _ = modelBuilder.Entity<Address>().HasData(
                new Address {
                    Identifier = new Guid("87befc3e-dca1-4efd-b7d5-b91939beec4c"),
                    Street = "Priorswell Rd",
                    AdditionalAddress = "second floor",
                    City = "Workshop",
                    ZipCode = "S80 2BW",
                    Country = "Royaume-Uni"

                },
                new Address {
                    Identifier = new Guid("414b34a4-d5d3-4128-98ed-23c64ae900c5"),
                    Street = "9612 Ardine St",
                    City = "Downey",
                    ZipCode = "CA 90241",
                    Country = "États-Unis"

                },
                new Address {
                    Identifier = new Guid("22c2d1a1-ac0d-4fe2-a2fc-f4c16381bee4"),
                    Street = "Kyrkogatan 28",
                    City = "Göteborg",
                    ZipCode = "411 15",
                    Country = "Suède"

                },
                new Address {
                    Identifier = new Guid("98147104-b970-46b4-86c0-af5c8853c119"),
                    Street = "Mäsäsläntie 2",
                    City = "Kitee",
                    ZipCode = "82430",
                    Country = "Finlande"

                });

        } 
        #endregion
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CrudPerson.DataLibrary.Migrations
{
    public partial class MinimalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Identifier", "Birthdate", "Email", "Firstname", "Lastname", "AdditionalAddress", "City", "Country", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("87befc3e-dca1-4efd-b7d5-b91939beec4c"), new DateTime(1958, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "bdickinson@ironmaiden.com", "Bruce", "Dickinson", "second floor", "Workshop", "Royaume-Uni", "Priorswell Rd", "S80 2BW" },
                    { new Guid("414b34a4-d5d3-4128-98ed-23c64ae900c5"), new DateTime(1963, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.hetfield@metallica.us", "James", "Hetfield", null, "Downey", "États-Unis", "9612 Ardine St", "CA 90241" },
                    { new Guid("22c2d1a1-ac0d-4fe2-a2fc-f4c16381bee4"), new DateTime(1986, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "johanneseckerstrom@avatarband.se", "Johannes", "Eckerström", null, "Göteborg", "Suède", "Kyrkogatan 28", "411 15" },
                    { new Guid("98147104-b970-46b4-86c0-af5c8853c119"), new DateTime(1977, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "tar.turunen@nightwish.fi", "Tarja", "Turunen", null, "Kitee", "Finlande", "Mäsäsläntie 2", "82430" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Identifier",
                keyValue: new Guid("22c2d1a1-ac0d-4fe2-a2fc-f4c16381bee4"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Identifier",
                keyValue: new Guid("414b34a4-d5d3-4128-98ed-23c64ae900c5"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Identifier",
                keyValue: new Guid("87befc3e-dca1-4efd-b7d5-b91939beec4c"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Identifier",
                keyValue: new Guid("98147104-b970-46b4-86c0-af5c8853c119"));
        }
    }
}

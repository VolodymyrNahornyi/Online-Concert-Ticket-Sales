using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class PopulateRockArtists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName", "GenreId" },
                values: new object[,]
                {
                    { new Guid("e53ee28f-fc14-4c08-919b-bdeb0f61f865"), "Guns N' Roses", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("16782e08-7f54-41fa-b3ae-1adc34aa3edd"), "Fleetwood Mac", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("bdf2bba3-a4a9-406f-a4b2-231bd2d3ee5f"), "Creedence Clearwater Revival", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("d604fae1-6a79-463d-956c-09fcfb59a769"), "Journey", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("296f7e3a-203e-4617-9c34-71f12bdb467e"), "Lynyrd Skynyrd", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("9b9e2426-46d0-44a5-9e71-fb73fecad422"), "U2", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("0f3e2eba-8226-4a9c-88e3-ddda16ee5f0d"), "Aerosmith", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("d4c23fa3-292b-4faa-8fc0-21458aebfd17"), "Eagles", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("0f3e2eba-8226-4a9c-88e3-ddda16ee5f0d"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("16782e08-7f54-41fa-b3ae-1adc34aa3edd"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("296f7e3a-203e-4617-9c34-71f12bdb467e"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("9b9e2426-46d0-44a5-9e71-fb73fecad422"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("bdf2bba3-a4a9-406f-a4b2-231bd2d3ee5f"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("d4c23fa3-292b-4faa-8fc0-21458aebfd17"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("d604fae1-6a79-463d-956c-09fcfb59a769"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("e53ee28f-fc14-4c08-919b-bdeb0f61f865"));
        }
    }
}

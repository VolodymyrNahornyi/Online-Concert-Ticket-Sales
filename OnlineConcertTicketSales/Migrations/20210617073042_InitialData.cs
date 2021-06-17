using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 9 },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 1 },
                    { new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903"), 0 },
                    { new Guid("2deefc3e-f1a9-4e70-9ebb-85fb2d3a9bef"), 2 },
                    { new Guid("6d3dbb7d-6297-4839-aaa5-650760356875"), 4 },
                    { new Guid("286d0569-5f6e-44c9-939f-aa0165353694"), 5 },
                    { new Guid("e04ba65d-1c39-4895-9c9a-a5ddee3e014a"), 11 }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName", "GenreId" },
                values: new object[,]
                {
                    { new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("7ecf51f4-d7a1-4446-a394-9685445c548d"), "The Rolling Stones", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Queen", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("772a66e2-1758-429a-bf2a-fa879c0a814b"), "AC/DC", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("fba81401-9ecb-4b88-bc76-f94a8cf2febf"), "Pink Floyd", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("d50c5b99-49f3-49ff-89f3-3e4c6903209e"), "Led Zeppelin", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("6a68cdd0-30c1-4b8c-9d3c-278c56bc7447"), "Luke Combs", new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903") },
                    { new Guid("1cf59f25-ea0f-46e1-9386-76d684e851ba"), "Morgan Wallen", new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903") },
                    { new Guid("bf0d8839-8205-4b38-ba5e-fe485409f423"), "Kane Brown", new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903") },
                    { new Guid("e8af3832-2e4f-489f-b282-94751285f4d4"), "Miles Davis", new Guid("6d3dbb7d-6297-4839-aaa5-650760356875") },
                    { new Guid("c1da350a-166a-490f-8430-d1fab16b24e7"), "Louis Armstrong", new Guid("6d3dbb7d-6297-4839-aaa5-650760356875") },
                    { new Guid("f545753e-b49f-45b9-91ee-de477d559365"), "John Coltrane", new Guid("6d3dbb7d-6297-4839-aaa5-650760356875") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("1cf59f25-ea0f-46e1-9386-76d684e851ba"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("6a68cdd0-30c1-4b8c-9d3c-278c56bc7447"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("772a66e2-1758-429a-bf2a-fa879c0a814b"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("7ecf51f4-d7a1-4446-a394-9685445c548d"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("bf0d8839-8205-4b38-ba5e-fe485409f423"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("c1da350a-166a-490f-8430-d1fab16b24e7"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("d50c5b99-49f3-49ff-89f3-3e4c6903209e"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("e8af3832-2e4f-489f-b282-94751285f4d4"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("f545753e-b49f-45b9-91ee-de477d559365"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: new Guid("fba81401-9ecb-4b88-bc76-f94a8cf2febf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("286d0569-5f6e-44c9-939f-aa0165353694"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("2deefc3e-f1a9-4e70-9ebb-85fb2d3a9bef"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("e04ba65d-1c39-4895-9c9a-a5ddee3e014a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("6d3dbb7d-6297-4839-aaa5-650760356875"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}

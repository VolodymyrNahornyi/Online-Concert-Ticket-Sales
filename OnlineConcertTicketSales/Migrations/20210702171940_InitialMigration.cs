using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(nullable: false),
                    GenreName = table.Column<int>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    ArtistName = table.Column<string>(maxLength: 60, nullable: false),
                    GenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Artists_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    ConcertId = table.Column<Guid>(nullable: false),
                    ConcertName = table.Column<string>(maxLength: 60, nullable: false),
                    ArtistId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.ConcertId);
                    table.ForeignKey(
                        name: "FK_Concerts_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("e8af3832-2e4f-489f-b282-94751285f4d4"), "Miles Davis", new Guid("6d3dbb7d-6297-4839-aaa5-650760356875") },
                    { new Guid("bf0d8839-8205-4b38-ba5e-fe485409f423"), "Kane Brown", new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903") },
                    { new Guid("1cf59f25-ea0f-46e1-9386-76d684e851ba"), "Morgan Wallen", new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903") },
                    { new Guid("6a68cdd0-30c1-4b8c-9d3c-278c56bc7447"), "Luke Combs", new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903") },
                    { new Guid("d4c23fa3-292b-4faa-8fc0-21458aebfd17"), "Eagles", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("0f3e2eba-8226-4a9c-88e3-ddda16ee5f0d"), "Aerosmith", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("9b9e2426-46d0-44a5-9e71-fb73fecad422"), "U2", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("296f7e3a-203e-4617-9c34-71f12bdb467e"), "Lynyrd Skynyrd", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("d604fae1-6a79-463d-956c-09fcfb59a769"), "Journey", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("bdf2bba3-a4a9-406f-a4b2-231bd2d3ee5f"), "Creedence Clearwater Revival", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("16782e08-7f54-41fa-b3ae-1adc34aa3edd"), "Fleetwood Mac", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("e53ee28f-fc14-4c08-919b-bdeb0f61f865"), "Guns N' Roses", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("d50c5b99-49f3-49ff-89f3-3e4c6903209e"), "Led Zeppelin", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("fba81401-9ecb-4b88-bc76-f94a8cf2febf"), "Pink Floyd", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("772a66e2-1758-429a-bf2a-fa879c0a814b"), "AC/DC", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Queen", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("7ecf51f4-d7a1-4446-a394-9685445c548d"), "The Rolling Stones", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("c1da350a-166a-490f-8430-d1fab16b24e7"), "Louis Armstrong", new Guid("6d3dbb7d-6297-4839-aaa5-650760356875") },
                    { new Guid("f545753e-b49f-45b9-91ee-de477d559365"), "John Coltrane", new Guid("6d3dbb7d-6297-4839-aaa5-650760356875") }
                });

            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "ConcertId", "ArtistId", "ConcertName", "Date" },
                values: new object[,]
                {
                    { new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Apple Corps Rooftop", new DateTime(2021, 2, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3075) },
                    { new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Twickenham Studios", new DateTime(2021, 3, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3353) },
                    { new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at EMI Recording Studios", new DateTime(2021, 4, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3365) },
                    { new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Candlestick Park", new DateTime(2021, 6, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3370) },
                    { new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Seattle Center Coliseum", new DateTime(2021, 8, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3374) },
                    { new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Shea Stadium", new DateTime(2021, 9, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3379) },
                    { new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Early shows", new DateTime(2021, 4, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3384) },
                    { new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Queen I", new DateTime(2021, 5, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3389) },
                    { new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Queen II", new DateTime(2021, 6, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3393) },
                    { new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Sheer Heart Attack", new DateTime(2021, 7, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3398) },
                    { new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "A Night At The Opera", new DateTime(2021, 8, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3403) },
                    { new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Day At The Races", new DateTime(2021, 9, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3407) },
                    { new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "News Of The World", new DateTime(2021, 10, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3412) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_GenreId",
                table: "Artists",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ArtistId",
                table: "Concerts",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

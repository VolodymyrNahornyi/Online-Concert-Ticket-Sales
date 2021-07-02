using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class AddConcertDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_GenreId",
                table: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");

            migrationBuilder.InsertData(
                table: "Concert",
                columns: new[] { "ConcertId", "ArtistId", "ConcertName", "Date" },
                values: new object[,]
                {
                    { new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Apple Corps Rooftop", new DateTime(2021, 2, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6156) },
                    { new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Twickenham Studios", new DateTime(2021, 3, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6429) },
                    { new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at EMI Recording Studios", new DateTime(2021, 4, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6441) },
                    { new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Candlestick Park", new DateTime(2021, 6, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6446) },
                    { new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Seattle Center Coliseum", new DateTime(2021, 8, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6451) },
                    { new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"), new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"), "The Beatles at Shea Stadium", new DateTime(2021, 9, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6455) },
                    { new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Early shows", new DateTime(2021, 4, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6459) },
                    { new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Queen I", new DateTime(2021, 5, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6464) },
                    { new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Queen II", new DateTime(2021, 6, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6468) },
                    { new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Sheer Heart Attack", new DateTime(2021, 7, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6473) },
                    { new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "A Night At The Opera", new DateTime(2021, 8, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6477) },
                    { new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "Day At The Races", new DateTime(2021, 9, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6482) },
                    { new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"), new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"), "News Of The World", new DateTime(2021, 10, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6486) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genre_GenreId",
                table: "Artists",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genre_GenreId",
                table: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"));

            migrationBuilder.DeleteData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"));

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genres_GenreId",
                table: "Artists",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

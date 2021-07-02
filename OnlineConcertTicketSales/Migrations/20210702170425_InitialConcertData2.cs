using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class InitialConcertData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genre_GenreId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Artists_ArtistId",
                table: "Concert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "Concerts");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_ArtistId",
                table: "Concerts",
                newName: "IX_Concerts_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts",
                column: "ConcertId");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"),
                column: "Date",
                value: new DateTime(2021, 6, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"),
                column: "Date",
                value: new DateTime(2021, 5, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"),
                column: "Date",
                value: new DateTime(2021, 2, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"),
                column: "Date",
                value: new DateTime(2021, 8, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"),
                column: "Date",
                value: new DateTime(2021, 3, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"),
                column: "Date",
                value: new DateTime(2021, 8, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"),
                column: "Date",
                value: new DateTime(2021, 6, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"),
                column: "Date",
                value: new DateTime(2021, 4, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"),
                column: "Date",
                value: new DateTime(2021, 7, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"),
                column: "Date",
                value: new DateTime(2021, 4, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"),
                column: "Date",
                value: new DateTime(2021, 10, 2, 20, 4, 25, 582, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genres_GenreId",
                table: "Artists",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Artists_ArtistId",
                table: "Concerts",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_GenreId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Artists_ArtistId",
                table: "Concerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Concerts",
                newName: "Concert");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_ArtistId",
                table: "Concert",
                newName: "IX_Concert_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concert",
                table: "Concert",
                column: "ConcertId");

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"),
                column: "Date",
                value: new DateTime(2021, 6, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"),
                column: "Date",
                value: new DateTime(2021, 5, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"),
                column: "Date",
                value: new DateTime(2021, 2, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"),
                column: "Date",
                value: new DateTime(2021, 8, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"),
                column: "Date",
                value: new DateTime(2021, 3, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"),
                column: "Date",
                value: new DateTime(2021, 8, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"),
                column: "Date",
                value: new DateTime(2021, 6, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"),
                column: "Date",
                value: new DateTime(2021, 4, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"),
                column: "Date",
                value: new DateTime(2021, 7, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"),
                column: "Date",
                value: new DateTime(2021, 4, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Concert",
                keyColumn: "ConcertId",
                keyValue: new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"),
                column: "Date",
                value: new DateTime(2021, 10, 2, 19, 55, 10, 375, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genre_GenreId",
                table: "Artists",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Artists_ArtistId",
                table: "Concert",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

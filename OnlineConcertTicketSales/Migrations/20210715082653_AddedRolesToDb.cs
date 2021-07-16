using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9f3a926c-ba95-44ec-849a-7a6bd5262206", "6481e556-4047-45c1-ad8f-468964fb10bf", "Manager", "MANAGER" },
                    { "f5670cd6-ca59-4d01-b5a1-0993acfd8339", "d711e1c1-27dc-4dfc-84e5-114192b615df", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"),
                column: "Date",
                value: new DateTime(2021, 6, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"),
                column: "Date",
                value: new DateTime(2021, 9, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"),
                column: "Date",
                value: new DateTime(2021, 5, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"),
                column: "Date",
                value: new DateTime(2021, 2, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"),
                column: "Date",
                value: new DateTime(2021, 8, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"),
                column: "Date",
                value: new DateTime(2021, 3, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"),
                column: "Date",
                value: new DateTime(2021, 8, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"),
                column: "Date",
                value: new DateTime(2021, 9, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"),
                column: "Date",
                value: new DateTime(2021, 6, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"),
                column: "Date",
                value: new DateTime(2021, 4, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"),
                column: "Date",
                value: new DateTime(2021, 7, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"),
                column: "Date",
                value: new DateTime(2021, 4, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"),
                column: "Date",
                value: new DateTime(2021, 10, 15, 11, 26, 52, 907, DateTimeKind.Local).AddTicks(6469));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f3a926c-ba95-44ec-849a-7a6bd5262206");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5670cd6-ca59-4d01-b5a1-0993acfd8339");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"),
                column: "Date",
                value: new DateTime(2021, 6, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"),
                column: "Date",
                value: new DateTime(2021, 9, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"),
                column: "Date",
                value: new DateTime(2021, 5, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"),
                column: "Date",
                value: new DateTime(2021, 2, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"),
                column: "Date",
                value: new DateTime(2021, 8, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"),
                column: "Date",
                value: new DateTime(2021, 3, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"),
                column: "Date",
                value: new DateTime(2021, 8, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"),
                column: "Date",
                value: new DateTime(2021, 9, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"),
                column: "Date",
                value: new DateTime(2021, 6, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"),
                column: "Date",
                value: new DateTime(2021, 4, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"),
                column: "Date",
                value: new DateTime(2021, 7, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"),
                column: "Date",
                value: new DateTime(2021, 4, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"),
                column: "Date",
                value: new DateTime(2021, 10, 15, 11, 17, 58, 476, DateTimeKind.Local).AddTicks(7041));
        }
    }
}

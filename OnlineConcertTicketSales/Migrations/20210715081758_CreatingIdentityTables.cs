using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineConcertTicketSales.Migrations
{
    public partial class CreatingIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"),
                column: "Date",
                value: new DateTime(2021, 6, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"),
                column: "Date",
                value: new DateTime(2021, 5, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"),
                column: "Date",
                value: new DateTime(2021, 2, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"),
                column: "Date",
                value: new DateTime(2021, 8, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"),
                column: "Date",
                value: new DateTime(2021, 3, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"),
                column: "Date",
                value: new DateTime(2021, 8, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"),
                column: "Date",
                value: new DateTime(2021, 6, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"),
                column: "Date",
                value: new DateTime(2021, 4, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"),
                column: "Date",
                value: new DateTime(2021, 7, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"),
                column: "Date",
                value: new DateTime(2021, 4, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"),
                column: "Date",
                value: new DateTime(2021, 10, 2, 20, 19, 40, 456, DateTimeKind.Local).AddTicks(3412));
        }
    }
}

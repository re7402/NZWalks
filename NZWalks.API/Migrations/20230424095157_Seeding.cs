using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("365ccc81-6e57-49ac-9c2c-150be3684e6d"), "Easy" },
                    { new Guid("9c8a9ee2-f3bd-46b6-b093-7e9d969df9f2"), "Hard" },
                    { new Guid("fcfa58a6-50bb-4658-b00b-4121c18b7630"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("5e470af2-002b-4d1d-ac9e-33d822900e3b"), "CMB", "Columbia", "gh.jpg" },
                    { new Guid("89b62bff-2d24-4196-be06-e38683471781"), "GRG", "Georgia", "grg.jpg" },
                    { new Guid("8ac9c219-6e02-4364-97bf-5fca80fe9ebd"), "AKL", "Auckland", "akl.jpg" },
                    { new Guid("dddf7948-4edf-4cb6-abe6-3ff003034a95"), "ATL", "Atlanta", "atl.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("365ccc81-6e57-49ac-9c2c-150be3684e6d"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9c8a9ee2-f3bd-46b6-b093-7e9d969df9f2"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fcfa58a6-50bb-4658-b00b-4121c18b7630"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("5e470af2-002b-4d1d-ac9e-33d822900e3b"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("89b62bff-2d24-4196-be06-e38683471781"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("8ac9c219-6e02-4364-97bf-5fca80fe9ebd"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("dddf7948-4edf-4cb6-abe6-3ff003034a95"));
        }
    }
}

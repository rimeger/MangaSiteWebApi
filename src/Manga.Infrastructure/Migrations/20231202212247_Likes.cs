using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manga.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Likes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "MangaChapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a2c4e8b-9d1f-4a7b-a0c8-8d9b6f2e3a14"),
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 2, 22, 22, 47, 118, DateTimeKind.Local).AddTicks(9536), "$2a$11$VllnSjP6X6MGqMxfnO2QSu/Rb9xSpDFZ6ZkjMxZ2CH8xOUMqgUuvC", new DateTime(2023, 12, 2, 22, 22, 47, 118, DateTimeKind.Local).AddTicks(9601) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "MangaChapters");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a2c4e8b-9d1f-4a7b-a0c8-8d9b6f2e3a14"),
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 1, 21, 32, 46, 582, DateTimeKind.Local).AddTicks(343), "$2a$11$mawYOygVnqZ.lWJupc0yG.3O8BxOsp188BGb57xbQh7ZYcCL/OBwq", new DateTime(2023, 12, 1, 21, 32, 46, 582, DateTimeKind.Local).AddTicks(405) });
        }
    }
}

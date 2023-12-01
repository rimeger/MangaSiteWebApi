using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manga.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LikeFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChapters",
                columns: table => new
                {
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChapters", x => new { x.ChapterId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserChapters_MangaChapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "MangaChapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChapters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a2c4e8b-9d1f-4a7b-a0c8-8d9b6f2e3a14"),
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 1, 21, 32, 46, 582, DateTimeKind.Local).AddTicks(343), "$2a$11$mawYOygVnqZ.lWJupc0yG.3O8BxOsp188BGb57xbQh7ZYcCL/OBwq", new DateTime(2023, 12, 1, 21, 32, 46, 582, DateTimeKind.Local).AddTicks(405) });

            migrationBuilder.CreateIndex(
                name: "IX_UserChapters_UserId",
                table: "UserChapters",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChapters");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a2c4e8b-9d1f-4a7b-a0c8-8d9b6f2e3a14"),
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 11, 36, 0, 855, DateTimeKind.Local).AddTicks(1575), "!@#$%^&*(admin)1128", new DateTime(2023, 11, 25, 11, 36, 0, 855, DateTimeKind.Local).AddTicks(1631) });
        }
    }
}

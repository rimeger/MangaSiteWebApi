using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manga.Migrations
{
    /// <inheritdoc />
    public partial class fixedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedName",
                table: "MangaTitles",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedName",
                table: "MangaPages",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedName",
                table: "MangaChapters",
                newName: "UpdatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MangaTitles",
                newName: "UpdatedName");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MangaPages",
                newName: "UpdatedName");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MangaChapters",
                newName: "UpdatedName");
        }
    }
}

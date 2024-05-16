using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlySpans.PolyLeads.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_Initial_Permitted_Sources_Entries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PermittedSource",
                table: "PermittedSource");

            migrationBuilder.RenameTable(
                name: "PermittedSource",
                newName: "PermittedSources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermittedSources",
                table: "PermittedSources",
                column: "Id");

            migrationBuilder.InsertData(
                table: "PermittedSources",
                columns: new[] { "Id", "BaseUrl", "Description" },
                values: new object[,]
                {
                    { 1L, "https://www.spbstu.ru/", "Сайт политеха" },
                    { 2L, "https://college.spbstu.ru/", "Институт среднего профессионального образования СПБПУ" },
                    { 3L, "https://enroll.spbstu.ru/", "Приемная комиссия СПБПУ" },
                    { 4L, "https://iccs.spbstu.ru/", "ИКНК СПБПУ" },
                    { 5L, "https://physmech.spbstu.ru/", "ФизМех СПБПУ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PermittedSources",
                table: "PermittedSources");

            migrationBuilder.DeleteData(
                table: "PermittedSources",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PermittedSources",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PermittedSources",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PermittedSources",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PermittedSources",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.RenameTable(
                name: "PermittedSources",
                newName: "PermittedSource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermittedSource",
                table: "PermittedSource",
                column: "Id");
        }
    }
}

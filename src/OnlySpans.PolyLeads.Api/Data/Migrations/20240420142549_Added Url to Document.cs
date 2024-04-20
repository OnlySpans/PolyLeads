using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlySpans.PolyLeads.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUrltoDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Documents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Documents");
        }
    }
}

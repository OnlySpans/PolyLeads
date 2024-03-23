using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlySpans.PolyLeads.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentGroupId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentGroups_DocumentGroups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StorageObjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StorageAlias = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    StorageId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Extension = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    StorageObjectId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileEntries_StorageObjects_StorageObjectId",
                        column: x => x.StorageObjectId,
                        principalTable: "StorageObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileEntryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_FileEntries_FileEntryId",
                        column: x => x.FileEntryId,
                        principalTable: "FileEntries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileRecognitionStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileEntryId = table.Column<long>(type: "bigint", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileRecognitionStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileRecognitionStatuses_FileEntries_FileEntryId",
                        column: x => x.FileEntryId,
                        principalTable: "FileEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecognitionResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileEntryId = table.Column<long>(type: "bigint", nullable: false),
                    AllText = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    RecognizedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecognitionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecognitionResults_FileEntries_FileEntryId",
                        column: x => x.FileEntryId,
                        principalTable: "FileEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentInGroups",
                columns: table => new
                {
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentGroupId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInGroups", x => new { x.DocumentId, x.DocumentGroupId });
                    table.ForeignKey(
                        name: "FK_DocumentInGroups_DocumentGroups_DocumentGroupId",
                        column: x => x.DocumentGroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentInGroups_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentGroups_ParentGroupId",
                table: "DocumentGroups",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInGroups_DocumentGroupId",
                table: "DocumentInGroups",
                column: "DocumentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileEntryId",
                table: "Documents",
                column: "FileEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileEntries_StorageObjectId",
                table: "FileEntries",
                column: "StorageObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileRecognitionStatuses_FileEntryId",
                table: "FileRecognitionStatuses",
                column: "FileEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecognitionResults_FileEntryId",
                table: "RecognitionResults",
                column: "FileEntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentInGroups");

            migrationBuilder.DropTable(
                name: "FileRecognitionStatuses");

            migrationBuilder.DropTable(
                name: "RecognitionResults");

            migrationBuilder.DropTable(
                name: "DocumentGroups");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "FileEntries");

            migrationBuilder.DropTable(
                name: "StorageObjects");
        }
    }
}

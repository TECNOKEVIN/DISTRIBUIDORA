using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Distribuidora.API.Migrations
{
    /// <inheritdoc />
    public partial class TipoLicorwithLicor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLicors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLicors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoLicors_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoLicorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licors_TipoLicors_TipoLicorId",
                        column: x => x.TipoLicorId,
                        principalTable: "TipoLicors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licors_TipoLicorId_Name",
                table: "Licors",
                columns: new[] { "TipoLicorId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_Name",
                table: "Sedes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoLicors_SedeId_Name",
                table: "TipoLicors",
                columns: new[] { "SedeId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licors");

            migrationBuilder.DropTable(
                name: "TipoLicors");

            migrationBuilder.DropTable(
                name: "Sedes");
        }
    }
}

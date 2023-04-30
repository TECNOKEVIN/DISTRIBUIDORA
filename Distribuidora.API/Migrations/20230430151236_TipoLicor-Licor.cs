using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Distribuidora.API.Migrations
{
    /// <inheritdoc />
    public partial class TipoLicorLicor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoLicors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SedeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    TipoLicorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                name: "IX_Licors_Name",
                table: "Licors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licors_TipoLicorId",
                table: "Licors",
                column: "TipoLicorId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoLicors_Name",
                table: "TipoLicors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoLicors_SedeId",
                table: "TipoLicors",
                column: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licors");

            migrationBuilder.DropTable(
                name: "TipoLicors");
        }
    }
}

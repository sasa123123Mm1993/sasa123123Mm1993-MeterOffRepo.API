using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterOff.EF.Migrations
{
    /// <inheritdoc />
    public partial class kmkm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "installCardReading");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "installCardReading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlCardId = table.Column<int>(type: "int", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    ControlCardOperationTypeEnum = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_installCardReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_installCardReading_ControlCard_ControlCardId",
                        column: x => x.ControlCardId,
                        principalTable: "ControlCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_installCardReading_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_installCardReading_ControlCardId",
                table: "installCardReading",
                column: "ControlCardId");

            migrationBuilder.CreateIndex(
                name: "IX_installCardReading_MeterId",
                table: "installCardReading",
                column: "MeterId");
        }
    }
}

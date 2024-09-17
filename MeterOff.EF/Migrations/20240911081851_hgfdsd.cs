using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterOff.EF.Migrations
{
    /// <inheritdoc />
    public partial class hgfdsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterStatusLog_MeterData_MeterDataId",
                table: "MeterStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_MeterStatusLog_MeterDataId",
                table: "MeterStatusLog");

            migrationBuilder.DropColumn(
                name: "MeterDataId",
                table: "MeterStatusLog");

            migrationBuilder.AlterColumn<string>(
                name: "VersionNumber",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "MeterData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReceiptNumber",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MeterOffReason",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ManufactureCompany",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "installCardReading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ControlCardOperationTypeEnum = table.Column<int>(type: "int", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    ControlCardId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "installCardReading");

            migrationBuilder.AddColumn<int>(
                name: "MeterDataId",
                table: "MeterStatusLog",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VersionNumber",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "MeterData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReceiptNumber",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeterOffReason",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManufactureCompany",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "MeterData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterStatusLog_MeterDataId",
                table: "MeterStatusLog",
                column: "MeterDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterStatusLog_MeterData_MeterDataId",
                table: "MeterStatusLog",
                column: "MeterDataId",
                principalTable: "MeterData",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterOff.EF.Migrations
{
    /// <inheritdoc />
    public partial class mmmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumer_Tariff_TariffId",
                table: "Consumer");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumerConsumptionFeesCalc_Tariff_TariffId",
                table: "ConsumerConsumptionFeesCalc");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariff_ActivityType_TariffTypeId",
                table: "Tariff");

            migrationBuilder.DropForeignKey(
                name: "FK_TariffFee_Tariff_TariffId",
                table: "TariffFee");

            migrationBuilder.DropForeignKey(
                name: "FK_TariffStep_Tariff_TariffId",
                table: "TariffStep");

            migrationBuilder.DropForeignKey(
                name: "FK_TariffTamper_Tariff_TariffId",
                table: "TariffTamper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TariffStep",
                table: "TariffStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tariff",
                table: "Tariff");

            migrationBuilder.RenameTable(
                name: "TariffStep",
                newName: "TariffSteps");

            migrationBuilder.RenameTable(
                name: "Tariff",
                newName: "Tariffs");

            migrationBuilder.RenameIndex(
                name: "IX_TariffStep_TariffId",
                table: "TariffSteps",
                newName: "IX_TariffSteps_TariffId");

            migrationBuilder.RenameIndex(
                name: "IX_Tariff_TariffTypeId",
                table: "Tariffs",
                newName: "IX_Tariffs_TariffTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CUploadMainteneceMetersOffReason",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TariffSteps",
                table: "TariffSteps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tariffs",
                table: "Tariffs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumer_Tariffs_TariffId",
                table: "Consumer",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumerConsumptionFeesCalc_Tariffs_TariffId",
                table: "ConsumerConsumptionFeesCalc",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TariffFee_Tariffs_TariffId",
                table: "TariffFee",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_ActivityType_TariffTypeId",
                table: "Tariffs",
                column: "TariffTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TariffSteps_Tariffs_TariffId",
                table: "TariffSteps",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TariffTamper_Tariffs_TariffId",
                table: "TariffTamper",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumer_Tariffs_TariffId",
                table: "Consumer");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumerConsumptionFeesCalc_Tariffs_TariffId",
                table: "ConsumerConsumptionFeesCalc");

            migrationBuilder.DropForeignKey(
                name: "FK_TariffFee_Tariffs_TariffId",
                table: "TariffFee");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_ActivityType_TariffTypeId",
                table: "Tariffs");

            migrationBuilder.DropForeignKey(
                name: "FK_TariffSteps_Tariffs_TariffId",
                table: "TariffSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_TariffTamper_Tariffs_TariffId",
                table: "TariffTamper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TariffSteps",
                table: "TariffSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tariffs",
                table: "Tariffs");

            migrationBuilder.RenameTable(
                name: "TariffSteps",
                newName: "TariffStep");

            migrationBuilder.RenameTable(
                name: "Tariffs",
                newName: "Tariff");

            migrationBuilder.RenameIndex(
                name: "IX_TariffSteps_TariffId",
                table: "TariffStep",
                newName: "IX_TariffStep_TariffId");

            migrationBuilder.RenameIndex(
                name: "IX_Tariffs_TariffTypeId",
                table: "Tariff",
                newName: "IX_Tariff_TariffTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CUploadMainteneceMetersOffReason",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TariffStep",
                table: "TariffStep",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tariff",
                table: "Tariff",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumer_Tariff_TariffId",
                table: "Consumer",
                column: "TariffId",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumerConsumptionFeesCalc_Tariff_TariffId",
                table: "ConsumerConsumptionFeesCalc",
                column: "TariffId",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariff_ActivityType_TariffTypeId",
                table: "Tariff",
                column: "TariffTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TariffFee_Tariff_TariffId",
                table: "TariffFee",
                column: "TariffId",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TariffStep_Tariff_TariffId",
                table: "TariffStep",
                column: "TariffId",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TariffTamper_Tariff_TariffId",
                table: "TariffTamper",
                column: "TariffId",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

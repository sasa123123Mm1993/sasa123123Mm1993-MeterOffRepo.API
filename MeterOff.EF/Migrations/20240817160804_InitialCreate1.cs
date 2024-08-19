using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterOff.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TariffTypeCode = table.Column<int>(type: "int", nullable: false),
                    ISsmall = table.Column<bool>(type: "bit", nullable: false),
                    ISBig = table.Column<bool>(type: "bit", nullable: false),
                    StutsBigSmall = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auditing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecordId = table.Column<long>(type: "bigint", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicConsumer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeNo = table.Column<int>(type: "int", nullable: false),
                    BranchNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    DailyNo = table.Column<int>(type: "int", nullable: false),
                    RegionNo = table.Column<int>(type: "int", nullable: false),
                    DepartmentNo = table.Column<int>(type: "int", nullable: false),
                    MeterUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CardUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SmallDepartmentNo = table.Column<int>(type: "int", nullable: true),
                    MeasurementNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContractingNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InitialBalanceReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    East = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EndAccountReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FirstReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstRechargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Western = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    North = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    South = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RefferenceAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectionNo = table.Column<int>(type: "int", nullable: false),
                    ContractingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountMeterStatusEnum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeterInstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterPreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndAccountDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastRechargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RecivedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SavedUserId = table.Column<int>(type: "int", nullable: true),
                    PerpearedUserId = table.Column<int>(type: "int", nullable: true),
                    PrintWorkOrderUserId = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Long = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTariffTypeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CleaningFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    TransformerMeterId = table.Column<int>(type: "int", nullable: true),
                    TariffId = table.Column<int>(type: "int", nullable: true),
                    TariffTypeId = table.Column<int>(type: "int", nullable: false),
                    OldTariffId = table.Column<int>(type: "int", nullable: true),
                    OldMeterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldAccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountMaxLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractTotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterInstalled = table.Column<bool>(type: "bit", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: true),
                    Issmallcustomer = table.Column<bool>(type: "bit", nullable: false),
                    IsPrepared = table.Column<bool>(type: "bit", nullable: false),
                    IsCardRead = table.Column<bool>(type: "bit", nullable: false),
                    IsCardCharged = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoveInatialBalance = table.Column<bool>(type: "bit", nullable: false),
                    PurposeOfUseId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AccountMeterReplacementTypeId = table.Column<int>(type: "int", nullable: true),
                    BlockNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPrintedMeterExchangeOrder = table.Column<bool>(type: "bit", nullable: false),
                    BlockReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GenerationCardType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    InitialCardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsEndAccountMustPayDebit = table.Column<bool>(type: "bit", nullable: false),
                    AccountUploadId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicConsumer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    AccountCode = table.Column<long>(type: "bigint", nullable: false),
                    MFPCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardFunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyHierarchical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    OrganizationLevelId = table.Column<int>(type: "int", nullable: false),
                    RegionCode = table.Column<int>(type: "int", nullable: true),
                    CodeAutoGenerated = table.Column<int>(type: "int", nullable: false),
                    SouthCairoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountReferenceCounter = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHierarchical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PassPort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AccountUploadId = table.Column<int>(type: "int", nullable: true),
                    BasicDataForFaxtionId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerTypeEnum = table.Column<int>(type: "int", nullable: false),
                    CustomerTransformTypeEnum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CUploadMainteneceMetersOffReason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUploadMainteneceMetersOffReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DbSerial = table.Column<int>(type: "int", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogoPrint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNameFr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsClear = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditChargeLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainOrderId = table.Column<int>(type: "int", nullable: false),
                    SubOrderId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditChargeLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EPayPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EPayPermissionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnterpriseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EPaymentTypeEnum = table.Column<int>(type: "int", nullable: false),
                    ChequeNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MFPCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPayPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterStatusType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterStatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    MeterTypeClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MeterTypeModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufacturerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MeterPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeterTypeMaxLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerInVolt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerInAmpere = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenConsumerCardLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenConsumerCardLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PagesName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAllowToAllDepartment = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardOwnerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReplaceConsumerLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeNo = table.Column<int>(type: "int", nullable: false),
                    BranchNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    DailyNo = table.Column<int>(type: "int", nullable: false),
                    RegionNo = table.Column<int>(type: "int", nullable: false),
                    DepartmentNo = table.Column<int>(type: "int", nullable: false),
                    MeterUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CardUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SmallDepartmentNo = table.Column<int>(type: "int", nullable: true),
                    MeasurementNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContractingNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InitialBalanceReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    East = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Western = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    North = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    South = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RefferenceAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectionNo = table.Column<int>(type: "int", nullable: false),
                    ContractingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountMeterStatusEnum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeterInstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RecivedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SavedUserId = table.Column<int>(type: "int", nullable: true),
                    PerpearedUserId = table.Column<int>(type: "int", nullable: true),
                    PrintWorkOrderUserId = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Long = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTariffTypeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CleaningFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    TransformerMeterId = table.Column<int>(type: "int", nullable: true),
                    TariffId = table.Column<int>(type: "int", nullable: true),
                    TariffTypeId = table.Column<int>(type: "int", nullable: false),
                    OldTariffId = table.Column<int>(type: "int", nullable: true),
                    OldMeterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldAccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountMaxLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractTotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterInstalled = table.Column<bool>(type: "bit", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: true),
                    Issmallcustomer = table.Column<bool>(type: "bit", nullable: false),
                    IsPrepared = table.Column<bool>(type: "bit", nullable: false),
                    IsCardRead = table.Column<bool>(type: "bit", nullable: false),
                    IsCardCharged = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoveInatialBalance = table.Column<bool>(type: "bit", nullable: false),
                    PurposeOfUseId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AccountMeterReplacementTypeId = table.Column<int>(type: "int", nullable: true),
                    BlockNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPrintedMeterExchangeOrder = table.Column<bool>(type: "bit", nullable: false),
                    BlockReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GenerationCardType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    InitialCardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountUploadId = table.Column<int>(type: "int", nullable: true),
                    ExchangeMeterOperationLogId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplaceConsumerLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetriveInitialBalanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    InitialBalanceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RemovedBy = table.Column<int>(type: "int", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetriveInitialBalanceLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionCode = table.Column<int>(type: "int", nullable: true),
                    CodeAutoGenerated = table.Column<int>(type: "int", nullable: false),
                    SouthCairoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountReferenceCounter = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettlementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DebitTypeEnum = table.Column<int>(type: "int", nullable: false),
                    BenefitPercentage = table.Column<int>(type: "int", nullable: false),
                    MaxMonths = table.Column<int>(type: "int", nullable: false),
                    IsMustMaxMonths = table.Column<bool>(type: "bit", nullable: false),
                    DiminishingInterestValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCheckInstallmentRules = table.Column<bool>(type: "bit", nullable: false),
                    ReplaceMeterCode = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubstitutionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstitutionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tamper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsMustPay = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailableInCharge = table.Column<bool>(type: "bit", nullable: false),
                    IsStopRecharge = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transformer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadConsumerData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatorById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassPort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeNo = table.Column<int>(type: "int", nullable: true),
                    BranchNo = table.Column<int>(type: "int", nullable: true),
                    AccountNo = table.Column<int>(type: "int", nullable: true),
                    DailyNo = table.Column<int>(type: "int", nullable: true),
                    RegionNo = table.Column<int>(type: "int", nullable: true),
                    DepartmentNo = table.Column<int>(type: "int", nullable: true),
                    SectionNo = table.Column<int>(type: "int", nullable: true),
                    SmallDepartmentNo = table.Column<int>(type: "int", nullable: true),
                    MeasurementNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialBalanceReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    East = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Western = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    North = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    South = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefferenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    TariffTypeCode = table.Column<int>(type: "int", nullable: true),
                    TariffTypeId = table.Column<int>(type: "int", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Long = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransformerMeterCode = table.Column<int>(type: "int", nullable: true),
                    TransformerMeterId = table.Column<int>(type: "int", nullable: true),
                    CustomerTypeCode = table.Column<int>(type: "int", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    Issmallcustomer = table.Column<int>(type: "int", nullable: true),
                    BuildingTypeCode = table.Column<int>(type: "int", nullable: true),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: true),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccountMaxLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BlockNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountMeterReplacementTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountMeterReplacementTypeCode = table.Column<int>(type: "int", nullable: true),
                    PurposeOfUseId = table.Column<int>(type: "int", nullable: true),
                    UsageSectorId = table.Column<int>(type: "int", nullable: true),
                    PurposeOfUseCode = table.Column<int>(type: "int", nullable: true),
                    UsageSectorCode = table.Column<int>(type: "int", nullable: true),
                    RefuseReasonId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountMeterStatusEnum = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    SavedUserId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    IsCanSave = table.Column<bool>(type: "bit", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true),
                    CleaningFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsMeterInstalled = table.Column<bool>(type: "bit", nullable: true),
                    IsPrepared = table.Column<bool>(type: "bit", nullable: true),
                    IsCardRead = table.Column<bool>(type: "bit", nullable: true),
                    IsCardCharged = table.Column<bool>(type: "bit", nullable: true),
                    IsRemoveInatialBalance = table.Column<bool>(type: "bit", nullable: true),
                    IsPrintedMeterExchangeOrder = table.Column<bool>(type: "bit", nullable: true),
                    ContractTotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalUpload = table.Column<int>(type: "int", nullable: true),
                    UploadFileCode = table.Column<int>(type: "int", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadConsumerData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadConsumerLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUploadCounter = table.Column<int>(type: "int", nullable: false),
                    NumberOfRefusedBeforeUpload = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadConsumerLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPointOfSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointOfSaleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPointOfSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeesType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TariffTypeId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    IsMeterDeduction = table.Column<bool>(type: "bit", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: true),
                    ForEveryKw = table.Column<int>(type: "int", nullable: true),
                    LimitFor = table.Column<double>(type: "float", nullable: true),
                    InSpecificKw = table.Column<double>(type: "float", nullable: true),
                    FromKw = table.Column<double>(type: "float", nullable: true),
                    ToKw = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeesType_ActivityType_TariffTypeId",
                        column: x => x.TariffTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TariffTypeId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceType_ActivityType_TariffTypeId",
                        column: x => x.TariffTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tariff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TariffTypeId = table.Column<int>(type: "int", nullable: false),
                    ZeroReading = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerServiceMethod = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationStructureId = table.Column<int>(type: "int", nullable: true),
                    TariffCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tariff_ActivityType_TariffTypeId",
                        column: x => x.TariffTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PointOfSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    LevelEnum = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMobileUnit = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfSale_CompanyHierarchical_departmentId",
                        column: x => x.departmentId,
                        principalTable: "CompanyHierarchical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeterTypeId = table.Column<int>(type: "int", nullable: false),
                    OrderSequence = table.Column<int>(type: "int", nullable: false),
                    VersionNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufactureCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentReceiptNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MeterOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterOffReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CysheildCardUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterData_MeterType_MeterTypeId",
                        column: x => x.MeterTypeId,
                        principalTable: "MeterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MiddleFeesType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeterTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleFeesType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiddleFeesType_MeterType_MeterTypeId",
                        column: x => x.MeterTypeId,
                        principalTable: "MeterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MainDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionCode = table.Column<int>(type: "int", nullable: true),
                    CodeAutoGenerated = table.Column<int>(type: "int", nullable: false),
                    SouthCairoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountReferenceCounter = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainDepartment_Section_sectionId",
                        column: x => x.sectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterSettingForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterTypeId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationTemplateId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterSettingForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterSettingForm_MeterType_MeterTypeId",
                        column: x => x.MeterTypeId,
                        principalTable: "MeterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeterSettingForm_SettingForm_ConfigurationTemplateId",
                        column: x => x.ConfigurationTemplateId,
                        principalTable: "SettingForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SettingFormsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterTemplateId = table.Column<int>(type: "int", nullable: false),
                    IsReadBalanceInChangeMeter = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterDisablewhenchanging = table.Column<bool>(type: "bit", nullable: false),
                    FriendlyStartHour = table.Column<int>(type: "int", nullable: false),
                    FriendlyEndHour = table.Column<int>(type: "int", nullable: false),
                    QuiteStartHour = table.Column<int>(type: "int", nullable: false),
                    QuiteEndHour = table.Column<int>(type: "int", nullable: false),
                    MaxLoad = table.Column<double>(type: "float", nullable: false),
                    MaxNumberOfCutoffs = table.Column<int>(type: "int", nullable: false),
                    BillingDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstCutoffAlarmLimitBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondCutoffAlarmLimitBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeterTimeStapToSet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HHFwVersion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HHFwName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CMSIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCanRemoveInitialBalance = table.Column<bool>(type: "bit", nullable: false),
                    IsCysheildCard = table.Column<bool>(type: "bit", nullable: false),
                    IsCmsUpdated = table.Column<bool>(type: "bit", nullable: false),
                    IsEFUseCysheildCard = table.Column<bool>(type: "bit", nullable: false),
                    IsConsumptionTamperBlock = table.Column<bool>(type: "bit", nullable: false),
                    IsDailyPrecedesReferenceAddress = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterDateInFuture = table.Column<bool>(type: "bit", nullable: false),
                    MaxMonthDeferDate = table.Column<int>(type: "int", nullable: false),
                    IsDebitDueDateNextDate = table.Column<bool>(type: "bit", nullable: false),
                    IsSetDateTimeWithOpenAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsDeductFeesexceptionWithZeroConsumption = table.Column<bool>(type: "bit", nullable: false),
                    IsUpdateInitalBalanceWithOpenAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsTariffDifferanceDeductAtNextMonth = table.Column<bool>(type: "bit", nullable: false),
                    IsActivityTypeCodeAddedToConsumerRefference = table.Column<bool>(type: "bit", nullable: false),
                    IsCommercialSectorCodeAddedToConsumerRefference = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GarceType = table.Column<int>(type: "int", nullable: false),
                    GraceValue = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StopChargePeriodInDays = table.Column<int>(type: "int", nullable: false),
                    UcsToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    DirectToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    InDirectToken = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    DirectPw = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IndirectPw = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServicePw = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenericSpecificationType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MeterSerialFrom = table.Column<int>(type: "int", nullable: false),
                    MeterSerialTo = table.Column<int>(type: "int", nullable: false),
                    DebtAmountLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    hoardMoneyLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallingMode = table.Column<int>(type: "int", nullable: false),
                    CancelOrPullChargePeriodInDays = table.Column<int>(type: "int", nullable: false),
                    MaxDaysforpaydebts = table.Column<int>(type: "int", nullable: false),
                    ProfileUid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndirectUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuringRescheduling = table.Column<int>(type: "int", nullable: false),
                    IsDelayDebitCharge = table.Column<bool>(type: "bit", nullable: false),
                    NoOfMaxInvalidLogin = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingFormsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingFormsData_SettingForm_MeterTemplateId",
                        column: x => x.MeterTemplateId,
                        principalTable: "SettingForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerProperity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    TariffTypeId = table.Column<int>(type: "int", nullable: true),
                    MeterReplacementTypeId = table.Column<int>(type: "int", nullable: true),
                    DebitTypeId = table.Column<int>(type: "int", nullable: true),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoOfInstallment = table.Column<int>(type: "int", nullable: false),
                    initalBalance = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerProperity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerProperity_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerProperity_ConsumerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "ConsumerType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConsumerProperity_SettlementType_DebitTypeId",
                        column: x => x.DebitTypeId,
                        principalTable: "SettlementType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConsumerProperity_SubstitutionType_MeterReplacementTypeId",
                        column: x => x.MeterReplacementTypeId,
                        principalTable: "SubstitutionType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransformerReading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    TransformerId = table.Column<int>(type: "int", nullable: false),
                    ReadingValue = table.Column<double>(type: "float", nullable: false),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransformerReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransformerReading_Transformer_TransformerId",
                        column: x => x.TransformerId,
                        principalTable: "Transformer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FeeException",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    LevelEnum = table.Column<int>(type: "int", nullable: false),
                    ExceptionAmount = table.Column<double>(type: "float", nullable: false),
                    IsNoFees = table.Column<bool>(type: "bit", nullable: false),
                    SectionNo = table.Column<int>(type: "int", nullable: true),
                    DepartmentNo = table.Column<int>(type: "int", nullable: true),
                    RegionNo = table.Column<int>(type: "int", nullable: true),
                    DailyNo = table.Column<int>(type: "int", nullable: true),
                    AccountNo = table.Column<int>(type: "int", nullable: true),
                    BranchNo = table.Column<int>(type: "int", nullable: true),
                    TariffTypeId = table.Column<int>(type: "int", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeException", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeException_FeesType_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StepsFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepsFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepsFee_FeesType_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TariffFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffFee_FeesType_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TariffFee_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TariffStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRecalculated = table.Column<bool>(type: "bit", nullable: false),
                    SangenRecalculatedEdge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SangenRecalculatedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InitialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InitialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsSystemcalculation = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffStep_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TariffTamper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    TamperId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffTamper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffTamper_Tamper_TamperId",
                        column: x => x.TamperId,
                        principalTable: "Tamper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TariffTamper_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyHierarchicalId = table.Column<int>(type: "int", nullable: true),
                    CompanyPosId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CompanyHierarchical_CompanyHierarchicalId",
                        column: x => x.CompanyHierarchicalId,
                        principalTable: "CompanyHierarchical",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_PointOfSale_CompanyPosId",
                        column: x => x.CompanyPosId,
                        principalTable: "PointOfSale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeterStatusLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    MeterStatusId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    MeterDataId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterStatusLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterStatusLog_MeterData_MeterDataId",
                        column: x => x.MeterDataId,
                        principalTable: "MeterData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeterStatusLog_MeterStatusType_MeterStatusId",
                        column: x => x.MeterStatusId,
                        principalTable: "MeterStatusType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SmallDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainDepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    CodeAutoGenerated = table.Column<int>(type: "int", nullable: false),
                    SouthCairoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountReferenceCounter = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionCode = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmallDepartment_MainDepartment_MainDepartmentId",
                        column: x => x.MainDepartmentId,
                        principalTable: "MainDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SmallDepartment_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    IsDepartmentUpdate = table.Column<bool>(type: "bit", nullable: false),
                    LevelEnum = table.Column<int>(type: "int", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCompanyCardPrivilidge = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployeeNew = table.Column<bool>(type: "bit", nullable: false),
                    TechnicianTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyHierarchicalId = table.Column<int>(type: "int", nullable: true),
                    MainDepartmentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technician_CompanyHierarchical_CompanyHierarchicalId",
                        column: x => x.CompanyHierarchicalId,
                        principalTable: "CompanyHierarchical",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Technician_MainDepartment_MainDepartmentId",
                        column: x => x.MainDepartmentId,
                        principalTable: "MainDepartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Technician_TechnicianType_TechnicianTypeId",
                        column: x => x.TechnicianTypeId,
                        principalTable: "TechnicianType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPropertySettlement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfInstallment = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerPropertyId = table.Column<int>(type: "int", nullable: false),
                    SettlementTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPropertySettlement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPropertySettlement_ConsumerProperity_CustomerPropertyId",
                        column: x => x.CustomerPropertyId,
                        principalTable: "ConsumerProperity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerPropertySettlement_SettlementType_SettlementTypeId",
                        column: x => x.SettlementTypeId,
                        principalTable: "SettlementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserSection",
                columns: table => new
                {
                    SectionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSection", x => new { x.SectionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSection_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSection_Section_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserSmallDepartment",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallDepartmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSmallDepartment", x => new { x.ApplicationUsersId, x.SmallDepartmentsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSmallDepartment_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSmallDepartment_SmallDepartment_SmallDepartmentsId",
                        column: x => x.SmallDepartmentsId,
                        principalTable: "SmallDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CMaintenenceMetersOff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCode = table.Column<int>(type: "int", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PlaceTypeId = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    MainDepartmentId = table.Column<int>(type: "int", nullable: false),
                    SmallDepartmentId = table.Column<int>(type: "int", nullable: false),
                    BranchNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    DailyNo = table.Column<int>(type: "int", nullable: false),
                    RegionNo = table.Column<int>(type: "int", nullable: false),
                    MeterPreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterInstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDateToLaboratory = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsMeterRecieved = table.Column<bool>(type: "bit", nullable: true),
                    CUploadMainteneceMetersOffReasonId = table.Column<int>(type: "int", nullable: false),
                    MeterOffStatusId = table.Column<int>(type: "int", nullable: false),
                    MeterOffReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeterOffMaintainNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExaminationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDateToTechnician = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterTypeId = table.Column<int>(type: "int", nullable: true),
                    IsExaminationdata = table.Column<bool>(type: "bit", nullable: true),
                    IsEnded = table.Column<bool>(type: "bit", nullable: true),
                    IsMeterInstalled = table.Column<bool>(type: "bit", nullable: true),
                    MainDepartmentCode = table.Column<int>(type: "int", nullable: false),
                    SmallDepartmentCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMaintenenceMetersOff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_CUploadMainteneceMetersOffReason_CUploadMainteneceMetersOffReasonId",
                        column: x => x.CUploadMainteneceMetersOffReasonId,
                        principalTable: "CUploadMainteneceMetersOffReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_MainDepartment_MainDepartmentId",
                        column: x => x.MainDepartmentId,
                        principalTable: "MainDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_MeterType_MeterTypeId",
                        column: x => x.MeterTypeId,
                        principalTable: "MeterType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_PlaceType_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CMaintenenceMetersOff_SmallDepartment_SmallDepartmentId",
                        column: x => x.SmallDepartmentId,
                        principalTable: "SmallDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SmallDepartment_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmallDepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallDepartment_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmallDepartment_Users_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SmallDepartment_Users_SmallDepartment_SmallDepartmentId",
                        column: x => x.SmallDepartmentId,
                        principalTable: "SmallDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeNo = table.Column<int>(type: "int", nullable: false),
                    BranchNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    DailyNo = table.Column<int>(type: "int", nullable: false),
                    RegionNo = table.Column<int>(type: "int", nullable: false),
                    DepartmentNo = table.Column<int>(type: "int", nullable: false),
                    MeterUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CardUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SmallDepartmentNo = table.Column<int>(type: "int", nullable: true),
                    MeasurementNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContractingNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InitialBalanceReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    East = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EndAccountReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EndAccountUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstRechargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Western = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    North = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    South = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RefferenceAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectionNo = table.Column<int>(type: "int", nullable: false),
                    ContractingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountMeterStatusEnum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeterInstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterPreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndAccountDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastRechargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RecivedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SavedUserId = table.Column<int>(type: "int", nullable: true),
                    PerpearedUserId = table.Column<int>(type: "int", nullable: true),
                    PrintWorkOrderUserId = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Long = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTariffTypeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CleaningFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    TransformerMeterId = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    TariffTypeId = table.Column<int>(type: "int", nullable: false),
                    OldTariffId = table.Column<int>(type: "int", nullable: true),
                    OldMeterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldAccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountMaxLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractTotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterInstalled = table.Column<bool>(type: "bit", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: false),
                    Issmallcustomer = table.Column<bool>(type: "bit", nullable: false),
                    IsPrepared = table.Column<bool>(type: "bit", nullable: false),
                    IsCardRead = table.Column<bool>(type: "bit", nullable: false),
                    IsCardCharged = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoveInatialBalance = table.Column<bool>(type: "bit", nullable: false),
                    PurposeOfUseId = table.Column<int>(type: "int", nullable: true),
                    UsageSectorCode = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AccountMeterReplacementTypeId = table.Column<int>(type: "int", nullable: false),
                    BlockNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPrintedMeterExchangeOrder = table.Column<bool>(type: "bit", nullable: false),
                    BlockReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BlockUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenerationCardType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    InitialCardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsEndAccountMustPayDebit = table.Column<bool>(type: "bit", nullable: false),
                    AccountUploadId = table.Column<int>(type: "int", nullable: true),
                    IsMeterReplaced = table.Column<bool>(type: "bit", nullable: false),
                    IsOpenCardPending = table.Column<bool>(type: "bit", nullable: false),
                    UnitACA_Key = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BuildingNationalID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RefAdd = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumer_ConsumerInfo_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "ConsumerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_ConsumerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "ConsumerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_PlaceType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_SubstitutionType_AccountMeterReplacementTypeId",
                        column: x => x.AccountMeterReplacementTypeId,
                        principalTable: "SubstitutionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_Technician_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Technician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consumer_Transformer_TransformerMeterId",
                        column: x => x.TransformerMeterId,
                        principalTable: "Transformer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ControlCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Limitation = table.Column<int>(type: "int", nullable: false),
                    MeterSerial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CysheildCardUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    NoOfCollectedMeters = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlCard_Technician_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Technician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SectionTechnician",
                columns: table => new
                {
                    SectionsId = table.Column<int>(type: "int", nullable: false),
                    TechniciansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTechnician", x => new { x.SectionsId, x.TechniciansId });
                    table.ForeignKey(
                        name: "FK_SectionTechnician_Section_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SectionTechnician_Technician_TechniciansId",
                        column: x => x.TechniciansId,
                        principalTable: "Technician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SmallDepartmentTechnician",
                columns: table => new
                {
                    SmallDepartmentsId = table.Column<int>(type: "int", nullable: false),
                    TechniciansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallDepartmentTechnician", x => new { x.SmallDepartmentsId, x.TechniciansId });
                    table.ForeignKey(
                        name: "FK_SmallDepartmentTechnician_SmallDepartment_SmallDepartmentsId",
                        column: x => x.SmallDepartmentsId,
                        principalTable: "SmallDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SmallDepartmentTechnician_Technician_TechniciansId",
                        column: x => x.TechniciansId,
                        principalTable: "Technician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AccountStatusLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AccountStatusEnum = table.Column<int>(type: "int", nullable: false),
                    AccountSuspendReasonEnum = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatusLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountStatusLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChargeLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DebitAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeesAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTamperFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderSequence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCreationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderModificationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCreatorById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargeLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerFee_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerFee_FeesType_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerSettlement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DebitTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmountWithInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "int", nullable: false),
                    InstallmentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NextInstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSystemAddedAutomically = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeMeterOperationLogId = table.Column<int>(type: "int", nullable: true),
                    RemainingNumberOfInstallment = table.Column<int>(type: "int", nullable: false),
                    TotalAllPaidValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PosChargeId = table.Column<int>(type: "int", nullable: true),
                    CustomerPropertySettlementId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerSettlement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerSettlement_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerSettlement_SettlementType_DebitTypeId",
                        column: x => x.DebitTypeId,
                        principalTable: "SettlementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerTamper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TamperId = table.Column<int>(type: "int", nullable: false),
                    RemoveBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDateFromMeter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTamperToRemove = table.Column<bool>(type: "bit", nullable: false),
                    IsTamperToPay = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterEvent = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CollectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCollectCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerTamper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerTamper_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerTamper_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerTamper_Tamper_TamperId",
                        column: x => x.TamperId,
                        principalTable: "Tamper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerTariffDifference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CurrentAccountTariffId = table.Column<int>(type: "int", nullable: false),
                    Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AmountWithCurrentAccountTariff = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    TariffDifferenceAmount = table.Column<double>(type: "float", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerTariffDifference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerTariffDifference_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CurrentReading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentConsumption = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TotalPowerConsumption = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MeterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemainingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingPower = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeterStatusCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BattaryStatusCode = table.Column<int>(type: "int", nullable: true),
                    TotalRechargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SystemTotalRecharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentMonthCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDebtAmount = table.Column<double>(type: "float", nullable: false),
                    TotalDebtInKW = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDemandInKW = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDemandInKWTimestamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDemandInInAmpere = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDemandInInAmpereTimestamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PowerFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderSequence = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: true),
                    NoOfCollectedMeters = table.Column<int>(type: "int", nullable: false),
                    MeterStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CollectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCollectCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentReading_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CurrentReading_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdvancePaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FeesFirstTimeOnly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesFirstTimeOnly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeesFirstTimeOnly_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FeesFirstTimeOnly_FeesType_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterMaintenanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    MeterOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterOffReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ResetMeterBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsMeterInstalled = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterReset = table.Column<bool>(type: "bit", nullable: false),
                    IsMeterTransferToStock = table.Column<bool>(type: "bit", nullable: false),
                    UploadMeterStatusEnum = table.Column<int>(type: "int", nullable: false),
                    UploadReasonEnum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RecivedEmployeeTechnId = table.Column<int>(type: "int", nullable: true),
                    OldConsumerStatus = table.Column<int>(type: "int", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterMaintenanceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterMaintenanceLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeterMaintenanceLog_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterReplaceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    OldMeterId = table.Column<int>(type: "int", nullable: false),
                    NewMeterId = table.Column<int>(type: "int", nullable: false),
                    OldReceiptNumber = table.Column<int>(type: "int", nullable: false),
                    OrderSequence = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReplaceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReplaceLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeterReplaceLog_MeterData_NewMeterId",
                        column: x => x.NewMeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeterReplaceLog_MeterData_OldMeterId",
                        column: x => x.OldMeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterToAnotherConsumer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewAccountId = table.Column<int>(type: "int", nullable: false),
                    OldAccountId = table.Column<int>(type: "int", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    ConsumerId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterToAnotherConsumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterToAnotherConsumer_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeterToAnotherConsumer_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MiddleFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractFeeTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiddleFee_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MiddleFee_MiddleFeesType_ContractFeeTypeId",
                        column: x => x.ContractFeeTypeId,
                        principalTable: "MiddleFeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReplaceCardLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    NewCardNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OldCardNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GenerationCardType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CardPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SetDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TampersToRemove = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReplaceWithRecharge = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplaceCardLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplaceCardLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReplaceConsumerOperationLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: false),
                    AccountOperationLogEnum = table.Column<int>(type: "int", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplaceConsumerOperationLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplaceConsumerOperationLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplaceConsumerOperationLog_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Settlement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DebitTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsHasDiminishingInterest = table.Column<bool>(type: "bit", nullable: false),
                    DiminishingInterestValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiminishingInterestNet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlement_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Settlement_SettlementType_DebitTypeId",
                        column: x => x.DebitTypeId,
                        principalTable: "SettlementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermissionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermissionLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPermissionLog_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkPermissionLog_MeterData_MeterId",
                        column: x => x.MeterId,
                        principalTable: "MeterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ControlCardManagment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ControlCarId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCardManagment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlCardManagment_CardFunction_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "CardFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ControlCardManagment_ControlCard_ControlCarId",
                        column: x => x.ControlCarId,
                        principalTable: "ControlCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerSettlement_Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ConsumerSettlement_Id = table.Column<int>(type: "int", nullable: false),
                    NextInstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallmentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentWay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "int", nullable: false),
                    CurrentReservedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayCashORDeposit = table.Column<int>(type: "int", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfInstallmentsAfter = table.Column<int>(type: "int", nullable: false),
                    InstallmentValueAfter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSystemAddedAutomically = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptNo = table.Column<int>(type: "int", nullable: true),
                    PosCode = table.Column<int>(type: "int", nullable: false),
                    AccountDepartmentCode = table.Column<int>(type: "int", nullable: false),
                    AdvancePaymentTypeEnum = table.Column<int>(type: "int", nullable: false),
                    Charges_Id = table.Column<int>(type: "int", nullable: true),
                    NumberOfInstallmentsPaid = table.Column<int>(type: "int", nullable: false),
                    VisaReceiptNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerSettlement_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerSettlement_Log_ConsumerSettlement_ConsumerSettlement_Id",
                        column: x => x.ConsumerSettlement_Id,
                        principalTable: "ConsumerSettlement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerConsumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Month = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TotalPowerConsumption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstantaneousReadingId = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerServiceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FifthStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FifthStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SixthStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SixthStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeventhStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeventhStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalFee = table.Column<double>(type: "float", nullable: false),
                    BroadCastMonthlyFee = table.Column<double>(type: "float", nullable: false),
                    ConsumptionStamp = table.Column<double>(type: "float", nullable: false),
                    QualityStamp = table.Column<double>(type: "float", nullable: false),
                    BroadCastBigCustomer = table.Column<double>(type: "float", nullable: false),
                    BroadCastInSpecificKw = table.Column<double>(type: "float", nullable: false),
                    BroadCastFromKwToKW = table.Column<double>(type: "float", nullable: false),
                    MaxDemandInKW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanFee = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalAmountConsumption = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerConsumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumption_CurrentReading_InstantaneousReadingId",
                        column: x => x.InstantaneousReadingId,
                        principalTable: "CurrentReading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerConsumptionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Month = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TotalPowerConsumption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstantaneousReadingId = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerServiceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FifthStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FifthStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SixthStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SixthStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeventhStepValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeventhStepAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalFee = table.Column<double>(type: "float", nullable: false),
                    BroadCastMonthlyFee = table.Column<double>(type: "float", nullable: false),
                    ConsumptionStamp = table.Column<double>(type: "float", nullable: false),
                    QualityStamp = table.Column<double>(type: "float", nullable: false),
                    BroadCastBigCustomer = table.Column<double>(type: "float", nullable: false),
                    BroadCastInSpecificKw = table.Column<double>(type: "float", nullable: false),
                    BroadCastFromKwToKW = table.Column<double>(type: "float", nullable: false),
                    MaxDemandInKW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanFee = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalAmountConsumption = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerConsumptionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionDetail_CurrentReading_InstantaneousReadingId",
                        column: x => x.InstantaneousReadingId,
                        principalTable: "CurrentReading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CutoffHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstantaneousReadingId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CutoffHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CutoffHistory_CurrentReading_InstantaneousReadingId",
                        column: x => x.InstantaneousReadingId,
                        principalTable: "CurrentReading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterChargeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RechargeTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RechargeValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstantaneousReadingId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterChargeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterChargeHistory_CurrentReading_InstantaneousReadingId",
                        column: x => x.InstantaneousReadingId,
                        principalTable: "CurrentReading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MeterEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RemovedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RemovalTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstantaneousReadingId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterEvent_CurrentReading_InstantaneousReadingId",
                        column: x => x.InstantaneousReadingId,
                        principalTable: "CurrentReading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DepositDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClear = table.Column<bool>(type: "bit", nullable: false),
                    AdvancePaymentId = table.Column<int>(type: "int", nullable: false),
                    AdvancePaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    EPayPermissionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvancePaymentTypeEnum = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousRemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChequeNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EPaymentPermissionNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MFPCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    LastUsedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ReceiptNo = table.Column<int>(type: "int", nullable: true),
                    ExchangeMeterOperationLogId = table.Column<int>(type: "int", nullable: true),
                    TranseferedFromCustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositDetail_DepositType_AdvancePaymentTypeId",
                        column: x => x.AdvancePaymentTypeId,
                        principalTable: "DepositType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DepositDetail_Deposit_AdvancePaymentId",
                        column: x => x.AdvancePaymentId,
                        principalTable: "Deposit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DepositDetail_EPayPermission_EPayPermissionId",
                        column: x => x.EPayPermissionId,
                        principalTable: "EPayPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DebitPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentsCount = table.Column<int>(type: "int", nullable: false),
                    IsHasDiminishingInterest = table.Column<bool>(type: "bit", nullable: false),
                    DiminishingInterestValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiminishingInterestNet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FirstDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMeterDeduction = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebitPayment_Settlement_DebitId",
                        column: x => x.DebitId,
                        principalTable: "Settlement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerConsumptionFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    MonthlyConsumptionId = table.Column<int>(type: "int", nullable: false),
                    ConsumptionFeesValue = table.Column<double>(type: "float", nullable: false),
                    PaymentStatusEnum = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerConsumptionFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFee_ConsumerConsumption_MonthlyConsumptionId",
                        column: x => x.MonthlyConsumptionId,
                        principalTable: "ConsumerConsumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFee_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFee_FeesType_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerConsumptionFeesCalc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeffered = table.Column<bool>(type: "bit", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    MonthlyConsumptionId = table.Column<int>(type: "int", nullable: false),
                    ConsumerConsumptionDetailId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerConsumptionFeesCalc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFeesCalc_ConsumerConsumptionDetail_ConsumerConsumptionDetailId",
                        column: x => x.ConsumerConsumptionDetailId,
                        principalTable: "ConsumerConsumptionDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFeesCalc_ConsumerConsumption_MonthlyConsumptionId",
                        column: x => x.MonthlyConsumptionId,
                        principalTable: "ConsumerConsumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFeesCalc_Consumer_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumerConsumptionFeesCalc_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DebitPaymentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitPaymentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecieptNumber = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    AdvancePaymentId = table.Column<int>(type: "int", nullable: false),
                    AdvancePaymentDetailId = table.Column<int>(type: "int", nullable: true),
                    ISPayFromAdvancePayment = table.Column<bool>(type: "bit", nullable: false),
                    IsLinkToClearDue = table.Column<bool>(type: "bit", nullable: false),
                    DueDateBeforeLinkToClearDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorById = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitPaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebitPaymentDetail_DebitPayment_DebitPaymentId",
                        column: x => x.DebitPaymentId,
                        principalTable: "DebitPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DebitPaymentDetail_Deposit_AdvancePaymentId",
                        column: x => x.AdvancePaymentId,
                        principalTable: "Deposit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountStatusLog_AccountId",
                table: "AccountStatusLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSection_UsersId",
                table: "ApplicationUserSection",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSmallDepartment_SmallDepartmentsId",
                table: "ApplicationUserSmallDepartment",
                column: "SmallDepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyHierarchicalId",
                table: "AspNetUsers",
                column: "CompanyHierarchicalId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyPosId",
                table: "AspNetUsers",
                column: "CompanyPosId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeLog_AccountId",
                table: "ChargeLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_ActivityTypeId",
                table: "CMaintenenceMetersOff",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_CUploadMainteneceMetersOffReasonId",
                table: "CMaintenenceMetersOff",
                column: "CUploadMainteneceMetersOffReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_MainDepartmentId",
                table: "CMaintenenceMetersOff",
                column: "MainDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_MeterTypeId",
                table: "CMaintenenceMetersOff",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_PlaceTypeId",
                table: "CMaintenenceMetersOff",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_SectionId",
                table: "CMaintenenceMetersOff",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CMaintenenceMetersOff_SmallDepartmentId",
                table: "CMaintenenceMetersOff",
                column: "SmallDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_AccountMeterReplacementTypeId",
                table: "Consumer",
                column: "AccountMeterReplacementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_BuildingTypeId",
                table: "Consumer",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_CustomerId",
                table: "Consumer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_CustomerTypeId",
                table: "Consumer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_EmployeeId",
                table: "Consumer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_MeterId",
                table: "Consumer",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_TariffId",
                table: "Consumer",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_TransformerMeterId",
                table: "Consumer",
                column: "TransformerMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumption_InstantaneousReadingId",
                table: "ConsumerConsumption",
                column: "InstantaneousReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionDetail_InstantaneousReadingId",
                table: "ConsumerConsumptionDetail",
                column: "InstantaneousReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFee_AccountId",
                table: "ConsumerConsumptionFee",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFee_FeeId",
                table: "ConsumerConsumptionFee",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFee_MonthlyConsumptionId",
                table: "ConsumerConsumptionFee",
                column: "MonthlyConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFeesCalc_AccountId",
                table: "ConsumerConsumptionFeesCalc",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFeesCalc_ConsumerConsumptionDetailId",
                table: "ConsumerConsumptionFeesCalc",
                column: "ConsumerConsumptionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFeesCalc_MonthlyConsumptionId",
                table: "ConsumerConsumptionFeesCalc",
                column: "MonthlyConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerConsumptionFeesCalc_TariffId",
                table: "ConsumerConsumptionFeesCalc",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerFee_AccountId",
                table: "ConsumerFee",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerFee_FeeId",
                table: "ConsumerFee",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerProperity_ActivityTypeId",
                table: "ConsumerProperity",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerProperity_CustomerTypeId",
                table: "ConsumerProperity",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerProperity_DebitTypeId",
                table: "ConsumerProperity",
                column: "DebitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerProperity_MeterReplacementTypeId",
                table: "ConsumerProperity",
                column: "MeterReplacementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerSettlement_AccountId",
                table: "ConsumerSettlement",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerSettlement_DebitTypeId",
                table: "ConsumerSettlement",
                column: "DebitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerSettlement_Log_ConsumerSettlement_Id",
                table: "ConsumerSettlement_Log",
                column: "ConsumerSettlement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerTamper_AccountId",
                table: "ConsumerTamper",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerTamper_MeterId",
                table: "ConsumerTamper",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerTamper_TamperId",
                table: "ConsumerTamper",
                column: "TamperId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerTariffDifference_AccountId",
                table: "ConsumerTariffDifference",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCard_EmployeeId",
                table: "ControlCard",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCardManagment_ControlCarId",
                table: "ControlCardManagment",
                column: "ControlCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCardManagment_PropertyId",
                table: "ControlCardManagment",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentReading_AccountId",
                table: "CurrentReading",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentReading_MeterId",
                table: "CurrentReading",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPropertySettlement_CustomerPropertyId",
                table: "CustomerPropertySettlement",
                column: "CustomerPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPropertySettlement_SettlementTypeId",
                table: "CustomerPropertySettlement",
                column: "SettlementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CutoffHistory_InstantaneousReadingId",
                table: "CutoffHistory",
                column: "InstantaneousReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitPayment_DebitId",
                table: "DebitPayment",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitPaymentDetail_AdvancePaymentId",
                table: "DebitPaymentDetail",
                column: "AdvancePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitPaymentDetail_DebitPaymentId",
                table: "DebitPaymentDetail",
                column: "DebitPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_AccountId",
                table: "Deposit",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositDetail_AdvancePaymentId",
                table: "DepositDetail",
                column: "AdvancePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositDetail_AdvancePaymentTypeId",
                table: "DepositDetail",
                column: "AdvancePaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositDetail_EPayPermissionId",
                table: "DepositDetail",
                column: "EPayPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeException_FeeId",
                table: "FeeException",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesFirstTimeOnly_AccountId",
                table: "FeesFirstTimeOnly",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesFirstTimeOnly_FeeId",
                table: "FeesFirstTimeOnly",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesType_TariffTypeId",
                table: "FeesType",
                column: "TariffTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainDepartment_sectionId",
                table: "MainDepartment",
                column: "sectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterChargeHistory_InstantaneousReadingId",
                table: "MeterChargeHistory",
                column: "InstantaneousReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterData_MeterTypeId",
                table: "MeterData",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterEvent_InstantaneousReadingId",
                table: "MeterEvent",
                column: "InstantaneousReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterMaintenanceLog_AccountId",
                table: "MeterMaintenanceLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterMaintenanceLog_MeterId",
                table: "MeterMaintenanceLog",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReplaceLog_AccountId",
                table: "MeterReplaceLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReplaceLog_NewMeterId",
                table: "MeterReplaceLog",
                column: "NewMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReplaceLog_OldMeterId",
                table: "MeterReplaceLog",
                column: "OldMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterSettingForm_ConfigurationTemplateId",
                table: "MeterSettingForm",
                column: "ConfigurationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterSettingForm_MeterTypeId",
                table: "MeterSettingForm",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterStatusLog_MeterDataId",
                table: "MeterStatusLog",
                column: "MeterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterStatusLog_MeterStatusId",
                table: "MeterStatusLog",
                column: "MeterStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterToAnotherConsumer_ConsumerId",
                table: "MeterToAnotherConsumer",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterToAnotherConsumer_MeterId",
                table: "MeterToAnotherConsumer",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleFee_AccountId",
                table: "MiddleFee",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleFee_ContractFeeTypeId",
                table: "MiddleFee",
                column: "ContractFeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleFeesType_MeterTypeId",
                table: "MiddleFeesType",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceType_TariffTypeId",
                table: "PlaceType",
                column: "TariffTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfSale_departmentId",
                table: "PointOfSale",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplaceCardLog_AccountId",
                table: "ReplaceCardLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplaceConsumerOperationLog_AccountId",
                table: "ReplaceConsumerOperationLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplaceConsumerOperationLog_MeterId",
                table: "ReplaceConsumerOperationLog",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTechnician_TechniciansId",
                table: "SectionTechnician",
                column: "TechniciansId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingFormsData_MeterTemplateId",
                table: "SettingFormsData",
                column: "MeterTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlement_AccountId",
                table: "Settlement",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlement_DebitTypeId",
                table: "Settlement",
                column: "DebitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallDepartment_MainDepartmentId",
                table: "SmallDepartment",
                column: "MainDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallDepartment_SectionId",
                table: "SmallDepartment",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallDepartment_Users_AppUserId",
                table: "SmallDepartment_Users",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallDepartment_Users_SmallDepartmentId",
                table: "SmallDepartment_Users",
                column: "SmallDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallDepartmentTechnician_TechniciansId",
                table: "SmallDepartmentTechnician",
                column: "TechniciansId");

            migrationBuilder.CreateIndex(
                name: "IX_StepsFee_FeeId",
                table: "StepsFee",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariff_TariffTypeId",
                table: "Tariff",
                column: "TariffTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffFee_FeeId",
                table: "TariffFee",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffFee_TariffId",
                table: "TariffFee",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffStep_TariffId",
                table: "TariffStep",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffTamper_TamperId",
                table: "TariffTamper",
                column: "TamperId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffTamper_TariffId",
                table: "TariffTamper",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_CompanyHierarchicalId",
                table: "Technician",
                column: "CompanyHierarchicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_MainDepartmentId",
                table: "Technician",
                column: "MainDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_TechnicianTypeId",
                table: "Technician",
                column: "TechnicianTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransformerReading_TransformerId",
                table: "TransformerReading",
                column: "TransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermissionLog_AccountId",
                table: "WorkPermissionLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermissionLog_MeterId",
                table: "WorkPermissionLog",
                column: "MeterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStatusLog");

            migrationBuilder.DropTable(
                name: "ApplicationUserSection");

            migrationBuilder.DropTable(
                name: "ApplicationUserSmallDepartment");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Auditing");

            migrationBuilder.DropTable(
                name: "BasicConsumer");

            migrationBuilder.DropTable(
                name: "BasicSetting");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ChargeLog");

            migrationBuilder.DropTable(
                name: "CMaintenenceMetersOff");

            migrationBuilder.DropTable(
                name: "ConsumerConsumptionFee");

            migrationBuilder.DropTable(
                name: "ConsumerConsumptionFeesCalc");

            migrationBuilder.DropTable(
                name: "ConsumerFee");

            migrationBuilder.DropTable(
                name: "ConsumerSettlement_Log");

            migrationBuilder.DropTable(
                name: "ConsumerTamper");

            migrationBuilder.DropTable(
                name: "ConsumerTariffDifference");

            migrationBuilder.DropTable(
                name: "ControlCardManagment");

            migrationBuilder.DropTable(
                name: "CustomerPropertySettlement");

            migrationBuilder.DropTable(
                name: "CutoffHistory");

            migrationBuilder.DropTable(
                name: "DbSetting");

            migrationBuilder.DropTable(
                name: "DebitPaymentDetail");

            migrationBuilder.DropTable(
                name: "DepositDetail");

            migrationBuilder.DropTable(
                name: "EditChargeLog");

            migrationBuilder.DropTable(
                name: "EmployeeGroup");

            migrationBuilder.DropTable(
                name: "FeeException");

            migrationBuilder.DropTable(
                name: "FeesFirstTimeOnly");

            migrationBuilder.DropTable(
                name: "MeterChargeHistory");

            migrationBuilder.DropTable(
                name: "MeterEvent");

            migrationBuilder.DropTable(
                name: "MeterMaintenanceLog");

            migrationBuilder.DropTable(
                name: "MeterReplaceLog");

            migrationBuilder.DropTable(
                name: "MeterSettingForm");

            migrationBuilder.DropTable(
                name: "MeterStatusLog");

            migrationBuilder.DropTable(
                name: "MeterToAnotherConsumer");

            migrationBuilder.DropTable(
                name: "MiddleFee");

            migrationBuilder.DropTable(
                name: "OpenConsumerCardLog");

            migrationBuilder.DropTable(
                name: "PagesName");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "ReplaceCardLog");

            migrationBuilder.DropTable(
                name: "ReplaceConsumerLog");

            migrationBuilder.DropTable(
                name: "ReplaceConsumerOperationLog");

            migrationBuilder.DropTable(
                name: "RetriveInitialBalanceLog");

            migrationBuilder.DropTable(
                name: "SectionTechnician");

            migrationBuilder.DropTable(
                name: "ServiceLogs");

            migrationBuilder.DropTable(
                name: "SettingFormsData");

            migrationBuilder.DropTable(
                name: "SmallDepartment_Users");

            migrationBuilder.DropTable(
                name: "SmallDepartmentTechnician");

            migrationBuilder.DropTable(
                name: "StepsFee");

            migrationBuilder.DropTable(
                name: "TableName");

            migrationBuilder.DropTable(
                name: "TariffFee");

            migrationBuilder.DropTable(
                name: "TariffStep");

            migrationBuilder.DropTable(
                name: "TariffTamper");

            migrationBuilder.DropTable(
                name: "TransformerReading");

            migrationBuilder.DropTable(
                name: "UploadConsumerData");

            migrationBuilder.DropTable(
                name: "UploadConsumerLog");

            migrationBuilder.DropTable(
                name: "UserPointOfSale");

            migrationBuilder.DropTable(
                name: "WorkPermissionLog");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "CUploadMainteneceMetersOffReason");

            migrationBuilder.DropTable(
                name: "ConsumerConsumptionDetail");

            migrationBuilder.DropTable(
                name: "ConsumerConsumption");

            migrationBuilder.DropTable(
                name: "ConsumerSettlement");

            migrationBuilder.DropTable(
                name: "CardFunction");

            migrationBuilder.DropTable(
                name: "ControlCard");

            migrationBuilder.DropTable(
                name: "ConsumerProperity");

            migrationBuilder.DropTable(
                name: "DebitPayment");

            migrationBuilder.DropTable(
                name: "DepositType");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "EPayPermission");

            migrationBuilder.DropTable(
                name: "MeterStatusType");

            migrationBuilder.DropTable(
                name: "MiddleFeesType");

            migrationBuilder.DropTable(
                name: "SettingForm");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SmallDepartment");

            migrationBuilder.DropTable(
                name: "FeesType");

            migrationBuilder.DropTable(
                name: "Tamper");

            migrationBuilder.DropTable(
                name: "CurrentReading");

            migrationBuilder.DropTable(
                name: "Settlement");

            migrationBuilder.DropTable(
                name: "PointOfSale");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "SettlementType");

            migrationBuilder.DropTable(
                name: "ConsumerInfo");

            migrationBuilder.DropTable(
                name: "ConsumerType");

            migrationBuilder.DropTable(
                name: "MeterData");

            migrationBuilder.DropTable(
                name: "PlaceType");

            migrationBuilder.DropTable(
                name: "SubstitutionType");

            migrationBuilder.DropTable(
                name: "Tariff");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "Transformer");

            migrationBuilder.DropTable(
                name: "MeterType");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "CompanyHierarchical");

            migrationBuilder.DropTable(
                name: "MainDepartment");

            migrationBuilder.DropTable(
                name: "TechnicianType");

            migrationBuilder.DropTable(
                name: "Section");
        }
    }
}

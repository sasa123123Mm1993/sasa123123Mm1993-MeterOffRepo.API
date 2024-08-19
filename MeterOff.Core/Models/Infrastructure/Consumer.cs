using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeterOff.Models.Enum;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Consumer : BaseEntity
    {
        public Consumer()
        {
            
            OrderLogs = new HashSet<ChargeLog>();
            AccountFees = new HashSet<ConsumerFee>();
            ReplaceCardHistories = new HashSet<ReplaceCardLog>();
            MeterReplacementLogs = new HashSet<MeterReplaceLog>();
            MeterMovementLogs = new HashSet<MeterToAnotherConsumer>();
            Debits = new HashSet<Settlement>();
            MeterMaintenanceHistories = new HashSet<MeterMaintenanceLog>();
            AccountTampers = new HashSet<ConsumerTamper>();
            AccountStatusLogs = new HashSet<AccountStatusLog>();
            ContractFees = new HashSet<MiddleFee>();
            ConsumptionCalculationFees = new HashSet<ConsumerConsumptionFeesCalc>();
            InstantaneousReadings = new HashSet<CurrentReading>();
            AccountTariffDifferences = new HashSet<ConsumerTariffDifference>();
            AccountConsumptionFees = new HashSet<ConsumerConsumptionFee>();
            AccountDebits = new HashSet<ConsumerSettlement>();

        }
        public int CustomerId { get; set; }

        [MaxLength(20)]
        public string CustomerCode { get; set; }
        public int TypeNo { get; set; }
        public int BranchNo { get; set; }
        public int AccountNo { get; set; }
        public int DailyNo { get; set; }
        public int RegionNo { get; set; }
        public int DepartmentNo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public Guid? MeterUid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public Guid? CardUid { get; set; }
        public int? SmallDepartmentNo { get; set; }
        [MaxLength(30)]
        public string MeasurementNo { get; set; }
        [MaxLength(30)]
        public string ContractingNo { get; set; }
        [MaxLength(30)]
        public string ReceiptNumber { get; set; }
        [MaxLength(30)]
        public string InitialBalanceReceiptNumber { get; set; }
        [MaxLength(100)]
        public string East { get; set; }
        [MaxLength(1000)]
        public string EndAccountReason { get; set; }
        public string EndAccountUser { get; set; }
        public DateTime? FirstReadDate { get; set; }
        public DateTime? FirstRechargeDate { get; set; }

        [MaxLength(100)]
        public string Western { get; set; }
        [MaxLength(100)]
        public string North { get; set; }
        [MaxLength(100)]
        public string South { get; set; }
        [MaxLength(50)]
        public string RefferenceAddress { get; set; }
        public int SectionNo { get; set; }
        public DateTime ContractingDate { get; set; }
        public int ContractingYear => ContractingDate.Year;
      
        public int? MeterId { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public AccountMeterStatusEnum AccountMeterStatusEnum { get; set; }
        public AccountStatusEnum Status { get; set; }

        [MaxLength(50)]
        public string PlateNumber { get; set; } //رقم اللوحة
        public DateTime? MeterInstallationDate { get; set; }
        public DateTime? MeterPreparedDate { get; set; }
        public DateTime? EndAccountDate { get; set; }
        public DateTime? LastRechargeDate { get; set; }
      
        public int? EmployeeId { get; set; }
      
        public int? RecivedEmployeeId { get; set; }
      
        public int? SavedUserId { get; set; }
      
        public int? PerpearedUserId { get; set; }
      
        public int? PrintWorkOrderUserId { get; set; }
        [MaxLength(20)]
        public string Lat { get; set; }
        [MaxLength(20)]
        public string Long { get; set; }
        public DateTime? MeasurementDate { get; set; }

        public DateTime? UpdateTariffTypeDate { get; set; }
        public decimal? CleaningFees { get; set; }
      
        public int? RegionId { get; set; }
      
        public int? TransformerMeterId { get; set; }
      
        public int? TariffId { get; set; }
      
        public int TariffTypeId { get; set; }

      
        public int? OldTariffId { get; set; }
        public string OldMeterNumber { get; set; }
        [MaxLength(20)]
        public string OldAccountNumber { get; set; }
        public int? CustomerTypeId { get; set; }

        [ConcurrencyCheck]
        public decimal AccountMaxLoad { get; set; }
        public decimal ContractTotalFees { get; set; }
        public decimal? InitialBalance { get; set; }
      
        public bool IsActivated { get; set; }
      
        public bool IsMeterInstalled { get; set; }
      
        public int? BuildingTypeId { get; set; }
      
        public bool Issmallcustomer { get; set; }
      
        public bool IsPrepared { get; set; }
      
        public bool IsCardRead { get; set; }
      
        public bool IsCardCharged { get; set; }
      
        public bool IsRemoveInatialBalance { get; set; }
      
        public int? PurposeOfUseId { get; set; }
        public int? UsageSectorCode { get; set; }
        [MaxLength(300)]
        public string Notes { get; set; }
      
        public int? AccountMeterReplacementTypeId { get; set; }
        [MaxLength(50)]
        public string BlockNumber { get; set; }
        [MaxLength(50)]
        public string FloorNumber { get; set; }
        [MaxLength(50)]
        public string ApartmentNumber { get; set; }
        public bool IsPrintedMeterExchangeOrder { get; set; }
        [MaxLength(200)]
        public string BlockReason { get; set; }
        public string BlockUser { get; set; }
        public DateTime? BlockDate { get; set; }
        [MaxLength(3)]
        public string GenerationCardType { get; set; }
      
        [MaxLength(20)]
        public string InitialCardNumber { get; set; }
        public bool IsEndAccountMustPayDebit { get; set; }
      
        public int? AccountUploadId { get; set; }
        public bool IsMeterReplaced { get; set; }
        public bool IsOpenCardPending { get; set; }

        [MaxLength(30)]
        public string UnitACA_Key { get; set; }

        [MaxLength(30)]
        public string BuildingNationalID { get; set; }

        public Int64 RefAdd { get; set; }
        [NotMapped]

        [ForeignKey("OldTariffId")]
        public virtual Tariff OldTariff { get; set; }

        [ForeignKey("BuildingTypeId")]
        public virtual PlaceType BuildingType { get; set; }


        [ForeignKey("AccountMeterReplacementTypeId")]
        public virtual SubstitutionType AccountMeterReplacementType { get; set; }

        [ForeignKey("CustomerTypeId")]
        public virtual ConsumerType CustomerType { get; set; }
        [ForeignKey("TariffId")]
        public virtual Tariff Tariff { get; set; }

        //[ForeignKey("RegionId")]
        //public virtual CompanyHierarchical OrganizationStructure { get; set; }

        [ForeignKey("TransformerMeterId")]
        public virtual Transformer TransformerMeter { get; set; }

        [ForeignKey("MeterId")]
        public virtual MeterData Meter { get; set; }

       
        public virtual ICollection<ChargeLog> OrderLogs { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ConsumerInfo Customer { get; set; }
        public virtual ICollection<AccountStatusLog> AccountStatusLogs { get; set; }
        public virtual ICollection<ConsumerFee> AccountFees { get; set; }
        public virtual ICollection<ReplaceCardLog> ReplaceCardHistories { get; set; }
        public virtual ICollection<MeterReplaceLog> MeterReplacementLogs { get; set; }
        public virtual ICollection<MeterToAnotherConsumer> MeterMovementLogs { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Technician Employee { get; set; }


        //[ForeignKey("RecivedEmployeeId")]
        //public virtual Technician RecivedEmployee { get; set; }
        //[ForeignKey("SavedUserId")]
        //public virtual AppUser SavedUser { get; set; }

        //[ForeignKey("PerpearedUserId")]
        //public virtual AppUser PerpearedUser { get; set; }

        //[ForeignKey("PrintWorkOrderUserId")]
        //public virtual AppUser PrintWorkOrderUser { get; set; }
      
        //[ForeignKey("CreatorById")]
        //public virtual AppUser User { get; set; }
        public virtual ICollection<Settlement> Debits { get; set; }
        public virtual ICollection<ConsumerSettlement> AccountDebits { get; set; }
        public virtual ICollection<MeterMaintenanceLog> MeterMaintenanceHistories { get; set; }
        public virtual ICollection<ConsumerTamper> AccountTampers { get; set; }
        public virtual ICollection<MiddleFee> ContractFees { get; set; }
        public virtual ICollection<ConsumerConsumptionFeesCalc> ConsumptionCalculationFees { get; set; }
        public virtual ICollection<ConsumerConsumptionFee> AccountConsumptionFees { get; set; }
        public virtual ICollection<ConsumerTariffDifference> AccountTariffDifferences { get; set; }

        public virtual ICollection<CurrentReading> InstantaneousReadings { get; set; }
    }
}

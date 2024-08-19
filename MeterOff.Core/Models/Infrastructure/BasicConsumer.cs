using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public class BasicConsumer : BaseEntity
    {
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
        [MaxLength(3)]
        public string GenerationCardType { get; set; }
      
        [MaxLength(20)]
        public string InitialCardNumber { get; set; }
        public bool IsEndAccountMustPayDebit { get; set; }
        public int? AccountUploadId { get; set; }

    }
}

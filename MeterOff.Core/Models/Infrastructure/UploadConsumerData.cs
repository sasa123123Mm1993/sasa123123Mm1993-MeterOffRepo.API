using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public class UploadConsumerData : BaseEntity
    {
        //customer
        public new bool? IsDeleted { get; set; }
        public new int? CreatorById { get; set; }
        public new DateTime? CreationTime { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string PassPort { get; set; }
        public string Phone { get; set; }
        //Account
        public int? TypeNo { get; set; } //from tariffTypeCode
        public int? BranchNo { get; set; }
        public int? AccountNo { get; set; }
        public int? DailyNo { get; set; }
        public int? RegionNo { get; set; }
        public int? DepartmentNo { get; set; }
        public int? SectionNo { get; set; }//from organizationStructureCodeByDepCode
        public int? SmallDepartmentNo { get; set; }//from organizationStructureCodeByDepCode

        public string MeasurementNo { get; set; }//don't duplicate
        public string ContractingNo { get; set; }//don't duplicate
        public string ReceiptNumber { get; set; }
        public string InitialBalanceReceiptNumber { get; set; }
        public string East { get; set; }
        public string Western { get; set; }
        public string North { get; set; }
        public string South { get; set; }
        public string RefferenceAddress { get; set; }
        public DateTime? ContractingDate { get; set; }//today
        public int TariffId { get; set; }
        public int? TariffTypeCode { get; set; }//fromTariffTypeByCode
        public int? TariffTypeId { get; set; }//fromTariffTypeByCode
        public int MeterId { get; set; }
        public string Address { get; set; }
        public string PlateNumber { get; set; } //رقم اللوحة
        public string Lat { get; set; }
        public string Long { get; set; }
        public DateTime? MeasurementDate { get; set; } 
        public int? TransformerMeterCode { get; set; }
        public int? TransformerMeterId { get; set; }
        public int? CustomerTypeCode { get; set; }//fromCustomerTypeByCode
        public int? CustomerTypeId { get; set; }//fromCustomerTypeByCode
        public int? Issmallcustomer { get; set; }
        public int? BuildingTypeCode { get; set; }//fromBuildingTypeByCode
        public int? BuildingTypeId { get; set; }//fromBuildingTypeByCode
        public decimal? InitialBalance { get; set; }//fromTariffTypeByTariffTypeCode
        public decimal? AccountMaxLoad { get; set; }
        public string BlockNumber { get; set; }
        public string FloorNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Notes { get; set; }
        public int? AccountMeterReplacementTypeId { get; set; }
        public int? AccountMeterReplacementTypeCode { get; set; }
        public int? PurposeOfUseId { get; set; }
        public int? UsageSectorId { get; set; }
        public int? PurposeOfUseCode { get; set; }
        public int? UsageSectorCode { get; set; }
        public int? RefuseReasonId { get; set; }

        #region Accounttttttttttttttt
        public int? CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public AccountMeterStatusEnum? AccountMeterStatusEnum { get; set; }
        public AccountStatusEnum? Status { get; set; }
        public int? SavedUserId { get; set; }
        public int? RegionId { get; set; }
        public bool? IsCanSave { get; set; }
        public bool? IsActivated { get; set; }
        #endregion
        public decimal? CleaningFees { get; set; }
        public bool? IsMeterInstalled { get; set; }
        public bool? IsPrepared { get; set; }
        public bool? IsCardRead { get; set; }
        public bool? IsCardCharged { get; set; }
        public bool? IsRemoveInatialBalance { get; set; }
        public bool? IsPrintedMeterExchangeOrder { get; set; }
        public decimal? ContractTotalFees { get; set; }
        public int? TotalUpload { get; set; }
        public int? UploadFileCode { get; set; }
        public bool IsAccepted { get; set; }


    }
}

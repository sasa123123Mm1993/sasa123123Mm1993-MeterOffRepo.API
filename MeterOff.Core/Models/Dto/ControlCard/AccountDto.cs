using MeterOff.Core.Models.Constant;
using MeterOff.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class AccountDto : BaseDto
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public int TypeNo { get; set; }
        public int BranchNo { get; set; }
        public int AccountNo { get; set; }
        public int DailyNo { get; set; }
        public int RegionNo { get; set; }
        public int DepartmentNo { get; set; }
        public int? SmallDepartmentNo { get; set; }
        public DateTime? LastRechargeDate { get; set; }
        public string MeasurementNo { get; set; }
        public string ContractingNo { get; set; }
        public string ReceiptNumber { get; set; }
        public string InitialBalanceReceiptNumber { get; set; }
        public string East { get; set; }
        public string Western { get; set; }
        public string North { get; set; }
        public string South { get; set; }
        public string RefferenceAddress { get; set; }
        public int SectionNo { get; set; }
        public DateTime? FirstReadDate { get; set; }
        public DateTime? FirstRechargeDate { get; set; }
        public string EndAccountReason { get; set; }
        public string EndAccountUser { get; set; }
        public DateTime ContractingDate { get; set; }
        public DateTime? UpdateTariffTypeDate { get; set; }
        public int TariffId { get; set; }
        public int TariffTypeId { get; set; }
        public int MeterId { get; set; }
        public string Address { get; set; }
        public string PlateNumber { get; set; } //رقم اللوحة
        public DateTime? MeterInstallationDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? RecivedEmployeeId { get; set; }
        public int? SavedUserId { get; set; }
        public int? PerpearedUserId { get; set; }
        public int? PrintWorkOrderUserId { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public DateTime? MeasurementDate { get; set; }
        public decimal CleaningFees { get; set; }
        public int? RegionId { get; set; }
        public int? TransformerMeterId { get; set; }
        public string OldMeterNumber { get; set; }
        public string OldAccountNumber { get; set; }
        public int CustomerTypeId { get; set; }
        public bool Issmallcustomer { get; set; }
        public bool IsPrepared { get; set; }
        public bool IsCardRead { get; set; }
        public bool IsCardCharged { get; set; }
        public bool IsPreparedRemoveInatialBalance { get; set; }
        public int? PurposeOfUseId { get; set; }
        public int? UsageSectorCode { get; set; }
        public int? BuildingTypeId { get; set; }
        public string BuildingNationalID { get; set; }
        public string CardUid { get; set; }
        public string MeterUid { get; set; }
        public string Notes { get; set; }
        public int? AccountMeterReplacementTypeId { get; set; }
        public decimal? InitialBalance { get; set; }
        public decimal AccountMaxLoad { get; set; }
        public decimal ContractTotalFees { get; set; }
        public string BlockNumber { get; set; }
        public string FloorNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public bool IsActivated { get; set; }
        public bool IsPrintedMeterExchangeOrder { get; set; }
        public string BlockReason { get; set; }
        public string BlockUser { get; set; }
        public DateTime? BlockDate { get; set; }
        public string InitialCardNumber { get; set; }
        public string GenerationCardType { get; set; }
        public bool IsEndAccountMustPayDebit { get; set; }
        public bool IsMeterReplaced { get; set; }
        public bool IsMeterInstalled { get; set; }
        public AccountMeterStatusEnum AccountMeterStatusEnum { get; set; }
        public BuildingTypeDto BuildingType { get; set; }
        public AccountStatusEnum Status { get; set; }
        public decimal? ContractMaxDemandInKW { get; set; }
        public TariffDto Tariff { get; set; }
        public EmployeeDto Employee { get; set; }
        public UserDto User { get; set; }
        public EmployeeDto RecivedEmployee { get; set; }
        public UserDto PerpearedUser { get; set; }
        public OrganizationStructureDto OrganizationStructure { get; set; }
        public OrganizationStructureDto SmallOrganizationStructure { get; set; }
        public CustomerDto Customer { get; set; }


    }
}

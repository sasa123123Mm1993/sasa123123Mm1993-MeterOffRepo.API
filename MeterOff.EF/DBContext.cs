using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using MeterOff.Core.Models.Test;
using MeterOff.Core.Models;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.Core.Models.Identity;
using MeterOff.Core.Models.Dto.Reports;
//using System.Data.Entity;

namespace MeterOff.EF
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {


        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        public DbSet<CMaintenenceMetersOffDto> cMaintenenceMetersOffDtos { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<ServiceLog> ServiceLogs { get; set; }
        public DbSet<Audit> Auditing { get; set; }
        public DbSet<BasicSetting> BasicSetting { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<ScreenManagement> PagesName { get; set; }
        public DbSet<CMaintenenceMetersOff> CMaintenenceMetersOff { get; set; }
        public DbSet<CUploadMainteneceMetersOffReason> CUploadMainteneceMetersOffReason { get; set; }
        public DbSet<DbSetting> DbSetting { get; set; } 
        public DbSet<CompanyPos> PointOfSale { get; set; }
        public DbSet<PosUser> UserPointOfSale { get; set; }
        public DbSet<Tamper> Tamper { get; set; }
        public DbSet<DataTable> TableName { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<CardFunction> CardFunction { get; set; }
        public DbSet<ChargeLog> ChargeLog { get; set; }
        public DbSet<ConsumerConsumption> ConsumerConsumption { get; set; }
        public DbSet<ConsumerConsumptionDetail> ConsumerConsumptionDetail { get; set; }
        public DbSet<ConsumerConsumptionFee> ConsumerConsumptionFee { get; set; }
        public DbSet<ConsumerConsumptionFeesCalc> ConsumerConsumptionFeesCalc { get; set; }
        public DbSet<ConsumerFee> ConsumerFee { get; set; }
        public DbSet<ConsumerInfo> ConsumerInfo { get; set; }
        public DbSet<SmallDepartment_User> SmallDepartment_Users { get; set; }
        public DbSet<ConsumerSettlement> ConsumerSettlement { get; set; }
        public DbSet<ConsumerSettlement_Log> ConsumerSettlement_Log { get; set; }
        public DbSet<ConsumerTamper> ConsumerTamper { get; set; }
        public DbSet<ConsumerTariffDifference> ConsumerTariffDifference { get; set; }
        public DbSet<ConsumerType> ConsumerType { get; set; }
        public DbSet<ControlCard> ControlCard { get; set; }
        public DbSet<ControlCardManagment> ControlCardManagment { get; set; }
        public DbSet<CurrentReading> CurrentReading { get; set; }
        public DbSet<CutoffHistory> CutoffHistory { get; set; }
        public DbSet<DebitPayment> DebitPayment { get; set; }
        public DbSet<DebitPaymentDetail> DebitPaymentDetail { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<DepositDetail> DepositDetail { get; set; }
        public DbSet<DepositType> DepositType { get; set; }
        public DbSet<EditChargeLog> EditChargeLog { get; set; }
        public DbSet<EPayPermission> EPayPermission { get; set; }
        public DbSet<FeeException> FeeException { get; set; }
        public DbSet<FeesFirstTimeOnly> FeesFirstTimeOnly { get; set; }
        public DbSet<FeesType> FeesType { get; set; }
        public DbSet<MeterChargeHistory> MeterChargeHistory { get; set; }
        public DbSet<MeterData> MeterData { get; set; }
        public DbSet<MeterEvent> MeterEvent { get; set; }
        public DbSet<MeterMaintenanceLog> MeterMaintenanceLog { get; set; }
        public DbSet<MeterReplaceLog> MeterReplaceLog { get; set; }
        public DbSet<MeterSettingForm> MeterSettingForm { get; set; }
        public DbSet<MeterStatusLog> MeterStatusLog { get; set; }
        public DbSet<MeterStatusType> MeterStatusType { get; set; }
        public DbSet<MeterToAnotherConsumer> MeterToAnotherConsumer { get; set; }
        public DbSet<MeterType> MeterType { get; set; }
        public DbSet<ReplaceCardLog> ReplaceCardLog { get; set; }
        public DbSet<SettingForm> SettingForm { get; set; }
        public DbSet<SettingFormsData> SettingFormsData { get; set; }
        public DbSet<Settlement> Settlement { get; set; }
        public DbSet<SettlementType> SettlementType { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffTamper> TariffTamper { get; set; }
        public DbSet<WorkPermissionLog> WorkPermissionLog { get; set; }
        public DbSet<BasicConsumer> BasicConsumer { get; set; }
        public DbSet<Consumer> Consumer { get; set; }
        public DbSet<MiddleFee> MiddleFee { get; set; }
        public DbSet<MiddleFeesType> MiddleFeesType { get; set; }
        public DbSet<OpenConsumerCardLog> OpenConsumerCardLog { get; set; }
        public DbSet<ReplaceConsumerLog> ReplaceConsumerLog { get; set; }
        public DbSet<ReplaceConsumerOperationLog> ReplaceConsumerOperationLog { get; set; }
        public DbSet<RetriveInitialBalanceLog> RetriveInitialBalanceLog { get; set; }
        public DbSet<SubstitutionType> SubstitutionType { get; set; }
        public DbSet<UploadConsumerData> UploadConsumerData { get; set; }
        public DbSet<UploadConsumerLog> UploadConsumerLog { get; set; }
        public DbSet<PlaceType> PlaceType { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SmallDepartment> SmallDepartment { get; set; }
        public DbSet<MainDepartment> MainDepartment { get; set; }
        public DbSet<ConsumerProperity> ConsumerProperity { get; set; }
        public DbSet<CustomerPropertySettlement> CustomerPropertySettlement { get; set; }
        public DbSet<Technician> Technician { get; set; }
        public DbSet<EmployeeGroup> EmployeeGroup { get; set; }
        public DbSet<StepsFee> StepsFee { get; set; }
        public DbSet<TariffFee> TariffFee { get; set; }
        public DbSet<TariffStep> TariffSteps { get; set; }
        public DbSet<Transformer> Transformer { get; set; }
        public DbSet<TransformerReading> TransformerReading { get; set; }
        public DbSet<TechnicianType> TechnicianType { get; set; }
        //public DbSet<InstallCardReading> installCardReading { get; set; }
        
        public object Query<T>(string query)
        {
            throw new NotImplementedException();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CMaintenenceMetersOffDto>(e => {e.HasNoKey().ToView(null); });
            builder.Entity<IdentityUser>()
           .Property(u => u.UserName)
           .HasMaxLength(256);

        }

        

    }
}

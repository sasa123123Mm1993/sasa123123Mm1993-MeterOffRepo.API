using Dapper;
using System.Data;
using System.Data.SqlClient;
using GPICardCore.Master;
using GPICardCore;

namespace GPICardDB
{
    public static class DB
    {
      
        static string connString = @"data source=.;
                                    initial catalog=GizaDevMenia;
                                    user=sa;
                                    password=Giza@123456;";

        private static string SettingFormsDataQuery = @"SELECT TOP (1) [Id]
      ,[MeterTemplateId]
      ,[FriendlyStartHour]
      ,[FriendlyEndHour]
      ,[QuiteStartHour]
      ,[QuiteEndHour]
      ,[MaxLoad]
      ,[MaxNumberOfCutoffs]
      ,[BillingDay]
      ,[FirstCutoffAlarmLimitBalance]
      ,[SecondCutoffAlarmLimitBalance]
      ,[MeterTimeStapToSet]
      ,[GarceType]
      ,[GraceValue]
      ,[IsDeleted]     
      ,[StopChargePeriodInDays]
      ,[HHFwVersion]
      ,[HHFwName]
      ,[IsCanRemoveInitialBalance]
      ,[GenericSpecificationType]
      ,[IsConsumptionTamperBlock]
      ,[IsMeterDateInFuture]
      ,[MeterSerialFrom]
      ,[MeterSerialTo]
      ,[IsCysheildCard]
      ,[IsEFUseCysheildCard]
      ,[MaxMonthDeferDate]
      ,[IsDebitDueDateNextDate]
      ,[IsSetDateTimeWithOpenAccount]
      ,[IsDeductFeesexceptionWithZeroConsumption]
      ,[IsUpdateInitalBalanceWithOpenAccount]
      ,[IsTariffDifferanceDeductAtNextMonth]      
      ,[DebtAmountLimit]
      ,[hoardMoneyLimit]
      ,[InstallingMode]
      ,[CancelOrPullChargePeriodInDays]      
      ,[IsReadBalanceInChangeMeter] 
      ,[IsMeterDisablewhenchanging]
      ,[IsActivityTypeCodeAddedToConsumerRefference]
      ,[IsCommercialSectorCodeAddedToConsumerRefference]
      ,[DuringRescheduling]
      ,[MaxDaysforpaydebts]
      ,[IsDelayDebitCharge] 
      ,[NoOfMaxInvalidLogin]
      ,[IsDailyPrecedesReferenceAddress]
      ,[IsCalculateContractMaxDemand]
      ,[ContractMaxDemandKWPrice]
      ,[ContractMaxDemandNumberOfInstallment]
      ,[CleanFeesActivationDate]
       FROM  
       [dbo].[SettingFormsDatas]
       WHERE IsDeleted = 0";

        private static DataTable dtSettingFormsData = new DataTable();
        private static SqlDataAdapter da = new SqlDataAdapter(SettingFormsDataQuery, new SqlConnection(connString));
        private static DataRow data;

        static DB()
        {
            da.Fill(dtSettingFormsData);
            data = dtSettingFormsData.Rows[0];
        }
        public static List<string> GetHolidays()         
        {
            try
            {
                const string query = @"
                SELECT TOP (30)
                FORMAT ([Date], 'dd-MM-yyyy') AS [holiday]
                FROM  [dbo].[Holidays]
                WHERE [IsDeleted] = 0 AND 
                [Date] >= GETDATE()
                ORDER BY [Date] ";

                using (IDbConnection db = new SqlConnection(connString))
                {
                    var holidays =   db.Query<string>(query);
                    return holidays.AsList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        
        }

        public static int GetInstallingMode()
        {
            return  data["InstallingMode"].ToInt();
        }

        public static FriendlyTime GetFriendlyTime() 
        {
            try
            {
                
                FriendlyTime friendlyTime = new FriendlyTime
                {
                    StartHour = data["FriendlyStartHour"].ToInt() , 
                    EndHour   = data["FriendlyEndHour"].ToInt()
                };

                return friendlyTime;
            }
            catch (Exception)
            {

                return null;
            }
        
        }

        public static MaxLoadSetting GetMaxLoadSetting()
        {
            try
            {
                MaxLoadSetting max = new MaxLoadSetting
                {
                    MaxLoad           = data["MaxLoad"].ToInt() ,
                    MaxNumberOfCutOFF = data["MaxNumberOfCutoffs"].ToInt() ,
                };

                return max; 
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static string GetBillingDay()
        {
            return "01 00:00";
        }

        public static QuiteTime GetQuiteTime()
        {
            try
            {
                QuiteTime quiteTime = new QuiteTime
                {
                    Start = data["QuiteStartHour"].ToInt(),
                    End   = data["QuiteEndHour"].ToInt()
                };

                return quiteTime;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static TotalDebt GetTotalDebt()
        {
            try
            {
                TotalDebt totalDebt = new TotalDebt
                {
                    Limit = 30
                };
                return totalDebt;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static GracePeriod GetGracePeriod()
        {
            try
            {
                GracePeriod gracePeriod = new GracePeriod
                {
                    Type  = data["GarceType"].ToInt(),
                    Value = data["GraceValue"].ToDecimal()
                };
                return gracePeriod;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetMeterVersion(int modelId)
        {
            switch (modelId)
            {

                case 1: return "GPM-PP01"; 

                case 2: return "";

                default: return null;
            }
            
        }

        public static string GetManufacturerId()
        {
            return "07";
        }

        public static List<TariffStep> GetTariffStep(int  TariffId)
        {
            try
            {
                 string query = $@"SELECT  
                 [ServicePrice]                         AS [TariffStepCustomerServiceFee]
                ,[From]						            AS [TariffStepLimitFrom]
                ,[To]						            AS [TariffStepLimitTo]
                ,ROW_NUMBER() OVER (ORDER BY [From] )   AS [TariffStepNumber]
                ,[Price]      				            AS [TariffStepPrice]
                ,[SangenRecalculatedEdge]	            AS [TariffStepRecalculationEdge]
                ,[SangenRecalculatedAmount]             AS [TariffStepRecalculationEdgeAddedAmount] 
                FROM  
                [dbo].[TariffSteps]
                WHERE 
                [TariffId]  = {TariffId}  AND
                [IsDeleted] = 0
                ORDER BY [From]";

                using (IDbConnection db = new SqlConnection(connString))
                {
                    var steps = db.Query<TariffStep>(query);
                    return steps.AsList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}

namespace GPICardCore.ErrorCode
{
    public static class DriverException
    {
        private static readonly Dictionary<int, string> ErrorCodeMessages = new Dictionary<int, string>
    {
        { 8001, "MeterId formatting or length errors" },
        { 8002, "MeterType formatting or length errors" },
        { 8003, "ManufacturerId formatting or length errors" },
        { 8004, "CardId formatting or length errors" },
        { 8005, "CustomerId formatting or length errors" },
        { 8006, "CardType formatting or length errors" },
        { 8007, "CustomerOperationType formatting or length errors" },
        { 8008, "ControlOperationType or StepExtraCost formatting or length errors" },
        { 8009, "OldCardId formatting or length errors" },
        { 8010, "CustomerRechargeCardCanRemoveFaultsAndManipulations formatting or length errors" },
        { 8011, "SetDateAndTimeMode formatting or length errors" },
        { 8012, "EditMeterDataOperations formatting or length errors" },
        { 8013, "ManipulationsAndFaultsToBeCleared formatting or length errors" },
        { 8014, "ControlCardActivationPeriod formatting errors" },
        { 8015, "Holidays formatting errors" },
        { 8016, "FriendlyTime formatting errors" },
        { 8017, "MaxLoadSettings formatting errors" },
        { 8018, "RechargeDetails or LastRechargeDetails formatting errors" },
        { 8019, "BillingDay formatting errors" },
        { 8020, "FeesAmounts formatting or length errors" },
        { 8021, "ZeroConsumptionFeeAmount formatting errors" },
        { 8022, "TariffGrace formatting errors" },
        { 8023, "BalanceAlarmCutoffLimits formatting errors" },
        { 8024, "MeterTimestampToSet formatting errors" },
        { 8025, "QuiteTime formatting errors" },
        { 8026, "GracePeriod formatting errors" },
        { 8027, "ResetMeterMode formatting or length errors" },
        { 8028, "HoardMoneyLimit formatting or length errors" },
        { 8029, "WeekOffDays formatting or length errors" },
        { 8030, "ControlCardActiveMeters formatting or length errors" },
        { 8031, "Extrafeeskwh formatting or length errors" },
        { 8032, "Extrafeesprice formatting or length errors" },
        { 8033, "StreetlightFee formatting or length errors" },
        { 8034, "DebtAmountLimit formatting or length errors" },
        { 8035, "SlidingIntervalDeductionDetails formatting errors" },
        { 8036, "SpecificDeductionDetails formatting errors" },
        { 8037, "NewMeterId formatting or length errors" },
        { 8038, "ElectricityDistributionID or NewElectricityDistributionID formatting or length errors" },
        { 8039, "MeterInstallerID formatting or length errors" },
        { 8040, "InstallingCardMode formatting errors" },
        { 8041, "ReverseCardRecoveryTime formatting or length errors" },
        { 8042, "LabTestCardAvailableTime formatting or length errors" },
        { 8043, "LabTestCardAvailableKWh formatting or length errors" },
        { 8044, "LabTestCardControlWords formatting or length errors" },
        { 8045, "ExtraFeeEveryKWH formatting or length errors" },
        { 8046, "InstallingMode formatting or length errors" },
        { 8102, "Decrypt or encrypt errors" },
        { 8201, "Hearder file or parameter file errors" },
        { 8301, "MaxLoadSettings maximum value exceed the scope" },
        { 8302, "RechargeDetails or LastRechargeDetails exceed the scope" },
        { 8303, "BalanceAlarmCutoffLimits exceed the scope" },
        { 8304, "ZeroConsumptionFeeAmount exceed the scope" },
        { 8305, "GracePeriod exceed the scope" },
        { 8306, "TariffsDetails.tariffStepPrice exceed the scope" },
        { 8307, "TariffsDetails.tariffStepLimitFrom exceed the scope" },
        { 8308, "TariffsDetails.tariffStepLimitTo exceed the scope" },
        { 8309, "TariffsDetails.tariffStepCustomerServiceFee exceed the scope" },
        { 8310, "TariffsDetails.tariffStepRecalculationEdge exceed the scope" },
        { 8311, "TariffsDetails.tariffStepRecalculationEdgeAddedAmount exceed the scope" },
        { 8312, "TariffGrace.tariffLimitGrace exceed the scope" },
        { 8313, "TariffGrace.tariffDeductionGrace exceed the scope" },
        { 8314, "TariffGrace.tariffGraceType exceed the scope" },
        { 8315, "TariffGrace.tariffGracevalue exceed the scope" },
        { 8316, "TariffGrace.tariffAlarmGrace exceed the scope" },
        { 8317, "SlidingIntervalDeductionDetails.slidingIntervalPrice exceed the scope" },
        { 8318, "FeesAmounts exceed the scope" },
        { 8319, "InstallingCardMode exceed the scope" }
    };

        public static void ThrowException(int errorCode)
        {
            if (ErrorCodeMessages.TryGetValue(errorCode, out var message))
            {
                throw new ErrorCodeException(errorCode,  $"[{errorCode}]:{message}");
            }
            else
            {
                throw new ErrorCodeException(errorCode, "An unknown error occurred.");
            }
        }

        public class ErrorCodeException : Exception
        {
            public int ErrorCode { get; }

            public ErrorCodeException(int errorCode, string message) : base(message)
            {
                ErrorCode = errorCode;
            }
        }
    }
}

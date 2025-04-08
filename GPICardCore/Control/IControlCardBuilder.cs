using GPICardCore.Master;

namespace GPICardCore
{
    public interface IControlCardBuilder
    {
        string CardName { get; }
        int CardType { get; }
        List<string> SelectedMeters { get; }

        event CardCreatedHandler OnCardCreated;

        string BuildAlarmCutoffLimitsCard(List<int> limits);
        string BuildAlterTariffCard(List<TariffStep> tariffSteps, TariffHeader header, decimal zeroConsumptionFeeAmount);
        string BuildChangeDistributionCompanyCodeCard(string NewNumber);
        string BuildChangeMeterNumberCard(string currentNumber, string NewNumber);
        string BuildClearTamperCard(List<int> tamperCodelist);
        string BuildCollectCard();
        string BuildCopyMeterCard(string SourceMeterSerial);
        string BuildLabCard(List<int> ControlWord, int AvailableKWh, int AvailableTime);
        string BuildLunchCurrentCard();
        string BuildRelayTestCard();
        string BuildResetMeterCard();
        string BuildSetDateTimeCard(DateTime DateTimeValue );
        string BuildSetDateTimeOnMeterManualCard();
        string BuildToggleRelayCard(int reverseCardRecoveryTime);
        IControlCardBuilder SetCardId(string cardId);
        IControlCardBuilder SetCardPeriod(ControlCardActivationPeriod cardDate);
        IControlCardBuilder SetDistributionCompanyCode(string distributionCompanyCode);
        IControlCardBuilder SetManufacturerId(string manufacturerId);
        IControlCardBuilder SetMeterType(int meterType);
        IControlCardBuilder SetMeterVersion(string meterVersion);
        IControlCardBuilder SetSectorCode(string sectorCode);
        IControlCardBuilder SetSelectedMeters(List<string> meters);
    }
}
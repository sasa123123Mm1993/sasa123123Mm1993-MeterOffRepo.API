namespace GPICardCore
{
    public enum ControlCardType
    {
        Reset,
        LunchCurrent  ,
        RelayTest,
        RelayToggle,
        ChangeMeterNumber,
        ChangeCompany,
        SetDateTime,
        SetDateTimeOnMeter,
        ClearTamper ,
        TarrifUpdate,
        AlarmCutoffLimits,
        Lab  ,
        Collect 
    }
}

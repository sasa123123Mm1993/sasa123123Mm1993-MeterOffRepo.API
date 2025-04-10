namespace GPICardCore
{
    public enum ControlCardType
    {
        ResetMeter,
        LunchCurrent  ,
        RelayTest,
        RelayToggle,
        ChangeMeterNumber,
        ChangeCompany,
        SetDateTimeAuto,
        SetDateTimeManual,
        ClearTamper ,
        TarrifUpdate,
        AlarmCutoffLimits,
        Lab  ,
        Collect ,
        CopyMeter,
        UnknownNotSupported
    }
}

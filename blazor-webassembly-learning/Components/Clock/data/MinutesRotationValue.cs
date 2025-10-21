namespace blazor;

public class MinutesRotationValue : ClockFaceRotationValue
{
    protected override int GetEpochOffset()
    {

        var minuteOffset = EpochTime.Minute * 60;
        return EpochTime.Second + minuteOffset;
    }
    
    public MinutesRotationValue(DateTime epochTime)
    {
        MaxRotationIncrement = 3600;
        
        EpochTime = epochTime;
        EpochOffset = GetEpochOffset();
    }
}
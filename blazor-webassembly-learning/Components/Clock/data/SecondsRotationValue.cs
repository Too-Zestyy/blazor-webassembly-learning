namespace blazor;

public class SecondsRotationValue : ClockFaceRotationValue
{
    protected override int GetEpochOffset()
    {
        return EpochTime.Second;
    }
    
    public SecondsRotationValue(DateTime epochTime)
    {
        MaxRotationIncrement = 60;
        
        EpochTime = epochTime;
        EpochOffset = GetEpochOffset();
    }
}
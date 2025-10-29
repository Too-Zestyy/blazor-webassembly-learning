namespace blazor;

public class TwelveHoursRotationValue : ClockFaceRotationValue
{
    protected override int GetEpochOffset()
    {
        return EpochTime.Second 
               + (EpochTime.Minute * 60) 
               + (EpochTime.Hour * 3600);
    }
    
    public TwelveHoursRotationValue(DateTime epochTime)
    {
        MaxRotationIncrement = 43200;
        
        EpochTime = epochTime;
        EpochOffset = GetEpochOffset();
    }
}
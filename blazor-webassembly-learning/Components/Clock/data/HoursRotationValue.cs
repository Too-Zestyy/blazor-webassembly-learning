namespace blazor;

public class HoursRotationValue : ClockFaceRotationValue
{
    protected override int GetEpochOffset()
    {
        return EpochTime.Second 
               + (EpochTime.Minute * 60) 
               + (EpochTime.Hour * 3600);
    }
    
    public HoursRotationValue(DateTime epochTime)
    {
        MaxRotationIncrement = 86400;
        
        EpochTime = epochTime;
        EpochOffset = GetEpochOffset();
    }
}
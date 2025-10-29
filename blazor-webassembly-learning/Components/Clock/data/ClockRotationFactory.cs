namespace blazor;

/// <summary>
/// Constructs instances of <c>ClockFaceRotationValue</c> for common units within a clock,
/// such as seconds, minutes, and hours.
/// </summary>
static class ClockRotationFactory
{
    public const int Minute = 60;
    public const int Hour = Minute * 60;
    public const int Day = Hour * 24;
    
    public static ClockFaceRotationValue BuildSecondsRotationManager(DateTime epoch)
    {
        return new SecondsRotationValue(epoch);
    }

    public static ClockFaceRotationValue BuildSecondsRotationManagerFromNow()
    {
        return BuildSecondsRotationManager(DateTime.Now);
    }
    
    public static ClockFaceRotationValue BuildMinutesRotationManager(DateTime epoch)
    {
        return new MinutesRotationValue(epoch);
    }
    public static ClockFaceRotationValue BuildMinutesRotationManagerFromNow()
    {
        return BuildMinutesRotationManager(DateTime.Now);
    }
    
    public static ClockFaceRotationValue BuildTwelveHoursRotationManager(DateTime epoch)
    {
        return new TwelveHoursRotationValue(epoch);
    }
    public static ClockFaceRotationValue BuildHoursRotationManagerFromNow()
    {
        return BuildTwelveHoursRotationManager(DateTime.Now);
    }
    
}
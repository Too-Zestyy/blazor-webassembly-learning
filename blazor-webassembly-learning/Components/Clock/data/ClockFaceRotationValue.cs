namespace blazor;
 
/// <summary>
/// <para>
/// Manages the rotation needed to represent the current time on a clock, assuming the normal clockwise layout
/// (or one that shows an identical value for the same rotation).
/// </para>
///
/// <para>
/// <c>EpochTime</c> is used to manage the amount of total rotations required to represent the
/// total time elapsed between it and the given <c>DateTime</c>, allowing for a constantly increasing rotation value
/// through rotations as opposed to a reset to <c>0deg</c>.
/// </para>
///
/// <para>
/// Child classes should specify <c>MaxRotationIncrement</c> and <c>GetEpochOffset</c> to signal both
/// the value representing a full rotation, and how to extract the number of seconds from <c>EpochOffset</c>
/// to correctly set an initial value.
/// </para>
/// </summary>
public abstract class ClockFaceRotationValue
{

    protected int MaxRotationIncrement { get; set; }
    protected DateTime EpochTime { get; set; }
    
    protected int EpochOffset { get; set; }

    protected abstract int GetEpochOffset();

    public ClockFaceRotationValue()
    {
        EpochTime = DateTime.Now;
        EpochOffset = GetEpochOffset();
    }

    public ClockFaceRotationValue(int maxRotationIncrement)
    {
        MaxRotationIncrement = maxRotationIncrement;
        
        EpochTime = DateTime.Now;
        EpochOffset = GetEpochOffset();
    }
    
    public ClockFaceRotationValue(int maxRotationIncrement, DateTime epochTime)
    {
        MaxRotationIncrement = maxRotationIncrement;
        
        EpochTime = epochTime;
        EpochOffset = GetEpochOffset();
    }

    public int GetTotalRotationIncrementsForTime(DateTime time)
    {
        TimeSpan delta = time - EpochTime;
        
        // Throw error if the clock has run long enough to be outside the 32-bit int range
        int totalWholeSeconds = Convert.ToInt32(Math.Floor(delta.TotalSeconds)) + EpochOffset;
        
        return totalWholeSeconds;
        
    }

    public int GetTotalRotationIncrementsForCurrentTime()
    {
        return GetTotalRotationIncrementsForTime(DateTime.Now);
    }

    public string GetCurrentCssValue()
    {
        var degreeValue = GetTotalRotationIncrementsForCurrentTime() * (360f  /  MaxRotationIncrement);
        return $"{degreeValue}deg";
    }
    
}
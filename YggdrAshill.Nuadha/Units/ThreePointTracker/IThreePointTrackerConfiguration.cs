namespace YggdrAshill.Nuadha
{
    public interface IThreePointTrackerConfiguration
    {
        IPoseTrackerConfiguration Origin { get; }
        
        IPoseTrackerConfiguration Head { get; }

        IPoseTrackerConfiguration LeftHand { get; }
        
        IPoseTrackerConfiguration RightHand { get; }
    }
}

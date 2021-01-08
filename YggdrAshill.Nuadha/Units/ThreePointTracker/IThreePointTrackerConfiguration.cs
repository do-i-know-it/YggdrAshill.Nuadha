namespace YggdrAshill.Nuadha
{
    public interface IThreePointTrackerConfiguration
    {
        IPoseTrackerConfiguration PoseTracker { get; }

        IHeadsetConfiguration Head { get; }

        IHandControllerConfiguration LeftHand { get; }

        IHandControllerConfiguration RightHand { get; }
    }
}

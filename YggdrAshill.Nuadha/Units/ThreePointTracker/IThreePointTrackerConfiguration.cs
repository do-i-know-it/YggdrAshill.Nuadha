namespace YggdrAshill.Nuadha
{
    public interface IThreePointTrackerConfiguration
    {
        IHeadsetConfiguration Head { get; }

        IHandControllerConfiguration LeftHand { get; }

        IHandControllerConfiguration RightHand { get; }
    }
}

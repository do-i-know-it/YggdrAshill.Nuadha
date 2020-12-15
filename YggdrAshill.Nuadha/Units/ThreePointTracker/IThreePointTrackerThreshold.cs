namespace YggdrAshill.Nuadha
{
    public interface IThreePointTrackerThreshold
    {
        IHeadsetThreshold Head { get; }

        IHandControllerThreshold LeftHand { get; }

        IHandControllerThreshold RightHand { get; }
    }
}

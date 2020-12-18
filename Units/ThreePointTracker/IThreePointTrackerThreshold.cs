namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerThreshold
    {
        IHeadsetThreshold Head { get; }

        IHandControllerThreshold LeftHand { get; }

        IHandControllerThreshold RightHand { get; }
    }
}

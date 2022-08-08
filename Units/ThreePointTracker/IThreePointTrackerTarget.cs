namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerTarget
    {
        IHeadTrackerTarget Head { get; }

        IHandControllerTarget LeftHand { get; }

        IHandControllerTarget RightHand { get; }
    }
}

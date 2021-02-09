namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerThreshold
    {
        IHandControllerThreshold LeftHand { get; }

        IHandControllerThreshold RightHand { get; }
    }
}

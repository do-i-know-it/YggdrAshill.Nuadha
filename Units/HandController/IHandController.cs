namespace YggdrAshill.Nuadha.Units
{
    public interface IHandController
    {
        IPoseTracker Pose { get; }

        IStick Thumb { get; }

        ITrigger IndexFinger { get; }

        ITrigger HandGrip { get; }
    }
}

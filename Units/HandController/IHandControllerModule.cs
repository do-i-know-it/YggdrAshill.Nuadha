namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerModule
    {
        IPoseTrackerModule Pose { get; }

        IStickModule Thumb { get; }

        ITriggerModule IndexFinger { get; }

        ITriggerModule HandGrip { get; }
    }
}

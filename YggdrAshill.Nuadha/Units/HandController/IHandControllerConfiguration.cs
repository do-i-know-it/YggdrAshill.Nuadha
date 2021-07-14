namespace YggdrAshill.Nuadha
{
    public interface IHandControllerConfiguration
    {
        IPoseTrackerConfiguration Pose { get; }

        IStickConfiguration Thumb { get; }

        ITriggerConfiguration IndexFinger { get; }

        ITriggerConfiguration HandGrip { get; }
    }
}

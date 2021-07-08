using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IHandControllerSoftware :
        IHandler
    {
        IPoseTrackerSoftware Pose { get; }

        IStickSoftware Thumb { get; }

        ITriggerSoftware IndexFinger { get; }

        ITriggerSoftware HandGrip { get; }
    }
}

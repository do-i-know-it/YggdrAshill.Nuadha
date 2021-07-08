using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IHandControllerHardware :
        IHandler
    {
        IPoseTrackerHardware Pose { get; }

        IStickHardware Thumb { get; }

        ITriggerHardware IndexFinger { get; }

        ITriggerHardware HandGrip { get; }
    }
}

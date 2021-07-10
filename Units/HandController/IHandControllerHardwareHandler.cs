using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerHardwareHandler :
        IHandler
    {
        IPoseTrackerHardwareHandler Pose { get; }

        IStickHardwareHandler Thumb { get; }

        ITriggerHardwareHandler IndexFinger { get; }

        ITriggerHardwareHandler HandGrip { get; }
    }
}

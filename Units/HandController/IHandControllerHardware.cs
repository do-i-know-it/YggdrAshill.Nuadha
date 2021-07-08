using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
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

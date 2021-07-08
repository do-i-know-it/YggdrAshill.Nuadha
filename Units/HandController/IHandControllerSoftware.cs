using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
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

using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedHandControllerHardwareHandler :
        IHandler
    {
        IPulsatedStickHardwareHandler Thumb { get; }

        IPulsatedTriggerHardwareHandler IndexFinger { get; }

        IPulsatedTriggerHardwareHandler HandGrip { get; }
    }
}

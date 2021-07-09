using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedHandControllerSoftwareHandler :
        IHandler
    {
        IPulsatedStickSoftwareHandler Thumb { get; }

        IPulsatedTriggerSoftwareHandler IndexFinger { get; }

        IPulsatedTriggerSoftwareHandler HandGrip { get; }
    }
}

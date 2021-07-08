using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerPulsationHardware :
        IHandler
    {
        IStickPulsationHardware Thumb { get; }

        ITriggerPulsationHardware IndexFinger { get; }

        ITriggerPulsationHardware HandGrip { get; }
    }
}

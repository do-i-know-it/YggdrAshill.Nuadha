using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IHandControllerPulsationHardware :
        IHandler
    {
        IStickPulsationHardware Thumb { get; }

        ITriggerPulsationHardware IndexFinger { get; }

        ITriggerPulsationHardware HandGrip { get; }
    }
}

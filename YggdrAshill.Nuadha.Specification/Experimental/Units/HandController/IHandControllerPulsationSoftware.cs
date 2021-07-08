using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IHandControllerPulsationSoftware :
        IHandler
    {
        IStickPulsationSoftware Thumb { get; }

        ITriggerPulsationSoftware IndexFinger { get; }

        ITriggerPulsationSoftware HandGrip { get; }
    }
}

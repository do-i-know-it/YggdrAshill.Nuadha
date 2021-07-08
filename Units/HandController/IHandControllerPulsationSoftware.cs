using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerPulsationSoftware :
        IHandler
    {
        IStickPulsationSoftware Thumb { get; }

        ITriggerPulsationSoftware IndexFinger { get; }

        ITriggerPulsationSoftware HandGrip { get; }
    }
}

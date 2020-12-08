using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerHardwareHandler :
        IHardwareHandler
    {
        IInputTerminal<Touch> Touch { get; }

        IInputTerminal<Pull> Pull { get; }
    }
}

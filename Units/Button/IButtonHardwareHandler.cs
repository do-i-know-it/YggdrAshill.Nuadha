using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonHardwareHandler :
        IHardwareHandler
    {
        IInputTerminal<Touch> Touch { get; }

        IInputTerminal<Push> Push { get; }
    }
}

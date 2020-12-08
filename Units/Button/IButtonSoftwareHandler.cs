using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonSoftwareHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Touch> Touch { get; }

        IOutputTerminal<Push> Push { get; }
    }
}

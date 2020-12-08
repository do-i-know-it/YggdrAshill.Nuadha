using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerSoftwareHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Touch> Touch { get; }

        IOutputTerminal<Pull> Pull { get; }
    }
}

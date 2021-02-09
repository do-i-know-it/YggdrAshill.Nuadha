using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerSoftwareHandler :
        ISoftwareHandler
    {
        IConnection<Touch> Touch { get; }

        IConnection<Pull> Pull { get; }
    }
}

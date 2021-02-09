using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonSoftwareHandler :
        ISoftwareHandler
    {
        IConnection<Touch> Touch { get; }

        IConnection<Push> Push { get; }
    }
}

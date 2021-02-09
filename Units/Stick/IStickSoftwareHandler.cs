using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickSoftwareHandler :
        ISoftwareHandler,
        IButtonSoftwareHandler
    {
        IConnection<Tilt> Tilt { get; }
    }
}

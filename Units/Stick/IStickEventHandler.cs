using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickEventHandler :
        ISoftwareHandler,
        IButtonEventHandler
    {
        ITiltEventHandler Tilt { get; }
    }
}

using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickEventOutputHandler :
        ISoftwareHandler,
        IButtonEventOutputHandler
    {
        ITiltEventOutputHandler Tilt { get; }
    }
}

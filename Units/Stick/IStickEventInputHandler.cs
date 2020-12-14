using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickEventInputHandler :
        IHardwareHandler,
        IButtonEventInputHandler
    {
        ITiltEventInputHandler Tilt { get; }
    }
}

using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickEventInputHandler :
        IHardwareHandler,
        IButtonEventInputHandler
    {
        ITiltEventInputHandler Tilt { get; }
    }
}

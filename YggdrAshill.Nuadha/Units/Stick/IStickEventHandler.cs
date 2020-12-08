using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickEventHandler :
        ISoftwareHandler,
        IButtonEventHandler
    {
        ITiltEventHandler Tilt { get; }
    }
}

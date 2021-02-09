using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionInputHandler :
        IHardwareHandler,
        IButtonDetectionInputHandler
    {
        ITiltDetectionInputHandler Tilt { get; }
    }
}

using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionHardwareHandler :
        IHardwareHandler,
        IButtonDetectionHardwareHandler
    {
        ITiltDetectionHardwareHandler Tilt { get; }
    }
}

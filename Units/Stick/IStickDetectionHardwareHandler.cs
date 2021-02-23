using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionHardwareHandler :
        ISystem,
        IButtonDetectionHardwareHandler
    {
        ITiltDetectionHardwareHandler Tilt { get; }
    }
}

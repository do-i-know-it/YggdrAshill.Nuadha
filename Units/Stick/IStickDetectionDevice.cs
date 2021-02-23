using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionDevice :
        IDevice
    {
        IDetectionDevice Touch { get; }

        ITiltDetectionDevice Tilt { get; }
    }
}

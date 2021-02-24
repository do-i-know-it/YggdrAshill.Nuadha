using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionHardware :
        IHardware
    {
        IDetectionHardware Touch { get; }

        ITiltDetectionHardware Tilt { get; }
    }
}

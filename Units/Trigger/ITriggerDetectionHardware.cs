using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionHardware :
        IHardware
    {
        IDetectionHardware Touch { get; }

        IDetectionHardware Pull { get; }
    }
}

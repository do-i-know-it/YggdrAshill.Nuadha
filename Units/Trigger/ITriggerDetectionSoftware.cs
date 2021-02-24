using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionSoftware :
        ISoftware
    {
        IDetectionSoftware Touch { get; }

        IDetectionSoftware Pull { get; }
    }
}

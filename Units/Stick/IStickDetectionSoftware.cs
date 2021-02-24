using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionSoftware :
        ISoftware
    {
        IDetectionSoftware Touch { get; }

        ITiltDetectionSoftware Tilt { get; }
    }
}

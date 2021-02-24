using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionSoftware :
        ISoftware
    {
        IDetectionSoftware Touch { get; }

        IDetectionSoftware Push { get; }
    }
}

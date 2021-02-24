using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionHardware :
        IHardware
    {
        IDetectionHardware Touch { get; }

        IDetectionHardware Push { get; }
    }
}

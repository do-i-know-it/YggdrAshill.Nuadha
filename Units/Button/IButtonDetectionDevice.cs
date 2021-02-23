using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionDevice :
        IDevice
    {
        IDetectionDevice Touch { get; }

        IDetectionDevice Push { get; }
    }
}

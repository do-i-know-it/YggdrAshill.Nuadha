using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionHardwareHandler :
        IHardwareHandler
    {
        IDetectionHardwareHandler Touch { get; }

        IDetectionHardwareHandler Push { get; }
    }
}

using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionHardwareHandler :
        ISystem
    {
        IDetectionHardwareHandler Touch { get; }

        IDetectionHardwareHandler Push { get; }
    }
}

using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionHardwareHandler :
        ISystem
    {
        IDetectionHardwareHandler Touch { get; }

        IDetectionHardwareHandler Pull { get; }
    }
}

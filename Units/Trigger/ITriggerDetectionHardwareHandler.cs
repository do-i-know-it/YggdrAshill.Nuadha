using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionHardwareHandler :
        IHardwareHandler
    {
        IDetectionHardwareHandler Touch { get; }

        IDetectionHardwareHandler Pull { get; }
    }
}

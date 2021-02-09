using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionInputHandler :
        IHardwareHandler
    {
        IPulseDetectionInputHandler Touch { get; }

        IPulseDetectionInputHandler Pull { get; }
    }
}

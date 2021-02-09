using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionOutputHandler :
        ISoftwareHandler
    {
        IPulseDetectionOutputHandler Touch { get; }

        IPulseDetectionOutputHandler Pull { get; }
    }
}

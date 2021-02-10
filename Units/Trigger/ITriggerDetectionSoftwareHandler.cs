using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionSoftwareHandler :
        ISoftwareHandler
    {
        IDetectionSoftwareHandler Touch { get; }

        IDetectionSoftwareHandler Pull { get; }
    }
}

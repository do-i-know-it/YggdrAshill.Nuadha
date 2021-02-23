using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionSystem :
        ISystem
    {
        IDetectionSystem Touch { get; }

        IDetectionSystem Pull { get; }
    }
}

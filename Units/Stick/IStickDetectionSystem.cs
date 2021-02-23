using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionSystem :
        ISystem
    {
        IDetectionSystem Touch { get; }

        ITiltDetectionSystem Tilt { get; }
    }
}

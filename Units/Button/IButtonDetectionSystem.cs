using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionSystem :
        ISystem
    {
        IDetectionSystem Touch { get; }

        IDetectionSystem Push { get; }
    }
}

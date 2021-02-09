using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionOutputHandler :
        ISoftwareHandler,
        IButtonDetectionOutputHandler
    {
        ITiltDetectionOutputHandler Tilt { get; }
    }
}

using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionOutputHandler :
        ISoftwareHandler
    {
        IPulseDetectionOutputHandler Touch { get; }

        IPulseDetectionOutputHandler Push { get; }
    }
}

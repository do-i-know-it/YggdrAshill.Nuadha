using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionInputHandler :
        IHardwareHandler
    {
        IPulseDetectionInputHandler Touch { get; }

        IPulseDetectionInputHandler Push { get; }
    }
}

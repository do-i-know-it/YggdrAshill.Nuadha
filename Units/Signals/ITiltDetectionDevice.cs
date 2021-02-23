using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionDevice :
        IDevice
    {
        IDetectionDevice Left { get; }

        IDetectionDevice Right { get; }

        IDetectionDevice Forward { get; }

        IDetectionDevice Backward { get; }
    }
}

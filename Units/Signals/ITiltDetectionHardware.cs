using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionHardware :
        IHardware
    {
        IDetectionHardware Left { get; }

        IDetectionHardware Right { get; }

        IDetectionHardware Forward { get; }

        IDetectionHardware Backward { get; }
    }
}

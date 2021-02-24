using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionSoftware :
        ISoftware
    {
        IDetectionSoftware Left { get; }

        IDetectionSoftware Right { get; }

        IDetectionSoftware Forward { get; }

        IDetectionSoftware Backward { get; }
    }
}

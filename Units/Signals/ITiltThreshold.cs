using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltThreshold
    {
        IHysteresisThreshold Left { get; }

        IHysteresisThreshold Right { get; }

        IHysteresisThreshold Forward { get; }

        IHysteresisThreshold Backward { get; }
    }
}

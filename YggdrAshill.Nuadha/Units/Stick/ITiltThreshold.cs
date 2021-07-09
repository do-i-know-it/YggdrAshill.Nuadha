using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITiltThreshold
    {
        HysteresisThreshold Distance { get; }

        HysteresisThreshold Left { get; }

        HysteresisThreshold Right { get; }

        HysteresisThreshold Forward { get; }

        HysteresisThreshold Backward { get; }
    }
}

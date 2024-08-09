using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public interface IHysteresisThreshold<in TSignal>
        where TSignal : ISignal
    {
        IDetection<TSignal> HighLevel { get; }
        IDetection<TSignal> LowLevel { get; }
    }
}

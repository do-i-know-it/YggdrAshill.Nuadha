using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Operation
{
    public interface IDetection<TSignal>
        where TSignal : ISignal
    {
        bool Detect(TSignal signal);
    }
}

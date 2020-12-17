using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Translation
{
    public interface IDetection<TSignal>
        where TSignal : ISignal
    {
        bool Detect(TSignal signal);
    }
}

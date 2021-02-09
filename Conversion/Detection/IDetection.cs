using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    public interface IDetection<TSignal>
        where TSignal : ISignal
    {
        bool Detect(TSignal signal);
    }
}

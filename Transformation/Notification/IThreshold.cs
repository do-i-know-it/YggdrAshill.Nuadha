using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    public interface IThreshold<TSignal>
        where TSignal : ISignal
    {
        TSignal Signal { get; }
    }
}

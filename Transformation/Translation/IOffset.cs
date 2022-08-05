using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    public interface IOffset<TSignal>
        where TSignal : ISignal
    {
        TSignal Signal { get; }
    }
}

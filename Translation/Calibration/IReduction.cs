using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    public interface IReduction<TSignal>
        where TSignal : ISignal
    {
        TSignal Reduce(TSignal left, TSignal right);
    }
}

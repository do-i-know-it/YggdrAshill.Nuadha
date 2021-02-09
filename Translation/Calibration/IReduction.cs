using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Translation
{
    public interface IReduction<TSignal>
        where TSignal : ISignal
    {
        TSignal Reduce(TSignal left, TSignal right);
    }
}

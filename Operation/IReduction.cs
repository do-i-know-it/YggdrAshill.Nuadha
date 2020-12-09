using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Operation
{
    public interface IReduction<TSignal>
        where TSignal : ISignal
    {
        TSignal Reduce(TSignal left, TSignal right);
    }
}

using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public interface IFiltration<TSignal>
        where TSignal : ISignal
    {
        TSignal Filtrate(TSignal current, TSignal previous);
    }
}

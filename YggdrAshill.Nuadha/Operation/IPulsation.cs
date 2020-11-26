using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Operation
{
    public interface IPulsation<TSignal>
        where TSignal : ISignal
    {
        bool Pulsate(TSignal previous, TSignal current);
    }
}

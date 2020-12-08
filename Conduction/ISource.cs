using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    public interface ISource<TSignal>
        where TSignal : ISignal
    {
        IEmission Connect(IInputTerminal<TSignal> terminal);
    }
}

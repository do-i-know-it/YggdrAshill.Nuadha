using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    public interface IPropagation<TSignal> :
        IConsumption<TSignal>,
        IConnection<TSignal>,
        IDisconnection
        where TSignal : ISignal
    {

    }
}

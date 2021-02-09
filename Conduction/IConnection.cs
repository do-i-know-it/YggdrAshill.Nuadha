using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    public interface IConnection<TSignal>
        where TSignal : ISignal
    {
        IDisconnection Connect(IConsumption<TSignal> consumption);
    }
}

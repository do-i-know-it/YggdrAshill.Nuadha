using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IGenerator<TSignal> :
        IOutputTerminal<TSignal>,
        IIgnition,
        IDisconnection
        where TSignal : ISignal
    {

    }
}

using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    public interface IGenerator<TSignal> :
        IOutputTerminal<TSignal>,
        IIgnitor,
        IDisconnection
        where TSignal : ISignal
    {

    }
}

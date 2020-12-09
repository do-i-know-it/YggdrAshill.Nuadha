using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPushEventSystem :
        IInputTerminal<Push>,
        IPushEventHandler,
        IDisconnection
    {

    }
}

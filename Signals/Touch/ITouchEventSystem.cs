using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITouchEventSystem :
        IInputTerminal<Touch>,
        ITouchEventHandler,
        IDisconnection
    {

    }
}

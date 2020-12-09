using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPullEventSystem :
        IInputTerminal<Pull>,
        IPullEventHandler,
        IDisconnection
    {

    }
}

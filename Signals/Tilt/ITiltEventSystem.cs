using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventSystem :
        IInputTerminal<Tilt>,
        ITiltEventHandler,
        IDisconnection
    {

    }
}

using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITouchEventSystem :
        IConnection<Touch>,
        ITouchEventHandler,
        IDisconnection
    {

    }
}

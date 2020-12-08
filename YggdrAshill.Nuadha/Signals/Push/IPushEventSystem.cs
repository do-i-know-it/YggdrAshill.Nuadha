using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPushEventSystem :
        IConnection<Push>,
        IPushEventHandler,
        IDisconnection
    {

    }
}

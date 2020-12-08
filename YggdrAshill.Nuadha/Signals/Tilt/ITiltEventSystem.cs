using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITiltEventSystem :
        IConnection<Tilt>,
        ITiltEventHandler,
        IDisconnection
    {

    }
}

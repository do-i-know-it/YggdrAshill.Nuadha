using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITouchEventSystem :
        IDivider<Touch>,
        ITouchEventHandler,
        IDisconnection
    {

    }
}

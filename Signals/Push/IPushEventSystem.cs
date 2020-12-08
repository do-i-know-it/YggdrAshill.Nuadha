using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPushEventSystem :
        IDivider<Push>,
        IPushEventHandler,
        IDisconnection
    {

    }
}

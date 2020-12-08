using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPullEventSystem :
        IDivider<Pull>,
        IPullEventHandler,
        IDisconnection
    {

    }
}

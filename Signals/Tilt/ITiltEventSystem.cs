using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventSystem :
        IDivider<Tilt>,
        ITiltEventHandler,
        IDisconnection
    {

    }
}

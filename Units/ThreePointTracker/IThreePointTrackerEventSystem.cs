using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerEventSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IThreePointTrackerEventHandler,
        IDisconnection
    {

    }
}

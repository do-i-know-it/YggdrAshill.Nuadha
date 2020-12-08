using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerEventSystem :
        ISoftware<IHandControllerSoftwareHandler>,
        IHandControllerEventHandler,
        IDisconnection
    {

    }
}

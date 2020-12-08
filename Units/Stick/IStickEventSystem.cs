using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickEventSystem :
        ISoftware<IStickSoftwareHandler>,
        IStickEventHandler,
        IDisconnection
    {

    }
}

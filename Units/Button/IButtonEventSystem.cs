using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventSystem :
        ISoftware<IButtonSoftwareHandler>,
        IButtonEventHandler,
        IDisconnection
    {

    }
}

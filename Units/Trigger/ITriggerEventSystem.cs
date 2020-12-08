using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventSystem :
        ISoftware<ITriggerSoftwareHandler>,
        ITriggerEventHandler,
        IDisconnection
    {

    }
}

using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IOutputSoftware<TDevice> :
        ISoftware<TDevice>,
        IDisconnection,
        IIgnition
        where TDevice : IDevice
    {

    }
}

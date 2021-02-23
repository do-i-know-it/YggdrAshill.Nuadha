using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha
{
    public interface IOutputSoftware<TDevice> :
        ISoftware<TDevice>,
        IDisconnection,
        IIgnition
        where TDevice : IDevice
    {

    }
}

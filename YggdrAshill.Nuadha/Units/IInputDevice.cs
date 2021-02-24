using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha
{
    public interface IInputDevice<TSoftware> :
        IDevice<TSoftware>,
        IDisconnection,
        IIgnition
        where TSoftware : ISoftware
    {

    }
}

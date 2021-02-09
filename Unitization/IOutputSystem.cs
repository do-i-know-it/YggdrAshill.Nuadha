using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IOutputSystem<TSoftwareHandler> :
        ISoftware<TSoftwareHandler>,
        IDisconnection,
        IIgnition
        where TSoftwareHandler : ISoftwareHandler
    {

    }
}

using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface ISoftwareConfiguration<TSoftwareHandler>
        where TSoftwareHandler : ISoftwareHandler
    {
        IEmission Connect(TSoftwareHandler handler);
    }
}

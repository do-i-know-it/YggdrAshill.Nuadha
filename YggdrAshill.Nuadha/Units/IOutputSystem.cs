using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha
{
    public interface IOutputSystem<THardware> :
        ISystem<THardware>,
        IDisconnection,
        IIgnition
        where THardware : IHardware
    {

    }
}

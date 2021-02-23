using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha
{
    public interface IInputHardware<TSystem> :
        IHardware<TSystem>,
        IDisconnection,
        IIgnition
        where TSystem : ISystem
    {

    }
}

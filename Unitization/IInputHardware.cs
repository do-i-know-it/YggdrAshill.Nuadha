using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IInputHardware<TSystem> :
        IHardware<TSystem>,
        IDisconnection,
        IIgnition
        where TSystem : ISystem
    {

    }
}

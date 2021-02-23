using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IHardware<TSystem>
        where TSystem : ISystem
    {
        IDisconnection Connect(TSystem system);
    }
}

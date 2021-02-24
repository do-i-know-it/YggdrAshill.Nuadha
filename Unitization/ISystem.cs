using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface ISystem<THardware>
        where THardware : IHardware
    {
        IDisconnection Connect(THardware hardware);
    }
}

using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IHardwareConfiguration<THardwareHandler>
        where THardwareHandler : IHardwareHandler
    {
        IEmission Connect(THardwareHandler handler);
    }
}
